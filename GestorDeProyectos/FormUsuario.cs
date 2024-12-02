using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private bool crearJson(string usuario, string contrasena)
        {
            string rutaArchivo = "usuarios.json"; // Ruta del archivo JSON

            // Verificar si el archivo JSON existe
            if (!File.Exists(rutaArchivo))
            {
                // Si no existe, crearlo con un arreglo vacío
                File.WriteAllText(rutaArchivo, "[]");
            }

            // Leer el contenido del archivo JSON
            string json = File.ReadAllText(rutaArchivo);
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();

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
                EsDesarrolador = desarrollador // Asignar EsDesarrolador como true
            };
            usuarios.Add(nuevoUsuario);

            // Guardar la lista actualizada en el archivo JSON
            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(usuarios, Formatting.Indented));

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
