using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GestorDeProyectos
{
    public partial class FormUsuario : Form
    {
        Boolean desarrollador;
        string usuario;
        string contrasena;
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
            usuario = textBoxUsuario.Text; // Suponiendo que tienes un TextBox llamado txtUsuario
            contrasena = textBoxContraseña.Text; // Suponiendo que tienes un TextBox llamado txtContrasena
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

        private string EncriptarJson(string textoPlano, string clave)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32)); // Clave de 256 bits
                aes.IV = Encoding.UTF8.GetBytes("1234567812345678"); // Vector de inicialización de 128 bits

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        private string DesencriptarJson(string textoEncriptado, string clave)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32)); // Clave de 256 bits
                aes.IV = Encoding.UTF8.GetBytes("1234567812345678"); // Vector de inicialización de 128 bits

                byte[] buffer = Convert.FromBase64String(textoEncriptado);
                using (var memoryStream = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }


        private bool crearJson(string usuario, string contrasena)
        {
            string rutaArchivo = "usuarios.json"; // Ruta del archivo JSON
            const string claveEncriptacion = "1234567812345678"; // Clave de encriptación

            List<Usuario> usuarios;

            // Verificar si el archivo existe y desencriptarlo
            if (File.Exists(rutaArchivo))
            {
                string contenidoEncriptado = File.ReadAllText(rutaArchivo);
                if (!string.IsNullOrWhiteSpace(contenidoEncriptado))
                {
                    try
                    {
                        string contenidoDesencriptado = DesencriptarJson(contenidoEncriptado, claveEncriptacion);
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

            // Verificar si el usuario ya existe
            if (usuarios.Any(u => u.NombreUsuario == usuario))
            {
                MessageBox.Show("El usuario ya existe.");
                return false; // El usuario ya existe
            }

            // Crear un nuevo usuario y agregarlo a la lista
            var nuevoUsuario = new Usuario
            {
                NombreUsuario = textBoxUsuario.Text,
                Contraseña = textBoxContraseña.Text,
                EsDesarrolador = desarrollador // Asignar el valor de "desarrollador"
            };
            usuarios.Add(nuevoUsuario);

            // Serializar y encriptar la lista actualizada
            string jsonSerializado = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            string jsonEncriptado = EncriptarJson(jsonSerializado, claveEncriptacion);
            File.WriteAllText(rutaArchivo, jsonEncriptado);

            return true; // Usuario creado exitosamente
        }


        // Clase para representar a un usuario


        private void checkBoxDesarrollador_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDesarrollador.Checked == true)
            {
                desarrollador = true;
            }
            else 
            {
                desarrollador = false;
            }
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            this.textBoxContraseña.UseSystemPasswordChar = true;
        }
    }
}
