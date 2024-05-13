using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class KitapArama : Form
    {
        public KitapArama()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");

        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
        private void KitapArama_Load(object sender, EventArgs e)
        {
            string sqlquery = "SELECT kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
            
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_Search.Text;
            string sqlquery = "SELECT kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE kitapAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE yazar LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string kitapyazar = row.Cells["Yazar"].Value.ToString();
                string kitapAdi = row.Cells["Kitap Adı"].Value.ToString();
                string result = "";

                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    string sqlquery = "SELECT * FROM kitapTablosu WHERE yazar=@yazar AND kitapAdi=@kitapAdi";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@yazar", kitapyazar);
                    komut.Parameters.AddWithValue("@kitapAdi", kitapAdi);
                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        string yazar = oku["yazar"].ToString();
                        string tur = oku["tur"].ToString().Replace(" ", "");
                        string sayfaSayisi = oku["sayfaSayisi"].ToString().Replace(" ", "");
                        string basimYili = oku["basimYili"].ToString().Replace(" ", "");
                        string yayinevi = oku["yayinevi"].ToString().Replace(" ", "");
                        string kitapAdet = oku["kitapAdet"].ToString().Replace(" ", "");

                        result = "Kitap Bilgileri:" + "\n" + kitapyazar + "\n" + kitapAdi + "\n" + yazar + "\n" + tur + "\n" + sayfaSayisi + "\n" + basimYili
                                    + "\n" + yayinevi + "\n" + kitapAdet;
                        break;
                    }

                    oku.Close();
                }
                catch (Exception ex)
                {
                    lbl_result.Text = "Hata: " + ex.Message;
                }
                finally
                {
                    lbl_result.Text = result;
                    baglanti.Close();
                }
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            string sqlquery = "SELECT kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE tur LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text;
            string sqlquery = "SELECT kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE yayinevi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }
    }
}
