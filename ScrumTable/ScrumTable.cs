using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ScrumTable
{
    public partial class frm_ScrumTable : Form
    {
        public frm_ScrumTable()
        {
            InitializeComponent();
        }

        List<Notlar> ana_notListesi = new List<Notlar>();
        StoryNotlari ana_storyNotu = new StoryNotlari();
        NotStartedNotlari ana_notStartednotu = new NotStartedNotlari();
        InProgressNotlari ana_inProgressnotu = new InProgressNotlari();
        DoneNotlari ana_doneNotu = new DoneNotlari();

        OleDbConnection veriBaglantisi = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\MustafaCevik\\Desktop\\Veriler.mdb");

        private void VerilerGoruntule()
        {
            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand();
            veriKomutu.Connection = veriBaglantisi;
            veriKomutu.CommandText = ("Select * from Veriler");
            OleDbDataReader veriOku = veriKomutu.ExecuteReader();
            while (veriOku.Read()) // veritabanından veri okuma işlemi
            {
                if (veriOku["hangiPanelde"].ToString() == "pnl_Stories") // story taskı ise
                {
                    string[] okunanVeriler = new string[8];
                    okunanVeriler[0] = veriOku["sira"].ToString();
                    okunanVeriler[1] = veriOku["hangiPanelde"].ToString();
                    okunanVeriler[2] = veriOku["tamAdi"].ToString();
                    okunanVeriler[3] = veriOku["baslik"].ToString();
                    okunanVeriler[4] = veriOku["aciklama"].ToString();
                    okunanVeriler[5] = veriOku["renk"].ToString();
                    okunanVeriler[6] = veriOku["kisi"].ToString();
                    okunanVeriler[7] = veriOku["tarih"].ToString();

                    StoryNotlari snot = Veriden_StoryNotuListeyeEkleme(okunanVeriler); // veritabanındaki storyyi listeye ekleme


                    OleDbCommand veriKomutu2 = new OleDbCommand();
                    veriKomutu2.Connection = veriBaglantisi;
                    veriKomutu2.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku2 = veriKomutu2.ExecuteReader();

                    while (veriOku2.Read())
                    {
                        if (veriOku2["hangiPanelde"].ToString() == "pnl_NotStarted" && veriOku2["sira"].ToString() == snot.sira.ToString()) // o storynin -> not started taskı ise
                        {
                            string[] okunanVeriler_NS = new string[8];
                            okunanVeriler_NS[0] = veriOku2["sira"].ToString();
                            okunanVeriler_NS[1] = veriOku2["hangiPanelde"].ToString();
                            okunanVeriler_NS[2] = veriOku2["tamAdi"].ToString();
                            okunanVeriler_NS[3] = veriOku2["baslik"].ToString();
                            okunanVeriler_NS[4] = veriOku2["aciklama"].ToString();
                            okunanVeriler_NS[5] = veriOku2["renk"].ToString();
                            okunanVeriler_NS[6] = veriOku2["kisi"].ToString();
                            okunanVeriler_NS[7] = veriOku2["tarih"].ToString();

                            Veriden_NotStartedNotuListeyeEkleme(okunanVeriler_NS, snot);
                        }
                    }

                    OleDbCommand veriKomutu3 = new OleDbCommand();
                    veriKomutu3.Connection = veriBaglantisi;
                    veriKomutu3.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku3 = veriKomutu3.ExecuteReader();

                    while (veriOku3.Read())
                    {
                        if (veriOku3["hangiPanelde"].ToString() == "pnl_InProgress" && veriOku3["sira"].ToString() == snot.sira.ToString()) // o storynin -> in progress taskı ise
                        {
                            string[] okunanVeriler_IP = new string[8];
                            okunanVeriler_IP[0] = veriOku3["sira"].ToString();
                            okunanVeriler_IP[1] = veriOku3["hangiPanelde"].ToString();
                            okunanVeriler_IP[2] = veriOku3["tamAdi"].ToString();
                            okunanVeriler_IP[3] = veriOku3["baslik"].ToString();
                            okunanVeriler_IP[4] = veriOku3["aciklama"].ToString();
                            okunanVeriler_IP[5] = veriOku3["renk"].ToString();
                            okunanVeriler_IP[6] = veriOku3["kisi"].ToString();
                            okunanVeriler_IP[7] = veriOku3["tarih"].ToString();

                            Veriden_InProgressNotuListeyeEkleme(okunanVeriler_IP, snot);
                        }
                    }

                    OleDbCommand veriKomutu4 = new OleDbCommand();
                    veriKomutu4.Connection = veriBaglantisi;
                    veriKomutu4.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku4 = veriKomutu4.ExecuteReader();


                    while (veriOku4.Read())
                    {
                        if (veriOku4["hangiPanelde"].ToString() == "pnl_Done" && veriOku4["sira"].ToString() == snot.sira.ToString()) // o storynin -> done taskı ise
                        {
                            string[] okunanVeriler_Dne = new string[8];
                            okunanVeriler_Dne[0] = veriOku4["sira"].ToString();
                            okunanVeriler_Dne[1] = veriOku4["hangiPanelde"].ToString();
                            okunanVeriler_Dne[2] = veriOku4["tamAdi"].ToString();
                            okunanVeriler_Dne[3] = veriOku4["baslik"].ToString();
                            okunanVeriler_Dne[4] = veriOku4["aciklama"].ToString();
                            okunanVeriler_Dne[5] = veriOku4["renk"].ToString();
                            okunanVeriler_Dne[6] = veriOku4["kisi"].ToString();
                            okunanVeriler_Dne[7] = veriOku4["tarih"].ToString();

                            Veriden_DoneNotuListeyeEkleme(okunanVeriler_Dne, snot);
                        }
                    }
                }
            }
            veriBaglantisi.Close();
        }



        private void lbl_AddStory_Click(object sender, EventArgs e)
        {

        }

        private StoryNotlari Veriden_StoryNotuListeyeEkleme(string[] okunanVeriler)
        {
            StoryNotlari storyNotu = new StoryNotlari
            {
                sira = Convert.ToInt32(okunanVeriler[0]),
                hangiPanelde = okunanVeriler[1],
                tamAdi = okunanVeriler[2],
                baslik = okunanVeriler[3],
                aciklama = okunanVeriler[4],
                renk = okunanVeriler[5],
                kisi = okunanVeriler[6],
                tarih = Convert.ToDateTime(okunanVeriler[7])
            };

            ana_notListesi.Add(storyNotu);

            return storyNotu;
        }

        private void Veriden_NotStartedNotuListeyeEkleme(string[] okunanVeriler, StoryNotlari storyNotu)
        {
            NotStartedNotlari notStartednotu = new NotStartedNotlari
            {
                sira = Convert.ToInt32(okunanVeriler[0]),
                hangiPanelde = okunanVeriler[1],
                tamAdi = okunanVeriler[2],
                baslik = okunanVeriler[3],
                aciklama = okunanVeriler[4],
                renk = okunanVeriler[5],
                kisi = okunanVeriler[6],
                tarih = Convert.ToDateTime(okunanVeriler[7])
            };

            storyNotu.NotStTaskEkle(notStartednotu);

        }

        private void Veriden_InProgressNotuListeyeEkleme(string[] okunanVeriler, StoryNotlari storyNotu)
        {
            InProgressNotlari inProgressNotu = new InProgressNotlari
            {
                sira = Convert.ToInt32(okunanVeriler[0]),
                hangiPanelde = okunanVeriler[1],
                tamAdi = okunanVeriler[2],
                baslik = okunanVeriler[3],
                aciklama = okunanVeriler[4],
                renk = okunanVeriler[5],
                kisi = okunanVeriler[6],
                tarih = Convert.ToDateTime(okunanVeriler[7])
            };

            storyNotu.InProTaskEkle(inProgressNotu);
        }

        private void Veriden_DoneNotuListeyeEkleme(string[] okunanVeriler, StoryNotlari storyNotu)
        {
            DoneNotlari doneNotu = new DoneNotlari
            {
                sira = Convert.ToInt32(okunanVeriler[0]),
                hangiPanelde = okunanVeriler[1],
                tamAdi = okunanVeriler[2],
                baslik = okunanVeriler[3],
                aciklama = okunanVeriler[4],
                renk = okunanVeriler[5],
                kisi = okunanVeriler[6],
                tarih = Convert.ToDateTime(okunanVeriler[7])
            };

            storyNotu.DoneTaskEkle(doneNotu);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            VerilerGoruntule();
            MessageBox.Show("Test");
        }
    }
}
