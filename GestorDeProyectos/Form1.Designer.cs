namespace GestorDeProyectos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxElegir = new System.Windows.Forms.ComboBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxElegir
            // 
            this.comboBoxElegir.FormattingEnabled = true;
            this.comboBoxElegir.Items.AddRange(new object[] {
            "Gestionar Usuarios",
            "Gestionar Proyecto"});
            this.comboBoxElegir.Location = new System.Drawing.Point(80, 35);
            this.comboBoxElegir.Name = "comboBoxElegir";
            this.comboBoxElegir.Size = new System.Drawing.Size(184, 21);
            this.comboBoxElegir.TabIndex = 0;
            this.comboBoxElegir.Text = "Seleccionar Opcion";
            this.comboBoxElegir.SelectedIndexChanged += new System.EventHandler(this.comboBoxElegir_SelectedIndexChanged);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(93, 97);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 1;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(174, 97);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 2;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 149);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.comboBoxElegir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxElegir;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonSalir;
    }
}

