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
        }

        public string baslik;
        public string aciklama;
        public string etiket;
        public string kimTarafindan;
        public DateTime tarih;
        public string hangiPanele;

        public bool butonaTiklandimi;
        private void ButonaTiklama(object sender, EventArgs e)
        {
            baslik = txt_Baslik.Text;
            aciklama = txt_Aciklama.Text;
            etiket = RenkAtamasi(cmb_Etiket.Text);
            kimTarafindan = cmb_KimTarafindan.Text;
            tarih = datetp_Tarih.Value;
            hangiPanele = cmb_Konumlandir.Text;
            butonaTiklandimi = true;
            Close();
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

        public void FormGoruntuleme(string baslik, string aciklama, string tarih, string kisi, string konum)
        {
            btn_Ekle.Text = "Kaydet";
            txt_Baslik.Text = baslik;
            txt_Aciklama.Text = aciklama;
            cmb_Etiket.Enabled = false;
            datetp_Tarih.Text = tarih;
            cmb_KimTarafindan.Text = kisi;
            cmb_Konumlandir.Text = konum;
            ShowDialog();
        }
    }
}
