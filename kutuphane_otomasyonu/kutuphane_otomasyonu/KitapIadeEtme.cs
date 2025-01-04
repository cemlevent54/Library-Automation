using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Configuration;

namespace kutuphane_otomasyonu
{
    public partial class KitapIadeEtme : Form
    {
        public KitapIadeEtme(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
        private string username;

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void KitapIadeEtme_Load(object sender, EventArgs e)
        {
            //verileriYukle();
            string sqlquery = "SELECT oduncKitaplar.kullaniciAdi AS 'Kullanıcı Adı', oduncKitaplar.id AS 'Kitap ID', kitapTablosu.kitapAdi AS 'Kitap Adı', oduncKitaplar.oduncTarih AS 'Ödünç Alınan Tarih' FROM oduncKitaplar INNER JOIN kitapTablosu ON oduncKitaplar.id = kitapTablosu.id WHERE oduncKitaplar.kullaniciAdi = @aranan";
            kontrol.verileriTabloyaAktar(sqlquery,username,dataGridView1);

        }

        
        private DataGridViewRow selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Tıklanan hücrenin satırını seç
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                label1.Text = "Lütfen iade etmek istediğiniz kitabı seçin.";
                return;
            }
            string silinecekid = selectedRow.Cells["Kitap ID"].Value.ToString().Replace(" ", "");
            string time = "";
            DateTime zaman = DateTime.Now;
            time = zaman.ToString("dd/MM/yyyy");
            string kullaniciAdi = username;
            string kitapAdet = "";
            string silinecekkitapadi = selectedRow.Cells["Kitap Adı"].Value.ToString();
            silinecekkitapadi = System.Text.RegularExpressions.Regex.Replace(silinecekkitapadi, @"\s+", " ").Trim();
            string silinecekOduncTarih = selectedRow.Cells["Ödünç Alınan Tarih"].Value.ToString().Replace(" ", "");

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }


                if (dataGridView1.SelectedRows.Count == 0)
                {
                    label1.Text = "Seçim yok";
                }

                else
                {
                    // silme 
                    string sqlquery_1 = "DELETE FROM oduncKitaplar WHERE id=@id AND kullaniciAdi=@kullaniciAdi";
                    SqlCommand silmeKomut = new SqlCommand(sqlquery_1, baglanti);
                    silmeKomut.Parameters.AddWithValue("@id", silinecekid);
                    silmeKomut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    silmeKomut.ExecuteNonQuery();

                    // kitap ekleme
                    string sqlquery_2 = "SELECT * FROM kitapTablosu WHERE id=@id";
                    SqlCommand adetKomut = new SqlCommand(sqlquery_2, baglanti);
                    adetKomut.Parameters.AddWithValue("@id", silinecekid);
                    SqlDataReader adetOku = adetKomut.ExecuteReader();
                    if (adetOku.Read())
                    {
                        kitapAdet = (int.Parse(adetOku["kitapAdet"].ToString().Replace(" ", "")) + 1).ToString();
                    }
                    adetOku.Close();

                    //güncelleme
                    string sqlquery_3 = "UPDATE kitapTablosu SET kitapAdet=@kitapAdet WHERE id=@id";
                    SqlCommand adetGuncellemeKomut = new SqlCommand(sqlquery_3, baglanti);
                    adetGuncellemeKomut.Parameters.AddWithValue("@kitapAdet", kitapAdet);
                    adetGuncellemeKomut.Parameters.AddWithValue("@id", silinecekid);
                    adetGuncellemeKomut.ExecuteNonQuery();

                    label1.Text = silinecekid + " id'li kitabı " + time + " tarihinde iade ettiniz.";

                    // insert to arsiv
                    string sqlquery_4 = "INSERT into oduncKitapArsivi (kullaniciAdi,id,kitapAdi,oduncTarih,iadeTarih) " +
                        "VALUES (@kullaniciAdi,@id,@kitapAdi,@oduncTarih,@iadeTarih)";
                    SqlCommand arsivKomut = new SqlCommand(sqlquery_4, baglanti);
                    arsivKomut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    arsivKomut.Parameters.AddWithValue("@id", silinecekid);
                    arsivKomut.Parameters.AddWithValue("@kitapAdi", silinecekkitapadi);
                    arsivKomut.Parameters.AddWithValue("@oduncTarih", silinecekOduncTarih);
                    arsivKomut.Parameters.AddWithValue("@iadeTarih", time);
                    arsivKomut.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
                string sqlquery = "SELECT oduncKitaplar.kullaniciAdi AS 'Kullanıcı Adı', oduncKitaplar.id AS 'Kitap ID', kitapTablosu.kitapAdi AS 'Kitap Adı', oduncKitaplar.oduncTarih AS 'Ödünç Alınan Tarih' FROM oduncKitaplar INNER JOIN kitapTablosu ON oduncKitaplar.id = kitapTablosu.id WHERE oduncKitaplar.kullaniciAdi = @aranan";
                kontrol.verileriTabloyaAktar(sqlquery, username, dataGridView1);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Tıklanan hücrenin satırını seç
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }
    }
}


