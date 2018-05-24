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
            StartPosition = FormStartPosition.CenterScreen;
            Veriden_UygunListelereEkleme();
            ListedekiNotlariPaneleAktarma(); // veritabanındaki notların yüklenmesi
        }

        List<Notlar> ana_notListesi = new List<Notlar>();
        StoryNotlari ana_storyNotu = new StoryNotlari(); // ana liste tanımlamaları

        OleDbConnection veriBaglantisi = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\MustafaCevik\\source\\repos\\_VeriTabanlari\\Veriler.mdb");
        OleDbCommand ana_veriKomutu = new OleDbCommand(); // veritabanı ilişkilendirmeleri


        //veritabanı işlemleri
        int eklenecekStorysirasi;
        private void Veriden_UygunListelereEkleme()
        {
            veriBaglantisi.Open();
            OleDbCommand veriKomutu_Sto = new OleDbCommand();
            veriKomutu_Sto.Connection = veriBaglantisi;
            veriKomutu_Sto.CommandText = ("Select * from Veriler");
            OleDbDataReader veriOku_Sto = veriKomutu_Sto.ExecuteReader();
            while (veriOku_Sto.Read()) // veritabanından veri okuma işlemi
            {
                if (veriOku_Sto["hangiPanelde"].ToString() == "Stories") // story taskı ise
                {
                    string[] okunanVeriler_Sto = new string[8];
                    okunanVeriler_Sto[0] = veriOku_Sto["sira"].ToString();
                    okunanVeriler_Sto[1] = veriOku_Sto["hangiPanelde"].ToString();
                    okunanVeriler_Sto[2] = veriOku_Sto["tamAdi"].ToString();
                    okunanVeriler_Sto[3] = veriOku_Sto["baslik"].ToString();
                    okunanVeriler_Sto[4] = veriOku_Sto["aciklama"].ToString();
                    okunanVeriler_Sto[5] = veriOku_Sto["renk"].ToString();
                    okunanVeriler_Sto[6] = veriOku_Sto["kisi"].ToString();
                    okunanVeriler_Sto[7] = veriOku_Sto["tarih"].ToString();

                    StoryNotlari snot = Veriden_StoryNotuListeyeEkleme(okunanVeriler_Sto); // veritabanındaki storyyi listeye ekleme


                    OleDbCommand veriKomutu_NS = new OleDbCommand();
                    veriKomutu_NS.Connection = veriBaglantisi;
                    veriKomutu_NS.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku_NS = veriKomutu_NS.ExecuteReader();

                    while (veriOku_NS.Read())
                    {
                        if (veriOku_NS["hangiPanelde"].ToString() == "Not Started" && veriOku_NS["sira"].ToString() == snot.sira.ToString()) // o storynin -> not started taskı ise
                        {
                            string[] okunanVeriler_NS = new string[8];
                            okunanVeriler_NS[0] = veriOku_NS["sira"].ToString();
                            okunanVeriler_NS[1] = veriOku_NS["hangiPanelde"].ToString();
                            okunanVeriler_NS[2] = veriOku_NS["tamAdi"].ToString();
                            okunanVeriler_NS[3] = veriOku_NS["baslik"].ToString();
                            okunanVeriler_NS[4] = veriOku_NS["aciklama"].ToString();
                            okunanVeriler_NS[5] = veriOku_NS["renk"].ToString();
                            okunanVeriler_NS[6] = veriOku_NS["kisi"].ToString();
                            okunanVeriler_NS[7] = veriOku_NS["tarih"].ToString();

                            Veriden_NotStartedNotuListeyeEkleme(okunanVeriler_NS, snot);
                        }
                    }

                    OleDbCommand veriKomutu_IP = new OleDbCommand();
                    veriKomutu_IP.Connection = veriBaglantisi;
                    veriKomutu_IP.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku_IP = veriKomutu_IP.ExecuteReader();

                    while (veriOku_IP.Read())
                    {
                        if (veriOku_IP["hangiPanelde"].ToString() == "In Progress" && veriOku_IP["sira"].ToString() == snot.sira.ToString()) // o storynin -> in progress taskı ise
                        {
                            string[] okunanVeriler_IP = new string[8];
                            okunanVeriler_IP[0] = veriOku_IP["sira"].ToString();
                            okunanVeriler_IP[1] = veriOku_IP["hangiPanelde"].ToString();
                            okunanVeriler_IP[2] = veriOku_IP["tamAdi"].ToString();
                            okunanVeriler_IP[3] = veriOku_IP["baslik"].ToString();
                            okunanVeriler_IP[4] = veriOku_IP["aciklama"].ToString();
                            okunanVeriler_IP[5] = veriOku_IP["renk"].ToString();
                            okunanVeriler_IP[6] = veriOku_IP["kisi"].ToString();
                            okunanVeriler_IP[7] = veriOku_IP["tarih"].ToString();

                            Veriden_InProgressNotuListeyeEkleme(okunanVeriler_IP, snot);
                        }
                    }

                    OleDbCommand veriKomutu_Dne = new OleDbCommand();
                    veriKomutu_Dne.Connection = veriBaglantisi;
                    veriKomutu_Dne.CommandText = ("Select * from Veriler");
                    OleDbDataReader veriOku_Dne = veriKomutu_Dne.ExecuteReader();


                    while (veriOku_Dne.Read())
                    {
                        if (veriOku_Dne["hangiPanelde"].ToString() == "Done" && veriOku_Dne["sira"].ToString() == snot.sira.ToString()) // o storynin -> done taskı ise
                        {
                            string[] okunanVeriler_Dne = new string[8];
                            okunanVeriler_Dne[0] = veriOku_Dne["sira"].ToString();
                            okunanVeriler_Dne[1] = veriOku_Dne["hangiPanelde"].ToString();
                            okunanVeriler_Dne[2] = veriOku_Dne["tamAdi"].ToString();
                            okunanVeriler_Dne[3] = veriOku_Dne["baslik"].ToString();
                            okunanVeriler_Dne[4] = veriOku_Dne["aciklama"].ToString();
                            okunanVeriler_Dne[5] = veriOku_Dne["renk"].ToString();
                            okunanVeriler_Dne[6] = veriOku_Dne["kisi"].ToString();
                            okunanVeriler_Dne[7] = veriOku_Dne["tarih"].ToString();

                            Veriden_DoneNotuListeyeEkleme(okunanVeriler_Dne, snot);
                        }
                    }
                }
                eklenecekStorysirasi++;
            }
            veriBaglantisi.Close();
        } // veritabanındaki verileri ilgili listelere ekleme

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
        }  // "Veriden_UygunListelereEkleme()" metotunda kullanılan metotlar
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

        private void Klavyeden_StoryNotuListeyeEkleme(frm_EklemeGoruntuleme storyFormu)
        {
            int kacinciSiraya = VeridekiEnBuyukSayiyiBul();

            StoryNotlari storyNotu = new StoryNotlari
            {
                sira = kacinciSiraya + 1,
                hangiPanelde = "Stories",
                tamAdi = storyFormu.etiket + storyFormu.baslik,
                baslik = storyFormu.baslik,
                aciklama = storyFormu.aciklama,
                renk = storyFormu.etiket,
                kisi = storyFormu.kimTarafindan,
                tarih = storyFormu.tarih,
            };

            ana_notListesi.Add(storyNotu);

            VeriEkle(storyNotu);
        } // klavyeden girilen notların listeye -> ordan da veritabanına aktarılması
        private void Klavyeden_NotStartedNotuListeyeEkleme(frm_EklemeGoruntuleme taskFormu, StoryNotlari storyNotu)
        {
            foreach (StoryNotlari stoNot in ana_notListesi)
            {
                if (stoNot == storyNotu)
                {

                    NotStartedNotlari notStartednotu = new NotStartedNotlari
                    {
                        sira = storyNotu.sira,
                        hangiPanelde = "Not Started",
                        tamAdi = storyNotu.renk + taskFormu.baslik,
                        baslik = taskFormu.baslik,
                        aciklama = taskFormu.aciklama,
                        renk = storyNotu.renk,
                        kisi = taskFormu.kimTarafindan,
                        tarih = taskFormu.tarih,
                    };

                    storyNotu.NotStTaskListesi.Add(notStartednotu);

                    VeriEkle(notStartednotu);

                    break;
                }
            }
        }

        private void VeriGuncelle(frm_EklemeGoruntuleme aktifForm, string guncellenecekVeri)
        {
            veriBaglantisi.Open();
            ana_veriKomutu.Connection = veriBaglantisi;
            ana_veriKomutu.CommandText = "update Veriler set hangiPanelde='" + aktifForm.hangiPanele + "', aciklama='" + aktifForm.aciklama + "', kisi='" + aktifForm.kimTarafindan + "', tarih='" + aktifForm.tarih.ToShortDateString() + "'where tamAdi = '" + guncellenecekVeri + "'";
            ana_veriKomutu.ExecuteNonQuery();
            veriBaglantisi.Close();

            SiralamaIcinGerekliIslemler();
        } // ilgili veriyi veritabanında güncelleme

        private string[] VeriBul(string aranacakVeri)
        {
            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand();
            veriKomutu.Connection = veriBaglantisi;
            veriKomutu.CommandText = ("Select * from Veriler");
            OleDbDataReader veriOku = veriKomutu.ExecuteReader();

            string[] okunanVeri = new string[8];

            while (veriOku.Read())
            {
                if (veriOku["tamAdi"].ToString() == aranacakVeri)
                {
                    okunanVeri[0] = veriOku["sira"].ToString();
                    okunanVeri[1] = veriOku["hangiPanelde"].ToString();
                    okunanVeri[2] = veriOku["tamAdi"].ToString();
                    okunanVeri[3] = veriOku["baslik"].ToString();
                    okunanVeri[4] = veriOku["aciklama"].ToString();
                    okunanVeri[5] = veriOku["renk"].ToString();
                    okunanVeri[6] = veriOku["kisi"].ToString();
                    okunanVeri[7] = veriOku["tarih"].ToString();
                }
            }
            veriBaglantisi.Close();

            return okunanVeri;
        }  // ilgili veriyi veritabanında bulma

        private void VeriEkle(Notlar aktifNot)
        {
            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand("insert into Veriler (sira,hangiPanelde,tamAdi,baslik,aciklama,renk,kisi,tarih) values ('" + aktifNot.sira + "','" + aktifNot.hangiPanelde + "','" + aktifNot.tamAdi + "','" + aktifNot.baslik + "','" + aktifNot.aciklama + "','" + aktifNot.renk + "' , '" + aktifNot.kisi + "' , '" + aktifNot.tarih.ToShortDateString() + "')", veriBaglantisi);
            veriKomutu.ExecuteNonQuery();
            veriBaglantisi.Close();
        }  // ilgili veriyi veritabanına ekleme

        private void VeriSil(string silinecekVeri)
        {
            veriBaglantisi.Open();
            ana_veriKomutu.Connection = veriBaglantisi;
            ana_veriKomutu.CommandText = "delete from Veriler where tamAdi= '" + silinecekVeri + "'";
            ana_veriKomutu.ExecuteNonQuery();
            veriBaglantisi.Close();

            SiralamaIcinGerekliIslemler();
            ana_notListesi = new List<Notlar>();
            Veriden_UygunListelereEkleme();
            ListedekiNotlariPaneleAktarma();
        }  // ilgili veriyi veritabanından silme

        private int VeridekiEnBuyukSayiyiBul()
        {
            int enBuyuksayi = 0;

            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand();
            veriKomutu.Connection = veriBaglantisi;
            veriKomutu.CommandText = ("Select * from Veriler");
            OleDbDataReader veriOku = veriKomutu.ExecuteReader();
            while (veriOku.Read()) // veritabanından veri okuma işlemi
            {
                enBuyuksayi = Convert.ToInt32(veriOku["sira"]);

                while (veriOku.Read())
                {
                    if (Convert.ToInt32(veriOku["sira"]) > enBuyuksayi)
                        enBuyuksayi = Convert.ToInt32(veriOku["sira"]);
                }
            }
            veriBaglantisi.Close();

            return enBuyuksayi;
        }  // veritabanındaki en büyük sayıyı(yani story sırasını) döndürme

        private void SiralamaIcinGerekliIslemler()
        {
            pnl_Stories.Controls.Clear();
            pnl_NotStarted.Controls.Clear();
            pnl_InProgress.Controls.Clear();
            pnl_Done.Controls.Clear();
            eklenenStorysayisi = 0;
            for (int i = 0; i < 5; i++)
            {
                eklenenTaskSayaci_NS[i] = 0;
                eklenenTaskSayaci_IP[i] = 0;
                eklenenTaskSayaci_Dne[i] = 0;
            }
            ana_notListesi = new List<Notlar>();
            Veriden_UygunListelereEkleme();
            ListedekiNotlariPaneleAktarma();
        } // veritabanındaki işlemler sonrasında notların yerinin güncenllenmesi için gerekli sıfırlamalar
        //


        //form-panel işlemleri
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
        }  // listedeki verilerin tümünü ilgili panellere ekleme

        int eklenenStorysayisi;
        private void Listeden_PaneleStoryEkleme(Notlar not)
        {
            Label storyLabeli = new Label();

            storyLabeli.Location = new Point(0, (eklenenStorysayisi * 205));
            eklenenStorysayisi++;

            storyLabeli.Size = new Size(180, 180);
            storyLabeli.FlatStyle = FlatStyle.Flat;
            storyLabeli.TextAlign = ContentAlignment.MiddleCenter;
            storyLabeli.Text = not.baslik;
            pnl_Stories.Controls.Add(storyLabeli);

            NotRenginiBelirleme(storyLabeli, not.renk);

            storyLabeli.MouseClick += StoryyeTiklama;

            Label addTaskLabeli = LabeleAddTaskLabeliEkleme(storyLabeli);

            addTaskLabeli.MouseClick += AddTaskLabelineTiklama;
        }  // "ListedekiNotlariPaneleAktarma()" metodunda kullanılan metot -> listedeki veri story ise story paneline ekleme yapıyor

        private void Listeden_PaneleTaskEkleme(Notlar not, Panel nereyeEklenecek)
        {
            Label eklenecekTask = new Label();

            if (nereyeEklenecek == pnl_NotStarted)
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaci_NS[not.sira] * 45));
                eklenenTaskSayaci_NS[not.sira]++;
            }
            else if (nereyeEklenecek == pnl_InProgress)
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaci_IP[not.sira] * 45));
                eklenenTaskSayaci_IP[not.sira]++;
            }
            else
            {
                eklenecekTask.Location = new Point(0, ((205 * not.sira)) + (eklenenTaskSayaci_Dne[not.sira] * 45));
                eklenenTaskSayaci_Dne[not.sira]++;
            }

            eklenecekTask.Size = new Size(180, 40);
            eklenecekTask.FlatStyle = FlatStyle.Flat;
            eklenecekTask.TextAlign = ContentAlignment.MiddleCenter;
            eklenecekTask.Text = not.baslik;

            NotRenginiBelirleme(eklenecekTask, not.renk);

            nereyeEklenecek.Controls.Add(eklenecekTask);

            eklenecekTask.MouseClick += TaskeTiklama;
        }  // "ListedekiNotlariPaneleAktarma()" metodunda kullanılan metot -> listedeki veri task ise ilgili panele ekleme yapıyor

        private void StoryyeTiklama(object sender, MouseEventArgs e)
        {
            Label tiklananLabel = (Label)sender;
            string labelTamadi = tiklananLabel.BackColor.Name + tiklananLabel.Text;

            string[] okunanVeriler = VeriBul(labelTamadi);

            frm_EklemeGoruntuleme goruntuleme = new frm_EklemeGoruntuleme();
            goruntuleme.cmb_Konumlandir.Hide();
            goruntuleme.StoryGoruntuleme("story", okunanVeriler[3], okunanVeriler[4], okunanVeriler[6], okunanVeriler[7], okunanVeriler[1]);

            if (goruntuleme.eklensinMi)
            {
                VeriGuncelle(goruntuleme, labelTamadi);
            }
        }  // story notuna tıklanıldığında gerçekleşecek işlemler

        private void TaskeTiklama(object sender, MouseEventArgs e)
        {
            Label tiklananLabel = (Label)sender;
            string labelTamadi = tiklananLabel.BackColor.Name + tiklananLabel.Text;

            string[] okunanVeriler = VeriBul(labelTamadi);

            frm_EklemeGoruntuleme goruntuleme = new frm_EklemeGoruntuleme();
            goruntuleme.TaskGoruntuleme(okunanVeriler[3], okunanVeriler[4], okunanVeriler[6], okunanVeriler[7], okunanVeriler[1]);

            if (goruntuleme.eklensinMi)
            {
                VeriGuncelle(goruntuleme, labelTamadi);
            }

            else if (goruntuleme.silinsinMi)
            {
                VeriSil(labelTamadi);
            }

        }  // task notuna tıklanıldığında gerçekleşecek işlemler

        private void AddStoryLabelineTiklama(object sender, EventArgs e)
        {
            frm_EklemeGoruntuleme storyEklemeformu = new frm_EklemeGoruntuleme();
            storyEklemeformu.cmb_Konumlandir.Hide();
            storyEklemeformu.ShowDialog();

            if (storyEklemeformu.eklensinMi)
            {
                Klavyeden_StoryNotuListeyeEkleme(storyEklemeformu);

                SiralamaIcinGerekliIslemler();
           
                ListedekiNotlariPaneleAktarma();
            }
        }  // story eklemeye tıklanıldığında gerçekleşecek işlemler

        private void AddTaskLabelineTiklama(object sender, MouseEventArgs e)
        {
            Label tiklananLabel = (Label)sender;

            ana_storyNotu = HangiStoryninNotu(tiklananLabel);

            frm_EklemeGoruntuleme taskEklemeformu = new frm_EklemeGoruntuleme();
            taskEklemeformu.cmb_Etiket.Enabled = false;
            taskEklemeformu.cmb_Konumlandir.Hide();
            taskEklemeformu.ShowDialog();

            if (taskEklemeformu.eklensinMi)
            {
                Klavyeden_NotStartedNotuListeyeEkleme(taskEklemeformu, ana_storyNotu);

                SiralamaIcinGerekliIslemler();

                ListedekiNotlariPaneleAktarma();
                   
            }
        }  // task eklemeye tıklanıldığında gerçekleşecek işlemler

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
        }  // story labelinin sağ alt köşesine "+ add task" şeklinde label eklenmesi

        int[] eklenenTaskSayaci_NS = new int[5];  // ilgili storylerin dizilişini kontrol eden değerler
        int[] eklenenTaskSayaci_IP = new int[5];
        int[] eklenenTaskSayaci_Dne = new int[5];
        private Label PaneleTaskEkleme(int yerlestirme, frm_EklemeGoruntuleme taskFormu, Panel nereyeEklenecek)
        {
            Label eklenecekTask = new Label();

            if (nereyeEklenecek == pnl_NotStarted)
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaci_NS[yerlestirme] * 45));
                eklenenTaskSayaci_NS[yerlestirme]++;
            }
            else if (nereyeEklenecek == pnl_InProgress)
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaci_IP[yerlestirme] * 45));
                eklenenTaskSayaci_IP[yerlestirme]++;
            }
            else
            {
                eklenecekTask.Location = new Point(0, ((205 * yerlestirme)) + (eklenenTaskSayaci_Dne[yerlestirme] * 45));
                eklenenTaskSayaci_Dne[yerlestirme]++;
            }

            eklenecekTask.Size = new Size(180, 40);
            eklenecekTask.FlatStyle = FlatStyle.Flat;
            eklenecekTask.TextAlign = ContentAlignment.MiddleCenter;
            eklenecekTask.Text = taskFormu.baslik;
            nereyeEklenecek.Controls.Add(eklenecekTask);

            return eklenecekTask;
        }  //panele task eklenmesi

        private StoryNotlari HangiStoryninNotu(Label tiklananLabel)
        {
            string tiklananLabelrengi = tiklananLabel.BackColor.Name;
            foreach (StoryNotlari stoNot in ana_notListesi)
            {
                if (stoNot.renk == tiklananLabelrengi)
                {
                    ana_storyNotu = stoNot;
                }
            }

            return ana_storyNotu;
        } // tıklanan task hangi storyiye ait olduğunu döndüren metot

        public void NotRenginiBelirleme(Label aktifLabel, string etiketRengi)
        {
            switch (etiketRengi)
            {
                case "Yellow":
                    aktifLabel.BackColor = Color.Yellow;
                    break;

                case "Red":
                    aktifLabel.BackColor = Color.Red;
                    break;

                case "LightGreen":
                    aktifLabel.BackColor = Color.LightGreen;
                    break;

                case "LightSkyBlue":
                    aktifLabel.BackColor = Color.LightSkyBlue;
                    break;

                case "White":
                    aktifLabel.BackColor = Color.White;
                    break;

                case "DarkOrchid":
                    aktifLabel.BackColor = Color.DarkOrchid;
                    break;

                case "DarkOrange":
                    aktifLabel.BackColor = Color.DarkOrange;
                    break;

                default:
                    aktifLabel.BackColor = Color.HotPink;
                    break;
            }
        } // ilgili notun renginin belirlenmesi
        //
    }
}
