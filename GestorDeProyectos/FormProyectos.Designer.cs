namespace GestorDeProyectos
{
    partial class FormProyectos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxUsuarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProyecto = new System.Windows.Forms.TextBox();
            this.textBoxTarea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSubtarea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAgregarTarea = new System.Windows.Forms.Button();
            this.buttonAgregarSubtarea = new System.Windows.Forms.Button();
            this.listViewTareas = new System.Windows.Forms.ListView();
            this.listViewSubtareas = new System.Windows.Forms.ListView();
            this.dateTimePickerDataInici = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerDataFin = new System.Windows.Forms.DateTimePicker();
            this.buttonCrearProyecto = new System.Windows.Forms.Button();
            this.comboBoxTareas = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonComfirmarSubtareas = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUsuarios
            // 
            this.listBoxUsuarios.FormattingEnabled = true;
            this.listBoxUsuarios.Location = new System.Drawing.Point(525, 38);
            this.listBoxUsuarios.Name = "listBoxUsuarios";
            this.listBoxUsuarios.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxUsuarios.Size = new System.Drawing.Size(164, 316);
            this.listBoxUsuarios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar Usuarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Proyecto";
            // 
            // textBoxProyecto
            // 
            this.textBoxProyecto.Location = new System.Drawing.Point(107, 19);
            this.textBoxProyecto.Name = "textBoxProyecto";
            this.textBoxProyecto.Size = new System.Drawing.Size(142, 20);
            this.textBoxProyecto.TabIndex = 3;
            // 
            // textBoxTarea
            // 
            this.textBoxTarea.Location = new System.Drawing.Point(107, 45);
            this.textBoxTarea.Name = "textBoxTarea";
            this.textBoxTarea.Size = new System.Drawing.Size(142, 20);
            this.textBoxTarea.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Agregar Tarea";
            // 
            // textBoxSubtarea
            // 
            this.textBoxSubtarea.Location = new System.Drawing.Point(341, 159);
            this.textBoxSubtarea.Name = "textBoxSubtarea";
            this.textBoxSubtarea.Size = new System.Drawing.Size(142, 20);
            this.textBoxSubtarea.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Agregar Subtarea";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tarea";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Subtarea";
            // 
            // buttonAgregarTarea
            // 
            this.buttonAgregarTarea.Location = new System.Drawing.Point(266, 43);
            this.buttonAgregarTarea.Name = "buttonAgregarTarea";
            this.buttonAgregarTarea.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarTarea.TabIndex = 12;
            this.buttonAgregarTarea.Text = "Agregar";
            this.buttonAgregarTarea.UseVisualStyleBackColor = true;
            this.buttonAgregarTarea.Click += new System.EventHandler(this.buttonAgregarTarea_Click);
            // 
            // buttonAgregarSubtarea
            // 
            this.buttonAgregarSubtarea.Location = new System.Drawing.Point(408, 185);
            this.buttonAgregarSubtarea.Name = "buttonAgregarSubtarea";
            this.buttonAgregarSubtarea.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarSubtarea.TabIndex = 13;
            this.buttonAgregarSubtarea.Text = "Agregar";
            this.buttonAgregarSubtarea.UseVisualStyleBackColor = true;
            this.buttonAgregarSubtarea.Click += new System.EventHandler(this.buttonAgregarSubtarea_Click);
            // 
            // listViewTareas
            // 
            this.listViewTareas.HideSelection = false;
            this.listViewTareas.Location = new System.Drawing.Point(15, 211);
            this.listViewTareas.Name = "listViewTareas";
            this.listViewTareas.Size = new System.Drawing.Size(200, 143);
            this.listViewTareas.TabIndex = 14;
            this.listViewTareas.UseCompatibleStateImageBehavior = false;
            // 
            // listViewSubtareas
            // 
            this.listViewSubtareas.HideSelection = false;
            this.listViewSubtareas.Location = new System.Drawing.Point(249, 211);
            this.listViewSubtareas.Name = "listViewSubtareas";
            this.listViewSubtareas.Size = new System.Drawing.Size(234, 143);
            this.listViewSubtareas.TabIndex = 15;
            this.listViewSubtareas.UseCompatibleStateImageBehavior = false;
            // 
            // dateTimePickerDataInici
            // 
            this.dateTimePickerDataInici.Location = new System.Drawing.Point(15, 119);
            this.dateTimePickerDataInici.Name = "dateTimePickerDataInici";
            this.dateTimePickerDataInici.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDataInici.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data Inicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Data fin";
            // 
            // dateTimePickerDataFin
            // 
            this.dateTimePickerDataFin.Location = new System.Drawing.Point(15, 162);
            this.dateTimePickerDataFin.Name = "dateTimePickerDataFin";
            this.dateTimePickerDataFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDataFin.TabIndex = 18;
            // 
            // buttonCrearProyecto
            // 
            this.buttonCrearProyecto.Location = new System.Drawing.Point(457, 384);
            this.buttonCrearProyecto.Name = "buttonCrearProyecto";
            this.buttonCrearProyecto.Size = new System.Drawing.Size(113, 37);
            this.buttonCrearProyecto.TabIndex = 20;
            this.buttonCrearProyecto.Text = "Crear Proyecto";
            this.buttonCrearProyecto.UseVisualStyleBackColor = true;
            this.buttonCrearProyecto.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxTareas
            // 
            this.comboBoxTareas.FormattingEnabled = true;
            this.comboBoxTareas.Location = new System.Drawing.Point(341, 132);
            this.comboBoxTareas.Name = "comboBoxTareas";
            this.comboBoxTareas.Size = new System.Drawing.Size(142, 21);
            this.comboBoxTareas.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(245, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Seleccionar Tarea";
            // 
            // buttonComfirmarSubtareas
            // 
            this.buttonComfirmarSubtareas.Location = new System.Drawing.Point(248, 360);
            this.buttonComfirmarSubtareas.Name = "buttonComfirmarSubtareas";
            this.buttonComfirmarSubtareas.Size = new System.Drawing.Size(75, 23);
            this.buttonComfirmarSubtareas.TabIndex = 23;
            this.buttonComfirmarSubtareas.Text = "Comfirmar";
            this.buttonComfirmarSubtareas.UseVisualStyleBackColor = true;
            this.buttonComfirmarSubtareas.Click += new System.EventHandler(this.buttonComfirmarSubtareas_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(576, 384);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(113, 37);
            this.buttonCancelar.TabIndex = 24;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 433);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonComfirmarSubtareas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxTareas);
            this.Controls.Add(this.buttonCrearProyecto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePickerDataFin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerDataInici);
            this.Controls.Add(this.listViewSubtareas);
            this.Controls.Add(this.listViewTareas);
            this.Controls.Add(this.buttonAgregarSubtarea);
            this.Controls.Add(this.buttonAgregarTarea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSubtarea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTarea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUsuarios);
            this.Name = "FormProyectos";
            this.Text = "FormProyectos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProyecto;
        private System.Windows.Forms.TextBox textBoxTarea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSubtarea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAgregarTarea;
        private System.Windows.Forms.Button buttonAgregarSubtarea;
        private System.Windows.Forms.ListView listViewTareas;
        private System.Windows.Forms.ListView listViewSubtareas;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInici;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFin;
        private System.Windows.Forms.Button buttonCrearProyecto;
        private System.Windows.Forms.ComboBox comboBoxTareas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonComfirmarSubtareas;
        private System.Windows.Forms.Button buttonCancelar;
    }
}