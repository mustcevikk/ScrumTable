using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class frm_EklemeGoruntuleme : Form
    {
        public frm_EklemeGoruntuleme()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            btn_Sil.Hide();
        }

        public string baslik;
        public string aciklama;
        public string etiket;
        public string kimTarafindan;
        public DateTime tarih;
        public string hangiPanele;

        public bool eklensinMi;
        private void EkleButonunaTiklama(object sender, EventArgs e)
        {
            baslik = txt_Baslik.Text;
            aciklama = txt_Aciklama.Text;
            etiket = RenkAtamasi(cmb_Etiket.Text);
            kimTarafindan = cmb_KimTarafindan.Text;
            tarih = datetp_Tarih.Value;
            hangiPanele = cmb_Konumlandir.Text;
            eklensinMi = true;
            Close();
        }

        public bool silinsinMi;
        private void SilButonunaTiklama(object sender, EventArgs e)
        {
            silinsinMi = true;
            Close();
        }

        public void StoryGoruntuleme(string story, string baslik, string aciklama, string kisi, string tarih, string konum)
        {
            Text = "Story Görüntüleme Ekranı";
            txt_Baslik.Enabled = false;
            btn_Ekle.Text = "KAYDET";
            txt_Baslik.Text = baslik;
            txt_Aciklama.Text = aciklama;
            cmb_Etiket.Enabled = false;
            datetp_Tarih.Text = tarih;
            cmb_KimTarafindan.Text = kisi;
            cmb_Konumlandir.Text = konum;
            ShowDialog();
        }

        public void TaskGoruntuleme(string baslik, string aciklama, string kisi, string tarih, string konum)
        {
            Text = "Task Görüntüleme Ekranı";
            Size = new Size(575, 260);
            btn_Sil.Show();
            txt_Baslik.Enabled = false;
            btn_Ekle.Text = "KAYDET";
            txt_Baslik.Text = baslik;
            txt_Aciklama.Text = aciklama;
            cmb_Etiket.Enabled = false;
            datetp_Tarih.Text = tarih;
            cmb_KimTarafindan.Text = kisi;
            cmb_Konumlandir.Text = konum;
            ShowDialog();
        }
        private string RenkAtamasi(string etiketTexti)
        {
            switch (etiketTexti)
            {
                case "Sarı":
                    return "Yellow";

                case "Kırmızı":
                    return "Red";

                case "Yeşil":
                    return "LightGreen";

                case "Mavi":
                    return "LightSkyBlue";

                case "Beyaz":
                    return "White";

                case "Mor":
                    return "DarkOrchid";

                case "Turuncu":
                    return "DarkOrange";

                case "Pembe":
                    return "HotPink";

                default:
                    return "";
            }
        }

    }
}
