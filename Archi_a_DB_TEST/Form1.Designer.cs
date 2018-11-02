namespace Archi_a_DB_TEST
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_leer = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_etiquetaCorrecta = new System.Windows.Forms.Label();
            this.lbl_fechaArchivo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.pb_completado = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_leer
            // 
            this.btn_leer.Location = new System.Drawing.Point(25, 26);
            this.btn_leer.Name = "btn_leer";
            this.btn_leer.Size = new System.Drawing.Size(100, 24);
            this.btn_leer.TabIndex = 0;
            this.btn_leer.Text = "Leer Archivo";
            this.btn_leer.UseVisualStyleBackColor = true;
            this.btn_leer.Click += new System.EventHandler(this.btn_leer_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(25, 79);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(217, 220);
            this.txt_log.TabIndex = 1;
            this.txt_log.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Etiqueta Correcta";
            // 
            // lbl_etiquetaCorrecta
            // 
            this.lbl_etiquetaCorrecta.AutoSize = true;
            this.lbl_etiquetaCorrecta.Location = new System.Drawing.Point(117, 9);
            this.lbl_etiquetaCorrecta.Name = "lbl_etiquetaCorrecta";
            this.lbl_etiquetaCorrecta.Size = new System.Drawing.Size(23, 13);
            this.lbl_etiquetaCorrecta.TabIndex = 4;
            this.lbl_etiquetaCorrecta.Text = "NO";
            // 
            // lbl_fechaArchivo
            // 
            this.lbl_fechaArchivo.AutoSize = true;
            this.lbl_fechaArchivo.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fechaArchivo.ForeColor = System.Drawing.Color.Red;
            this.lbl_fechaArchivo.Location = new System.Drawing.Point(148, 3);
            this.lbl_fechaArchivo.Name = "lbl_fechaArchivo";
            this.lbl_fechaArchivo.Size = new System.Drawing.Size(22, 21);
            this.lbl_fechaArchivo.TabIndex = 9;
            this.lbl_fechaArchivo.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Log";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(142, 26);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(100, 24);
            this.btn_connect.TabIndex = 13;
            this.btn_connect.Text = "Guardar en BD";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // pb_completado
            // 
            this.pb_completado.Location = new System.Drawing.Point(35, 173);
            this.pb_completado.Name = "pb_completado";
            this.pb_completado.Size = new System.Drawing.Size(197, 23);
            this.pb_completado.TabIndex = 14;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 311);
            this.Controls.Add(this.pb_completado);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_fechaArchivo);
            this.Controls.Add(this.lbl_etiquetaCorrecta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_leer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Archivo a BD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_leer;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_etiquetaCorrecta;
        private System.Windows.Forms.Label lbl_fechaArchivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ProgressBar pb_completado;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

