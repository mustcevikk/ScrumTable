namespace ScrumTable
{
    partial class frm_EklemeGoruntuleme
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
            this.cmb_Konumlandir = new System.Windows.Forms.ComboBox();
            this.datetp_Tarih = new System.Windows.Forms.DateTimePicker();
            this.btn_Ekle = new System.Windows.Forms.Button();
            this.cmb_KimTarafindan = new System.Windows.Forms.ComboBox();
            this.cmb_Etiket = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Aciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Baslik = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_Konumlandir
            // 
            this.cmb_Konumlandir.FormattingEnabled = true;
            this.cmb_Konumlandir.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Done"});
            this.cmb_Konumlandir.Location = new System.Drawing.Point(398, 170);
            this.cmb_Konumlandir.Name = "cmb_Konumlandir";
            this.cmb_Konumlandir.Size = new System.Drawing.Size(121, 21);
            this.cmb_Konumlandir.TabIndex = 23;
            // 
            // datetp_Tarih
            // 
            this.datetp_Tarih.Location = new System.Drawing.Point(319, 137);
            this.datetp_Tarih.Name = "datetp_Tarih";
            this.datetp_Tarih.Size = new System.Drawing.Size(200, 20);
            this.datetp_Tarih.TabIndex = 21;
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ekle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Ekle.Location = new System.Drawing.Point(239, 168);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_Ekle.TabIndex = 22;
            this.btn_Ekle.Text = "EKLE";
            this.btn_Ekle.UseVisualStyleBackColor = false;
            this.btn_Ekle.Click += new System.EventHandler(this.ButonaTiklama);
            // 
            // cmb_KimTarafindan
            // 
            this.cmb_KimTarafindan.FormattingEnabled = true;
            this.cmb_KimTarafindan.Items.AddRange(new object[] {
            "Emin BORANDAĞ",
            "Mustafa ÇEVİK",
            "Yalçın KABAR"});
            this.cmb_KimTarafindan.Location = new System.Drawing.Point(319, 88);
            this.cmb_KimTarafindan.Name = "cmb_KimTarafindan";
            this.cmb_KimTarafindan.Size = new System.Drawing.Size(200, 21);
            this.cmb_KimTarafindan.TabIndex = 20;
            // 
            // cmb_Etiket
            // 
            this.cmb_Etiket.FormattingEnabled = true;
            this.cmb_Etiket.Items.AddRange(new object[] {
            "Sarı",
            "Kırmızı",
            "Yeşil",
            "Mavi",
            "Beyaz",
            "Mor",
            "Turuncu",
            "Pembe"});
            this.cmb_Etiket.Location = new System.Drawing.Point(319, 40);
            this.cmb_Etiket.Name = "cmb_Etiket";
            this.cmb_Etiket.Size = new System.Drawing.Size(200, 21);
            this.cmb_Etiket.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Açıklama";
            // 
            // txt_Aciklama
            // 
            this.txt_Aciklama.Location = new System.Drawing.Point(25, 89);
            this.txt_Aciklama.Multiline = true;
            this.txt_Aciklama.Name = "txt_Aciklama";
            this.txt_Aciklama.Size = new System.Drawing.Size(272, 69);
            this.txt_Aciklama.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(316, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tarih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(316, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kim Tarafından";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(316, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Etiket";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Başlık";
            // 
            // txt_Baslik
            // 
            this.txt_Baslik.Location = new System.Drawing.Point(25, 41);
            this.txt_Baslik.Name = "txt_Baslik";
            this.txt_Baslik.Size = new System.Drawing.Size(272, 20);
            this.txt_Baslik.TabIndex = 12;
            // 
            // frm_EklemeGoruntuleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(560, 218);
            this.Controls.Add(this.cmb_Konumlandir);
            this.Controls.Add(this.datetp_Tarih);
            this.Controls.Add(this.btn_Ekle);
            this.Controls.Add(this.cmb_KimTarafindan);
            this.Controls.Add(this.cmb_Etiket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Aciklama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Baslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_EklemeGoruntuleme";
            this.Text = "EklemeGoruntuleme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker datetp_Tarih;
        private System.Windows.Forms.Button btn_Ekle;
        private System.Windows.Forms.ComboBox cmb_KimTarafindan;
        public System.Windows.Forms.ComboBox cmb_Etiket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Aciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Baslik;
        public System.Windows.Forms.ComboBox cmb_Konumlandir;
    }
}