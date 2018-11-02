using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Boolean etiquetaCorrectaBool;
        public Boolean formatoCorrectoBool;
        public Boolean ArchivoCorrectoBool;
        List<LightningStrike> listaRayos;
        int NumFilas = 0;

        // private FormEjecutando childForm;

        public Form1()
        {
            InitializeComponent();
            listaRayos = new List<LightningStrike>();
            pb_completado.Visible = false;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            //pb_completado.Maximum = listaRayos.Count;
            pb_completado.Step = 1;
            pb_completado.Value = 0;
            pb_completado.Visible = false;
        }

        private void btn_leer_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            string log = "";
            int counter = 0;
            NumFilas = 0;


            listaRayos.Clear();


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    formatoCorrectoBool = true;
                    ArchivoCorrectoBool = false;

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        
                    }

                    if (!string.IsNullOrEmpty(fileContent))
                    {
                        string[] lineasArchivo = fileContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        counter = 0;
                        

                        foreach (String linea in lineasArchivo)
                        { 
                            if (counter != 0)
                            {
                                if (!string.IsNullOrEmpty(linea))
                                {
                                    string[] columnas = linea.Split(",".ToCharArray());

                                    DateTime Fecha;
                                    double latitud = 0.0;
                                    double longitud = 0.0;

                                    bool Fecha_Ok = DateTime.TryParse(columnas[0], out Fecha);
                                    bool latitud_OK = Double.TryParse(columnas[1], out latitud);
                                    bool longitud_OK = Double.TryParse(columnas[2], out longitud);

                                    if (latitud_OK && longitud_OK && Fecha_Ok)
                                    {
                                        //log += "Linea " + Convert.ToString(counter + 1) + " OK";
                                        Fecha = Fecha.AddHours(-6);
                                        if (latitud < 9 || latitud > 12)
                                        {
                                            log += Convert.ToString(counter + 1) + " Lat no CR\r\n";
                                        }
                                        else if (longitud < -86 || longitud > -82)
                                        {
                                            log += Convert.ToString(counter + 1) + ", Long no CR\r\n";
                                        }
                                        else
                                        {
                                            LightningStrike rayo = new LightningStrike(Fecha,latitud,longitud);
                                            listaRayos.Add(rayo);
                                        }

                                    }
                                    else
                                    {
                                        log += Convert.ToString(counter +1) + " ERRONEA\r\n";
                                        formatoCorrectoBool = false;
                                    }

                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(linea))
                                {
                                    string[] columnas = linea.Split(",".ToCharArray());

                                    if (columnas[0] == "LIGHTNING-Conelec24hr")
                                    {
                                        //log += "Linea " + Convert.ToString(counter + 1) + " OK\r\n";
                                        lbl_etiquetaCorrecta.Text = "SI";
                                        ArchivoCorrectoBool = true;
                                    }
                                        
                                    else
                                    {
                                        log += "Linea " + Convert.ToString(counter + 1) + " ERRONEA\r\n";
                                        lbl_etiquetaCorrecta.Text = "NO";
                                        ArchivoCorrectoBool = false;
                                    }
                                        

                                    if (!string.IsNullOrEmpty(columnas[1]))
                                    {
                                        string[] fecha_txt = columnas[1].Split("_".ToCharArray());
                                        lbl_fechaArchivo.Text = fecha_txt[2] + "/"+fecha_txt[1] + "/"+fecha_txt[0];
                                    }
                                }
                            }

                            counter++;
                        }

                        NumFilas = listaRayos.Count -1;


                    }
                }

                if (formatoCorrectoBool)
                {
                    log += "\r\nFormato Correcto\r\n";
                    log += Convert.ToString(listaRayos.Count) + " lineas Correctas\r\n";
                    log += Convert.ToString(counter - listaRayos.Count -1) + " lineas Incorrectas\r\n";


                }

                //////////////
            }

            txt_log.Text = log;

        }



        public DateTime StringToDate(string fecha)
        {
            DateTime dt_fecha;
            bool convertida = DateTime.TryParse(fecha, out dt_fecha);
            if (!convertida)
            {
                dt_fecha = DateTime.Parse("2010-01-01"); //Error de conversion
            }
            return dt_fecha;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            pb_completado.Visible = true;
            btn_connect.Enabled = false;
            btn_leer.Enabled = false;



            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int j = 0;

            if (ArchivoCorrectoBool)
                    {
                        string connetionString = null;
                        SqlConnection cnn;
                        connetionString = "Data Source=192.168.4.2;Initial Catalog=LightningStrikes;User ID=jorge;Password=ERR100189";
                        cnn = new SqlConnection(connetionString);
                        try
                        {
                            cnn.Open();
                            foreach (LightningStrike lightning in listaRayos)
                            {
                                j++;
                                SqlCommand cmd = new SqlCommand("InsertLightning", cnn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@fechaHora", lightning.FechaHora);
                                cmd.Parameters.AddWithValue("@latitud", lightning.latitud);
                                cmd.Parameters.AddWithValue("@longitud", lightning.longitud);
                                cmd.ExecuteNonQuery();

                                backgroundWorker1.ReportProgress( j * 100 / NumFilas);

                            }
                            cnn.Close();
                            
                            MessageBox.Show("Archivo Cargado Correctamente", "Cargado");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not open connection ! \r\n" + ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Archivo Incorrecto", "Error");
                    }


                    System.Threading.Thread.Sleep(500);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb_completado.Value = e.ProgressPercentage;
            //label3.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label3.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label3.Text = "Error: " + e.Error.Message;
            }
            else
            {
                pb_completado.Visible = false;
                btn_connect.Enabled = true;
                btn_leer.Enabled = true;
            }
        }
    }
}
