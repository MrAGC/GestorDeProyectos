using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GestorDeProyectos
{
    public partial class FormVerJson : Form
    {
        private static readonly string ClaveEncriptacion = "0123456789012345"; // Clave de 16 caracteres para AES
        private static readonly byte[] IVPersonalizado = Encoding.UTF8.GetBytes("5432109876543210"); // IV invertido (16 bytes)

        public FormVerJson()
        {
            InitializeComponent();
        }

        private void buttonSeleccionarJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Seleccionar archivo JSON"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                string contenidoArchivo = File.ReadAllText(rutaArchivo);
                string contenidoJson;

                try
                {
                    contenidoJson = DesencriptarJson(contenidoArchivo);
                }
                catch
                {
                    contenidoJson = contenidoArchivo; // Si falla la desencriptación, asumimos que no está encriptado
                }

                // Convert JSON object to array format
                var jsonObject = JsonConvert.DeserializeObject<JObject>(contenidoJson);
                var flattenedJson = FlattenJson(jsonObject);
                var jsonArray = new JArray { flattenedJson };

                var dataTable = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                dataGridViewVerJson.DataSource = dataTable;
                dataGridViewVerJson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private JObject FlattenJson(JObject jsonObject)
        {
            var result = new JObject();

            foreach (var property in jsonObject.Properties())
            {
                if (property.Value is JObject nestedObject)
                {
                    foreach (var nestedProperty in nestedObject.Properties())
                    {
                        result.Add($"{property.Name}_{nestedProperty.Name}", nestedProperty.Value);
                    }
                }
                else
                {
                    result.Add(property.Name, property.Value);
                }
            }

            return result;
        }




        private string DesencriptarJson(string jsonEncriptado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ClaveEncriptacion);
                aesAlg.IV = IVPersonalizado;

                byte[] datosEncriptados = Convert.FromBase64String(jsonEncriptado);

                byte[] iv = new byte[16];
                Array.Copy(datosEncriptados, 0, iv, 0, iv.Length);

                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(datosEncriptados, 16, datosEncriptados.Length - 16))
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 nuevoForm = new Form1();
            nuevoForm.ShowDialog();
        }
    }
}
