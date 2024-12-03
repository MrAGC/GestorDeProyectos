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
        private List<string> usuariosSeleccionados = new List<string>();
        private List<Tareas> tareas = new List<Tareas>();
        private List<string> subtareas = new List<string>();

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
            string nombreTarea = textBoxTarea.Text;

            if (!string.IsNullOrWhiteSpace(nombreTarea))
            {
                // Verificar si la tarea ya existe
                if (tareas.Any(t => t.NombreTarea.Equals(nombreTarea, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("La tarea ya existe. Por favor, ingresa un nombre diferente.");
                    return;
                }

                Tareas crearTarea = new Tareas
                {
                    NombreTarea = nombreTarea,
                };

                tareas.Add(crearTarea);
                ListViewItem item = new ListViewItem(nombreTarea);
                listViewTareas.Items.Add(item);
                listViewTareas.View = View.List;
                comboBoxTareas.Items.Add(crearTarea.NombreTarea);
                textBoxTarea.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una tarea.");
            }
        }

        private void buttonAgregarSubtarea_Click(object sender, EventArgs e)
        {
            string nombreSubtarea = textBoxSubtarea.Text;

            if (!string.IsNullOrWhiteSpace(nombreSubtarea))
            {
                // Verificar si la subtarea ya existe
                if (subtareas.Any(s => s.Equals(nombreSubtarea, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("La subtarea ya existe. Por favor, ingresa un nombre diferente.");
                    return;
                }

                subtareas.Add(nombreSubtarea);
                ListViewItem item = new ListViewItem(nombreSubtarea);
                listViewSubtareas.Items.Add(item);
                listViewSubtareas.View = View.List;
                textBoxSubtarea.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una subtarea.");
            }
        }

        private void buttonComfirmarSubtareas_Click(object sender, EventArgs e)
        {
            
            if (comboBoxTareas.SelectedItem != null)
            {
                string tareaSeleccionada = comboBoxTareas.SelectedItem.ToString();
                var tareaEncontrada = tareas.FirstOrDefault(t => t.NombreTarea.Equals(tareaSeleccionada, StringComparison.OrdinalIgnoreCase));

                if (tareaEncontrada != null)
                {
                    // Verificar si las subtareas ya están asociadas a la tarea
                    if (tareaEncontrada.Subtareas == null)
                    {
                        tareaEncontrada.Subtareas = new List<string>();
                    }

                    foreach (var subtarea in subtareas)
                    {
                        if (tareaEncontrada.Subtareas.Any(s => s.Equals(subtarea, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show($"La subtarea '{subtarea}' ya está asociada a la tarea '{tareaSeleccionada}'.");
                            subtareas.Clear();
                            listViewSubtareas.Clear();
                            return;
                            
                        }
                    }


                    
                    tareaEncontrada.Subtareas.AddRange(subtareas);
                    MessageBox.Show("Subtareas añadidas exitosamente.");
                    listViewSubtareas.Clear();
                    subtareas.Clear();
                  
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una tarea.");
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
                    MessageBox.Show("Proyecto creado exitosamente.");
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

