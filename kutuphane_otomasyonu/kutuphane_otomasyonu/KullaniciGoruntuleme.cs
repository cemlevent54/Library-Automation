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
    public partial class KullaniciGoruntuleme : Form
    {
        public KullaniciGoruntuleme()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
    
        private void KullaniciGoruntuleme_Load(object sender, EventArgs e)
        {
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'Ad', email AS 'E-mail' FROM kullaniciTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string result = "";
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (ConnectionState.Closed == baglanti.State)
                    {
                        baglanti.Open();
                    }

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string kullaniciAdi = row.Cells["Kullanıcı Adı"].Value.ToString();
                    string kullaniciEmail = row.Cells["E-mail"].Value.ToString();
                    string sqlquery = "SELECT ad, soyad, dogumTarihi, cinsiyet, telefonNumarasi, adres, kullaniciAdi, sifre FROM kullaniciTablosu WHERE kullaniciAdi LIKE @arananKullanici AND email LIKE @arananEmail";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@arananKullanici", "%" + kullaniciAdi + "%");
                    komut.Parameters.AddWithValue("@arananEmail", "%" + kullaniciEmail + "%");
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        string ad = oku["ad"].ToString().Replace(" ", "");
                        string soyad = oku["soyad"].ToString().Replace(" ", "");
                        string dogumTarihi = oku["dogumTarihi"].ToString().Replace(" ", "");
                        string cinsiyet = oku["cinsiyet"].ToString().Replace(" ", "");
                        string telefonNumarasi = oku["telefonNumarasi"].ToString().Replace(" ", "");
                        string adres = oku["adres"].ToString().Replace(" ", "");
                        string kullaniciad = oku["kullaniciAdi"].ToString().Replace(" ", "");
                        string sifre = oku["sifre"].ToString().Replace(" ", "");

                        result = "Kullanıcı Bilgileri\n" + ad + "\n" + soyad + "\n" + dogumTarihi + "\n" + cinsiyet + "\n" +
                            telefonNumarasi + "\n" + kullaniciEmail + "\n" + adres + "\n" + kullaniciAdi + "\n" + sifre;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
            finally
            {
                label1.Text = result;
                baglanti.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'Ad', email AS 'E-mail' FROM kullaniciTablosu WHERE kullaniciAdi LIKE @aranan";
            kontrol.veriArama(sqlquery,searchText,dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'Ad', email AS 'E-mail' FROM kullaniciTablosu WHERE ad LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'Ad', email AS 'E-mail' FROM kullaniciTablosu WHERE email LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }
    }
}
