using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GestorDeProyectos
{
    public partial class FormProyectos : Form
    {
        String nomProyecto;
        String tarea;
        String subtarea;
        private List<string> tareas = new List<string>();
        private List<string> subtareas = new List<string>();
        private List<string> usuariosSeleccionados = new List<string>();

        public FormProyectos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarUsuarios();
            this.FormClosing += FormProyectos_FormClosing;
        }

        private void FormProyectos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CargarUsuarios()
        {
            string rutaArchivo = "usuarios.json"; // Ruta del archivo JSON

            // Verificar si el archivo JSON existe
            if (File.Exists(rutaArchivo))
            {
                // Leer el contenido del archivo JSON
                string json = File.ReadAllText(rutaArchivo);
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();

                // Limpiar el ListBox antes de agregar usuarios
                listBoxUsuarios.Items.Clear();

                // Agregar solo los nombres de los usuarios al ListBox
                foreach (var usuario in usuarios)
                {
                    listBoxUsuarios.Items.Add(usuario.NombreUsuario);
                }
            }
            else
            {
                MessageBox.Show("No hay usuarios registrados.");
            }
        }

        private void buttonAgregarTarea_Click(object sender, EventArgs e)
        {
            string tarea = textBoxTarea.Text; 

            if (!string.IsNullOrWhiteSpace(tarea)) 
            {
                tareas.Add(tarea); 
                ListViewItem item = new ListViewItem(tarea);
                listViewTareas.Items.Add(item);
                listViewTareas.View = View.List;
                comboBoxTareas.Items.Add(item.Text);
                textBoxTarea.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una tarea.");
            }
        }

        private void buttonAgregarSubtarea_Click(object sender, EventArgs e)
        {
            string subtarea = textBoxSubtarea.Text; 

            if (!string.IsNullOrWhiteSpace(subtarea)) 
            {
                subtareas.Add(subtarea);
                ListViewItem item = new ListViewItem(subtarea);
                listViewSubtareas.Items.Add(item);
                listViewSubtareas.View = View.List;
                textBoxSubtarea.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una subtarea.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreProyecto = textBoxProyecto.Text;
            

            if (string.IsNullOrWhiteSpace(nombreProyecto))
            {
                MessageBox.Show("Los campos estan vacios, rellenelos antes de aceptar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (crearJson(nombreProyecto))
                {
                    MessageBox.Show("Usuario creado exitosamente.");
                    this.Hide();
                    Form1 nuevoForm = new Form1();
                    nuevoForm.ShowDialog();

                }
            }
        }

        private bool crearJson(string nombreProyecto)
        {
            string rutaArchivo = "proyecto.json";

            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "[]");
            }

            string json = File.ReadAllText(rutaArchivo);
            var proyectos = JsonConvert.DeserializeObject<List<Proyecto>>(json) ?? new List<Proyecto>();

            
            if (proyectos.Any(u => u.NombreProyecto == nombreProyecto))
            {
                MessageBox.Show("El proyecto ya existe.");
                return false;
            }

            foreach (var item in listBoxUsuarios.SelectedItems)
            {
                usuariosSeleccionados.Add(item.ToString());
            }                                                                                                                                                      

            
            var nuevoProyecto = new Proyecto
            {
                NombreProyecto = textBoxProyecto.Text,
                Tareas = tareas,
                Subtareas = subtareas,
                FechaInicio = dateTimePickerDataInici.Value,
                FechaFin = dateTimePickerDataFin.Value,
                Usuarios = usuariosSeleccionados
            };
            proyectos.Add(nuevoProyecto);

            
            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(proyectos, Formatting.Indented));

            return true; 
        }

    }
}

