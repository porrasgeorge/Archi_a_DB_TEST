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
            this.btn_leer = new System.Windows.Forms.Button();
            this.txt_datos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_etiquetaCorrecta = new System.Windows.Forms.Label();
            this.lbl_formatoCorrecto = new System.Windows.Forms.Label();
            this.lbl_anho = new System.Windows.Forms.Label();
            this.lbl_mes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_dia = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_leer
            // 
            this.btn_leer.Location = new System.Drawing.Point(791, 26);
            this.btn_leer.Name = "btn_leer";
            this.btn_leer.Size = new System.Drawing.Size(144, 48);
            this.btn_leer.TabIndex = 0;
            this.btn_leer.Text = "Leer Archivo";
            this.btn_leer.UseVisualStyleBackColor = true;
            this.btn_leer.Click += new System.EventHandler(this.btn_leer_Click);
            // 
            // txt_datos
            // 
            this.txt_datos.Location = new System.Drawing.Point(202, 26);
            this.txt_datos.Multiline = true;
            this.txt_datos.Name = "txt_datos";
            this.txt_datos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_datos.Size = new System.Drawing.Size(535, 478);
            this.txt_datos.TabIndex = 1;
            this.txt_datos.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Etiqueta Correcta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Formato Correcto";
            // 
            // lbl_etiquetaCorrecta
            // 
            this.lbl_etiquetaCorrecta.AutoSize = true;
            this.lbl_etiquetaCorrecta.Location = new System.Drawing.Point(117, 26);
            this.lbl_etiquetaCorrecta.Name = "lbl_etiquetaCorrecta";
            this.lbl_etiquetaCorrecta.Size = new System.Drawing.Size(23, 13);
            this.lbl_etiquetaCorrecta.TabIndex = 4;
            this.lbl_etiquetaCorrecta.Text = "NO";
            // 
            // lbl_formatoCorrecto
            // 
            this.lbl_formatoCorrecto.AutoSize = true;
            this.lbl_formatoCorrecto.Location = new System.Drawing.Point(117, 44);
            this.lbl_formatoCorrecto.Name = "lbl_formatoCorrecto";
            this.lbl_formatoCorrecto.Size = new System.Drawing.Size(23, 13);
            this.lbl_formatoCorrecto.TabIndex = 5;
            this.lbl_formatoCorrecto.Text = "NO";
            // 
            // lbl_anho
            // 
            this.lbl_anho.AutoSize = true;
            this.lbl_anho.Location = new System.Drawing.Point(117, 88);
            this.lbl_anho.Name = "lbl_anho";
            this.lbl_anho.Size = new System.Drawing.Size(13, 13);
            this.lbl_anho.TabIndex = 9;
            this.lbl_anho.Text = "--";
            // 
            // lbl_mes
            // 
            this.lbl_mes.AutoSize = true;
            this.lbl_mes.Location = new System.Drawing.Point(117, 105);
            this.lbl_mes.Name = "lbl_mes";
            this.lbl_mes.Size = new System.Drawing.Size(13, 13);
            this.lbl_mes.TabIndex = 8;
            this.lbl_mes.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mes";
            // 
            // lbl_dia
            // 
            this.lbl_dia.AutoSize = true;
            this.lbl_dia.Location = new System.Drawing.Point(118, 128);
            this.lbl_dia.Name = "lbl_dia";
            this.lbl_dia.Size = new System.Drawing.Size(13, 13);
            this.lbl_dia.TabIndex = 11;
            this.lbl_dia.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 559);
            this.Controls.Add(this.lbl_dia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_anho);
            this.Controls.Add(this.lbl_mes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_formatoCorrecto);
            this.Controls.Add(this.lbl_etiquetaCorrecta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_datos);
            this.Controls.Add(this.btn_leer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_leer;
        private System.Windows.Forms.TextBox txt_datos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_etiquetaCorrecta;
        private System.Windows.Forms.Label lbl_formatoCorrecto;
        private System.Windows.Forms.Label lbl_anho;
        private System.Windows.Forms.Label lbl_mes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_dia;
        private System.Windows.Forms.Label label4;
    }
}

