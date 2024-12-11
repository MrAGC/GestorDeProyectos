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
        private string rutaArchivo;
        private bool archivoEncriptado;

        public FormVerJson()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += FormProyectos_FormClosing;
        }

        private void FormProyectos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
                rutaArchivo = openFileDialog.FileName;
                string contenidoArchivo = File.ReadAllText(rutaArchivo);
                string contenidoJson;

                try
                {
                    contenidoJson = DesencriptarJson(contenidoArchivo);
                    archivoEncriptado = true;
                }
                catch
                {
                    contenidoJson = contenidoArchivo; // Si falla la desencriptación, asumimos que no está encriptado
                    archivoEncriptado = false;
                }

                // Verificar si el contenido JSON es un array o un objeto
                JToken jsonToken = JToken.Parse(contenidoJson);
                if (jsonToken is JArray)
                {
                    var jsonArray = (JArray)jsonToken;
                    var flattenedJson = jsonArray.Select(obj => FlattenJson(obj)).ToList();
                    var dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(flattenedJson));
                    dataGridViewVerJson.DataSource = dataTable;
                }
                else if (jsonToken is JObject)
                {
                    var jsonObject = (JObject)jsonToken;
                    var flattenedJson = FlattenJson(jsonObject);
                    var jsonArray = new JArray { flattenedJson };
                    var dataTable = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                    dataGridViewVerJson.DataSource = dataTable;
                }
                dataGridViewVerJson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private JObject FlattenJson(JToken jsonToken)
        {
            var result = new JObject();

            foreach (var property in jsonToken.Children<JProperty>())
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

                    byte[] iv = aesAlg.IV;
                    byte[] encrypted = msEncrypt.ToArray();

                    byte[] result = new byte[iv.Length + encrypted.Length];
                    Array.Copy(iv, 0, result, 0, iv.Length);
                    Array.Copy(encrypted, 0, result, iv.Length, encrypted.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        private void buttonEliminarFila_Click(object sender, EventArgs e)
        {
            if (dataGridViewVerJson.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewVerJson.SelectedRows)
                {
                    dataGridViewVerJson.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridViewVerJson.DataSource;
            string json = JsonConvert.SerializeObject(dataTable);

            if (archivoEncriptado)
            {
                json = EncriptarJson(json);
            }

            File.WriteAllText(rutaArchivo, json);

            this.Hide();
            Form1 nuevoForm = new Form1();
            nuevoForm.ShowDialog();
        }
    }
}
