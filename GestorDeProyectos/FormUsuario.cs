using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GestorDeProyectos
{
    public partial class FormUsuario : Form
    {
        Boolean desarrollador;
        string usuario;
        string contrasena;
        private static readonly string ClaveEncriptacion = "0123456789012345"; // Clave de 16 caracteres para AES
        private static readonly byte[] IVPersonalizado = Encoding.UTF8.GetBytes("5432109876543210"); // IV invertido (16 bytes)

        public FormUsuario()
        {
            InitializeComponent();
            this.FormClosing += FormProyectos_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormProyectos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            usuario = textBoxUsuario.Text;
            contrasena = textBoxContraseña.Text;
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Los campos estan vacios, rellenelos antes de aceptar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (crearJson(usuario, contrasena))
                {
                    MessageBox.Show("Usuario creado exitosamente.");
                    this.Hide();
                    Form1 nuevoForm = new Form1();
                    nuevoForm.ShowDialog();
                }
            }
        }

        private string EncriptarJson(string json)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ClaveEncriptacion);
                aesAlg.IV = IVPersonalizado;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(json);
                        }
                    }

                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
        }


        private string DesencriptarJson(string jsonEncriptado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ClaveEncriptacion);
                aesAlg.IV = IVPersonalizado;

                byte[] datosEncriptados = Convert.FromBase64String(jsonEncriptado);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(datosEncriptados))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private bool crearJson(string usuario, string contrasena)
        {
            string rutaArchivo = "usuarios.json";
            List<Usuario> usuarios;

            if (File.Exists(rutaArchivo))
            {
                string contenidoEncriptado = File.ReadAllText(rutaArchivo);
                if (!string.IsNullOrWhiteSpace(contenidoEncriptado))
                {
                    try
                    {
                        string contenidoDesencriptado = DesencriptarJson(contenidoEncriptado);
                        usuarios = JsonConvert.DeserializeObject<List<Usuario>>(contenidoDesencriptado) ?? new List<Usuario>();
                    }
                    catch
                    {
                        MessageBox.Show("El archivo JSON está dañado o no se puede desencriptar.");
                        return false;
                    }
                }
                else
                {
                    usuarios = new List<Usuario>();
                }
            }
            else
            {
                usuarios = new List<Usuario>();
            }

            if (usuarios.Any(u => u.NombreUsuario == usuario))
            {
                MessageBox.Show("El usuario ya existe.");
                return false;
            }

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = textBoxUsuario.Text,
                Contraseña = textBoxContraseña.Text,
                EsDesarrolador = desarrollador
            };
            usuarios.Add(nuevoUsuario);

            string jsonSerializado = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            string jsonEncriptado = EncriptarJson(jsonSerializado);
            File.WriteAllText(rutaArchivo, jsonEncriptado);

            return true;
        }

        private void checkBoxDesarrollador_CheckedChanged(object sender, EventArgs e)
        {
            desarrollador = checkBoxDesarrollador.Checked;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            this.textBoxContraseña.UseSystemPasswordChar = true;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 nuevoForm = new Form1();
            nuevoForm.ShowDialog();
        }
    }
}
