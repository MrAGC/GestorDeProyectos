namespace GestorDeProyectos
{
    partial class FormVerJson
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
            this.dataGridViewVerJson = new System.Windows.Forms.DataGridView();
            this.buttonSeleccionarJson = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonEliminarFila = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerJson)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVerJson
            // 
            this.dataGridViewVerJson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVerJson.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewVerJson.Name = "dataGridViewVerJson";
            this.dataGridViewVerJson.Size = new System.Drawing.Size(1055, 368);
            this.dataGridViewVerJson.TabIndex = 0;
            // 
            // buttonSeleccionarJson
            // 
            this.buttonSeleccionarJson.Location = new System.Drawing.Point(312, 386);
            this.buttonSeleccionarJson.Name = "buttonSeleccionarJson";
            this.buttonSeleccionarJson.Size = new System.Drawing.Size(145, 23);
            this.buttonSeleccionarJson.TabIndex = 1;
            this.buttonSeleccionarJson.Text = "Seleccionar Json";
            this.buttonSeleccionarJson.UseVisualStyleBackColor = true;
            this.buttonSeleccionarJson.Click += new System.EventHandler(this.buttonSeleccionarJson_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(614, 386);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(145, 23);
            this.buttonSalir.TabIndex = 2;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // buttonEliminarFila
            // 
            this.buttonEliminarFila.Location = new System.Drawing.Point(463, 386);
            this.buttonEliminarFila.Name = "buttonEliminarFila";
            this.buttonEliminarFila.Size = new System.Drawing.Size(145, 23);
            this.buttonEliminarFila.TabIndex = 3;
            this.buttonEliminarFila.Text = "Eliminar Fila";
            this.buttonEliminarFila.UseVisualStyleBackColor = true;
            this.buttonEliminarFila.Click += new System.EventHandler(this.buttonEliminarFila_Click);
            // 
            // FormVerJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.buttonEliminarFila);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonSeleccionarJson);
            this.Controls.Add(this.dataGridViewVerJson);
            this.Name = "FormVerJson";
            this.Text = "FormVerJson";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerJson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVerJson;
        private System.Windows.Forms.Button buttonSeleccionarJson;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonEliminarFila;
    }
}