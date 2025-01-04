using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class KullaniciSilme : Form
    {
        public KullaniciSilme(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        public string username;
        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        private void btn_kayitSil_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = username;
            baglanti.Open();
            string sqlquery = "DELETE kullaniciTablosu WHERE kullaniciadi=@kullaniciAdi";
            SqlCommand komut = new SqlCommand(sqlquery,baglanti);
            komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            komut.ExecuteNonQuery();
            label2.Text = "kaydınız silindi.";
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
