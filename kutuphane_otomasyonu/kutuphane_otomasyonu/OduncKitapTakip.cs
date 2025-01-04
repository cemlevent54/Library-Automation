using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class OduncKitapTakip : Form
    {
        public OduncKitapTakip()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();

        private string format = "dd.MM.yyyy";
 
        DataGridViewRow selectedRow;

        private void guncelle()
        {
            if (ConnectionState.Closed == baglanti.State)
            {
                baglanti.Open();
            }

            List<string> kullaniciAdlari = new List<string>();
            List<string> kitapIdleri = new List<string>();
            List<int> gunFarklari = new List<int>();

            string sqlquery = "SELECT * FROM oduncKitaplar";
            SqlCommand tabloKomut = new SqlCommand(sqlquery, baglanti);
            SqlDataReader tabloOku = tabloKomut.ExecuteReader();

            while (tabloOku.Read())
            {
                string kullaniciAdi = tabloOku["kullaniciAdi"].ToString().Replace(" ", "");
                string kitapId = tabloOku["id"].ToString().Replace(" ", "");
                string oduncTarih = tabloOku["oduncTarih"].ToString().Replace(" ", "");

                DateTime oduncTime;
                DateTime simdi = DateTime.Now;
                int gunFarki;

                if (DateTime.TryParseExact(oduncTarih, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out oduncTime))
                {
                    TimeSpan fark = simdi - oduncTime;
                    gunFarki = (int)fark.TotalDays;
                }
                else
                {
                    gunFarki = -1;
                }

                kullaniciAdlari.Add(kullaniciAdi);
                kitapIdleri.Add(kitapId);
                gunFarklari.Add(gunFarki);
            }

            tabloOku.Close();
            baglanti.Close();

            // Güncelleme işlemini gerçekleştir
            for (int i = 0; i < kullaniciAdlari.Count; i++)
            {
                string kullaniciAdi = kullaniciAdlari[i];
                string kitapId = kitapIdleri[i];
                int gunFarki = gunFarklari[i];

                string kacGun = gunFarki.ToString();

                string sqlguncellemequery = "UPDATE oduncKitaplar SET kacGun = @kacGun WHERE kullaniciAdi=@kullaniciAdi AND id=@id";
                SqlCommand komutguncelleme = new SqlCommand(sqlguncellemequery, baglanti);
                komutguncelleme.Parameters.AddWithValue("@kacGun", kacGun);
                komutguncelleme.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komutguncelleme.Parameters.AddWithValue("@id", kitapId);

                if (ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }

                komutguncelleme.ExecuteNonQuery();
                baglanti.Close();
            }
        }



        private void OduncKitapTakip_Load(object sender, EventArgs e)
        {
            //verileriYukle();
            guncelle();
            string sqlQuery = "SELECT kullaniciAdi AS 'Kullanıcı Adı',id AS 'Kitap ID', oduncTarih AS 'Ödünç Alınan Tarih', kacGun AS 'Kaç Gün' FROM oduncKitaplar";
            kontrol.verileriTabloyaAktar(sqlQuery, dataGridView1);
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı',id AS 'Kitap ID', oduncTarih AS 'Ödünç Alınan Tarih', kacGun AS 'Kaç Gün' FROM oduncKitaplar WHERE kullaniciAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }
    }
}
