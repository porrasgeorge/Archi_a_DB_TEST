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

namespace Archi_a_DB_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_leer_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                   using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        
                    }

                    string[] array = fileContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    int counter = 0;
                    foreach (String item in array)
                    { 
                        if (counter != 0)
                        {
                            string[] partes = item.Split(",".ToCharArray());
                            foreach(string data in partes)
                            {
                                //txt_datos.Text = data + "\r\n";
                                //Console.WriteLine(data);
                            }
                        }
                        else
                        {
                            string[] partes = item.Split(",".ToCharArray());

                            if (partes[0] == "LIGHTNING-Conelec24hr")
                                lbl_etiquetaCorrecta.Text = "SI";
                            else
                                lbl_etiquetaCorrecta.Text = "NO";

                            string[] fecha = item.Split("_".ToCharArray());

                        }

                        counter++;
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }


    }
}
