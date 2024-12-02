using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeProyectos
{
    public partial class Form1 : Form
    {
        String opcionComboBox;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (opcionComboBox == "Gestionar Usuarios")
            {
                this.Hide();
                FormUsuario nuevoForm = new FormUsuario();
                nuevoForm.ShowDialog();
            }
            else if(opcionComboBox == "Gestionar Proyecto")
            {
                this.Hide();
                FormProyectos nuevoForm = new FormProyectos();
                nuevoForm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Por favor, seleccione una opcion.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxElegir_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcionComboBox = comboBoxElegir.SelectedItem as String;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
