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
        StoryNotlari bu_storyNotu = new StoryNotlari();



        //NotStartedNotlari ana_notStartednotu = new NotStartedNotlari();
        //InProgressNotlari ana_inProgressnotu = new InProgressNotlari();
        //DoneNotlari ana_doneNotu = new DoneNotlari();

        OleDbConnection veriBaglantisi = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\MustafaCevik\\source\\repos\\_VeriTabanlari\\Veriler.mdb");

        int storySirasi;
        private void Veriden_UygunListelereEkleme()
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
                storySirasi++;
            }
            veriBaglantisi.Close();
        }

        private void ListedekiNotlariPaneleAktarma()
        {
            foreach (StoryNotlari not_Sto in ana_notListesi)
            {
                Listeden_PaneleStoryEkleme(not_Sto);
                foreach (NotStartedNotlari not_NS in not_Sto.NotStTaskListesi )
                {
                    Listeden_PaneleTaskEkleme(not_NS, pnl_NotStarted);
                }

                foreach (InProgressNotlari not_IP in not_Sto.InProTaskListesi)
                {
                    Listeden_PaneleTaskEkleme(not_IP, pnl_InProgress);
                }

                foreach(DoneNotlari not_Dne in not_Sto.DoneTaskListesi)
                {
                    Listeden_PaneleTaskEkleme(not_Dne, pnl_Done);
                }
            }
        }

        private void Listeden_PaneleTaskEkleme(Notlar not, Panel nereyeEklenecek)
        {
            Label eklenecekTask = new Label();

            if (nereyeEklenecek == pnl_NotStarted)
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaciNotS[not.sira] * 45));
                eklenenTaskSayaciNotS[not.sira]++;
            }
            else if (nereyeEklenecek == pnl_InProgress)
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaciInP[not.sira] * 45));
                eklenenTaskSayaciInP[not.sira]++;
            }
            else
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaciDne[not.sira] * 45));
                eklenenTaskSayaciDne[not.sira]++;
            }

            eklenecekTask.Size = new Size(180, 40);
            eklenecekTask.FlatStyle = FlatStyle.Flat;
            eklenecekTask.TextAlign = ContentAlignment.MiddleCenter;
            eklenecekTask.Text = not.baslik;

            LabelRenginiBelirleme(eklenecekTask, not.renk);

            nereyeEklenecek.Controls.Add(eklenecekTask);

            eklenecekTask.MouseClick += LabeleTiklama;
        }
        private void Listeden_PaneleStoryEkleme(Notlar not)
        {
            Label storyLabeli = new Label();

            storyLabeli.Location = new Point(0, (eklenenTaskSayaciSto * 205));
            eklenenTaskSayaciSto++;

            storyLabeli.Size = new Size(180, 180);
            storyLabeli.FlatStyle = FlatStyle.Flat;
            storyLabeli.TextAlign = ContentAlignment.MiddleCenter;
            storyLabeli.Text = not.baslik;
            pnl_Stories.Controls.Add(storyLabeli);

            LabelRenginiBelirleme(storyLabeli, not.renk);

            storyLabeli.MouseClick += LabeleTiklama;

            Label addTaskLabeli = LabeleAddTaskLabeliEkleme(storyLabeli);

            addTaskLabeli.MouseClick += AddTaskLabelineTiklama;
        }

        private void LabeleTiklama(object sender, MouseEventArgs e)
        {
            MessageBox.Show("st");
        }

        private void AddStoryLabelineTiklama(object sender, EventArgs e)
        {
            frm_EklemeGoruntuleme storyEklemeformu = new frm_EklemeGoruntuleme();
            storyEklemeformu.cmb_Konumlandir.Hide();
            storyEklemeformu.ShowDialog();

            if (storyEklemeformu.butonaTiklandimi)
            {
                Klavyeden_StoryNotuListeyeEkleme(storyEklemeformu);

                SiralamaIcinGerekliIslemler();
           
                ListedekiNotlariPaneleAktarma();
            }
        }

        private void AddTaskLabelineTiklama(object sender, MouseEventArgs e)
        {
            Label tiklananLabel = (Label)sender;

            bu_storyNotu = HangiStoryninNotu(tiklananLabel);

            frm_EklemeGoruntuleme taskEklemeformu = new frm_EklemeGoruntuleme();
            taskEklemeformu.cmb_Etiket.Enabled = false;
            taskEklemeformu.cmb_Konumlandir.Hide();
            taskEklemeformu.ShowDialog();

            if (taskEklemeformu.butonaTiklandimi)
            {
                Klavyeden_NotStartedNotuListeyeEkleme(taskEklemeformu, bu_storyNotu);

                SiralamaIcinGerekliIslemler();

                ListedekiNotlariPaneleAktarma();
                   
            }
        }



        private void Klavyeden_StoryNotuListeyeEkleme(frm_EklemeGoruntuleme storyFormu)
        {
            int kacinciSiraya = VeridekiEnBuyukSayiyiBul();

            StoryNotlari storyNotu = new StoryNotlari
            {
                sira = kacinciSiraya + 1,
                hangiPanelde = pnl_Stories.Name,
                tamAdi = storyFormu.etiket + storyFormu.baslik,
                baslik = storyFormu.baslik,
                aciklama = storyFormu.aciklama,
                renk = storyFormu.etiket,
                kisi = storyFormu.kimTarafindan,
                tarih = storyFormu.tarih,
            };

            ana_notListesi.Add(storyNotu);
        }

        private void Klavyeden_NotStartedNotuListeyeEkleme(frm_EklemeGoruntuleme taskFormu, StoryNotlari snot)
        {
            foreach (StoryNotlari not_Sto in ana_notListesi)
            {
                if (not_Sto == snot)
                {

                    NotStartedNotlari notStartednotu = new NotStartedNotlari
                    {
                        sira = snot.sira,
                        hangiPanelde = pnl_NotStarted.Name,
                        tamAdi = snot.renk + taskFormu.baslik,
                        baslik = taskFormu.baslik,
                        aciklama = taskFormu.aciklama,
                        renk = snot.renk,
                        kisi = taskFormu.kimTarafindan,
                        tarih = taskFormu.tarih,
                    };

                    snot.NotStTaskListesi.Add(notStartednotu);

                    veriBaglantisi.Open();
                    OleDbCommand veriKomutu = new OleDbCommand("insert into Veriler (sira,hangiPanelde,tamAdi,baslik,aciklama,renk,kisi,tarih) values ('" + notStartednotu.sira + "','" + notStartednotu.hangiPanelde + "','" + notStartednotu.tamAdi + "','" + notStartednotu.baslik + "','" + notStartednotu.aciklama + "','" + notStartednotu.renk + "' , '" + notStartednotu.kisi + "' , '" + notStartednotu.tarih.ToShortDateString() + "')", veriBaglantisi);
                    veriKomutu.ExecuteNonQuery();
                    veriBaglantisi.Close();

                    break;
                }
            }
        }

        int eklenenTaskSayaciSto;
        private Label PaneleStoryEkleme(frm_EklemeGoruntuleme storyFormu)
        {
            Label storyLabeli = new Label();

            storyLabeli.Location = new Point(0, (eklenenTaskSayaciSto * 205));
            eklenenTaskSayaciSto++;

            storyLabeli.Size = new Size(180, 180);
            storyLabeli.FlatStyle = FlatStyle.Flat;
            storyLabeli.TextAlign = ContentAlignment.MiddleCenter;
            storyLabeli.Text = storyFormu.baslik;
            pnl_Stories.Controls.Add(storyLabeli);

            LabelRenginiBelirleme(storyLabeli, storyFormu.etiket);

            return storyLabeli;
        }


        private Label LabeleAddTaskLabeliEkleme(Label nereyeEklenecek)
        {
            Label addTasklabeli = new Label();

            addTasklabeli.Location = new Point(100, 155);
            addTasklabeli.Size = new Size(80, 25);
            addTasklabeli.FlatStyle = FlatStyle.Flat;
            addTasklabeli.TextAlign = ContentAlignment.BottomRight;
            addTasklabeli.Text = "+ add task";
            nereyeEklenecek.Controls.Add(addTasklabeli);

            return addTasklabeli;
        }

        

        int[] eklenenTaskSayaciNotS = new int[5];
        int[] eklenenTaskSayaciInP = new int[5];
        int[] eklenenTaskSayaciDne = new int[5];
        private Label PaneleTaskEkleme(int yerlestirme, frm_EklemeGoruntuleme taskFormu, Panel nereyeEklenecek)
        {
            Label eklenecekTask = new Label();

            if (nereyeEklenecek == pnl_NotStarted)
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaciNotS[yerlestirme] * 45));
                eklenenTaskSayaciNotS[yerlestirme]++;
            }
            else if (nereyeEklenecek == pnl_InProgress)
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaciInP[yerlestirme] * 45));
                eklenenTaskSayaciInP[yerlestirme]++;
            }
            else
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaciDne[yerlestirme] * 45));
                eklenenTaskSayaciDne[yerlestirme]++;
            }

            eklenecekTask.Size = new Size(180, 40);
            eklenecekTask.FlatStyle = FlatStyle.Flat;
            eklenecekTask.TextAlign = ContentAlignment.MiddleCenter;
            eklenecekTask.Text = taskFormu.baslik;
            nereyeEklenecek.Controls.Add(eklenecekTask);

            return eklenecekTask;
        }



        public void LabelRenginiBelirleme(Label label, string etiket)
        {
            switch (etiket)
            {
                case "Yellow":
                    label.BackColor = Color.Yellow;
                    break;

                case "Red":
                    label.BackColor = Color.Red;
                    break;

                case "LightGreen":
                    label.BackColor = Color.LightGreen;
                    break;

                case "LightSkyBlue":
                    label.BackColor = Color.LightSkyBlue;
                    break;

                case "White":
                    label.BackColor = Color.White;
                    break;

                case "DarkOrchid":
                    label.BackColor = Color.DarkOrchid;
                    break;

                case "DarkOrange":
                    label.BackColor = Color.DarkOrange;
                    break;

                default:
                    label.BackColor = Color.HotPink;
                    break;
            }
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
        }  // veritabanından okunanları uygun listelere ekleme metotları
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

        private int VeridekiEnBuyukSayiyiBul()
        {
            int sayi = 0;

            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand();
            veriKomutu.Connection = veriBaglantisi;
            veriKomutu.CommandText = ("Select * from Veriler");
            OleDbDataReader veriOku = veriKomutu.ExecuteReader();
            while (veriOku.Read()) // veritabanından veri okuma işlemi
            {
                sayi = Convert.ToInt32(veriOku["sira"]);

                while (veriOku.Read())
                {
                    if (Convert.ToInt32(veriOku["sira"]) > sayi)
                        sayi = Convert.ToInt32(veriOku["sira"]);
                }
            }
            veriBaglantisi.Close();
            return sayi;
        }

        private void SiralamaIcinGerekliIslemler()
        {
            pnl_Stories.Controls.Clear();
            pnl_NotStarted.Controls.Clear();
            pnl_InProgress.Controls.Clear();
            pnl_Done.Controls.Clear();
            eklenenTaskSayaciSto = 0;
            for (int i = 0; i < 5; i++)
            {
                eklenenTaskSayaciNotS[i] = 0;
                eklenenTaskSayaciInP[i] = 0;
                eklenenTaskSayaciDne[i] = 0;
            }
        }

        private StoryNotlari HangiStoryninNotu(Label tiklananLabel)
        {
            string tiklananLabelrengi = tiklananLabel.BackColor.Name;
            foreach (StoryNotlari snot in ana_notListesi)
            {
                if (snot.renk == tiklananLabelrengi)
                {
                    bu_storyNotu = snot;
                }
            }

            return bu_storyNotu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veriden_UygunListelereEkleme();
            VeridekiEnBuyukSayiyiBul();
            ListedekiNotlariPaneleAktarma();
            MessageBox.Show("Test");
        }
    }
}
