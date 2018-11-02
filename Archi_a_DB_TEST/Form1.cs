﻿using System;
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

        public Form1()
        {
            InitializeComponent();
            listaRayos = new List<LightningStrike>();
            pb_completado.Visible = false;
        }

        private void btn_leer_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            string log = "";
            int counter = 0;
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
            if (ArchivoCorrectoBool)
            {
                string connetionString = null;
                SqlConnection cnn;
                connetionString = "Data Source=192.168.4.2;Initial Catalog=LightningStrikes;User ID=jorge;Password=ERR100189";
                cnn = new SqlConnection(connetionString);
                pb_completado.Maximum = listaRayos.Count;
                pb_completado.Step = 1;
                pb_completado.Value = 0;
                pb_completado.Visible = true;
                int i = 0;

                try
                {
                    cnn.Open();
                    foreach (LightningStrike lightning in listaRayos)
                    {
                        i++;
                        SqlCommand cmd = new SqlCommand("InsertLightning", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fechaHora", lightning.FechaHora);
                        cmd.Parameters.AddWithValue("@latitud", lightning.latitud);
                        cmd.Parameters.AddWithValue("@longitud", lightning.longitud);
                        cmd.ExecuteNonQuery();

                        pb_completado.Value = i;
                    
                    }
                    cnn.Close();
                    pb_completado.Visible = false;
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
        }


    }
}
