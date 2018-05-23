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
    public partial class EklemeGoruntuleme : Form
    {
        public EklemeGoruntuleme()
        {
            InitializeComponent();
        }

        OleDbConnection veriBaglantisi = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\bin\\Debug\\Veriler.mdb");

        private void VerilerGoruntule()
        {
            veriBaglantisi.Open();
            OleDbCommand veriKomutu = new OleDbCommand();
            veriKomutu.Connection = veriBaglantisi;
            veriKomutu.CommandText = ("Select * from Verier");
            OleDbDataReader veriOku = veriKomutu.ExecuteReader();
            while (veriOku.Read())
            {

            }
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {

        }
    }
    //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\Debug\Veriler.mdb
}
