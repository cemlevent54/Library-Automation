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

namespace kutuphane_otomasyonu
{
    public partial class KitapGoruntuleme : Form
    {
        public KitapGoruntuleme()
        {
            InitializeComponent();
        }

        

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
        

        private void gereksiz()
        {
            //baglanti.Open();
            //string sqlquery = "SELECT * FROM kitapTablosu";
            //SqlCommand komut = new SqlCommand(sqlquery, baglanti);
            //SqlDataReader oku = komut.ExecuteReader();

            //while (oku.Read())
            //{
            //    ListViewItem item = new ListViewItem(oku["id"].ToString());
            //    item.SubItems.Add(oku["kitapAdi"].ToString());
            //    item.SubItems.Add(oku["kitapAdet"].ToString());
            //    listView1.Items.Add(item);
            //}

            //baglanti.Close();
        }

        private void KitapGoruntuleme_Load(object sender, EventArgs e)
        {
            string sqlquery = "SELECT id AS 'Kitap ID', kitapAdi AS 'Kitap Adı', kitapAdet AS 'Adet' , yazar AS 'Yazar',tur 'Kitap Türü' FROM kitapTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    string sqlquery = "SELECT * FROM kitapTablosu WHERE id=@id AND kitapAdi=@kitapAdi AND kitapAdet=@kitapAdet";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@id", selectedRow.Cells["Kitap ID"].Value.ToString());
                    komut.Parameters.AddWithValue("@kitapAdi", selectedRow.Cells["Kitap Adı"].Value.ToString());
                    komut.Parameters.AddWithValue("@kitapAdet", selectedRow.Cells["Adet"].Value.ToString());
                    SqlDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        string isim, kitapAdi, yazar, tur, sayfaSayisi, basimYili, yayinevi, kitapAdet;
                        isim = oku["id"].ToString().Replace(" ", "");
                        kitapAdi = oku["kitapAdi"].ToString();
                        yazar = oku["yazar"].ToString();
                        tur = oku["tur"].ToString().Replace(" ", "");
                        sayfaSayisi = oku["sayfaSayisi"].ToString().Replace(" ", "");
                        basimYili = oku["basimYili"].ToString().Replace(" ", "");
                        yayinevi = oku["yayinevi"].ToString().Replace(" ", "");
                        kitapAdet = oku["kitapAdet"].ToString().Replace(" ", "");

                        // Sonuç oluşturuldu
                        string result = "Kitap Bilgileri:" + "\n" + isim + "\n" + kitapAdi + "\n" + yazar + "\n" + tur + "\n" + sayfaSayisi + "\n" + basimYili
                        + "\n" + yayinevi + "\n" + kitapAdet;

                        label6.Text = result;
                    }
                    else
                    {
                        label6.Text = "Kitap bulunamadı.";
                    }
                    oku.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    baglanti.Close();
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT id AS 'Kitap ID', kitapAdi AS 'Kitap Adı', kitapAdet AS 'Adet' , yazar AS 'Yazar',tur 'Kitap Türü' FROM kitapTablosu WHERE kitapAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            string sqlquery = "SELECT id AS 'Kitap ID', kitapAdi AS 'Kitap Adı', kitapAdet AS 'Adet' , yazar AS 'Yazar',tur 'Kitap Türü' FROM kitapTablosu WHERE yazar LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text;
            string sqlquery = "SELECT id AS 'Kitap ID', kitapAdi AS 'Kitap Adı', kitapAdet AS 'Adet' , yazar AS 'Yazar',tur 'Kitap Türü' FROM kitapTablosu WHERE tur LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    string sqlquery = "SELECT * FROM kitapTablosu WHERE id=@id AND kitapAdi=@kitapAdi AND kitapAdet=@kitapAdet";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@id", selectedRow.Cells["Kitap ID"].Value.ToString());
                    komut.Parameters.AddWithValue("@kitapAdi", selectedRow.Cells["Kitap Adı"].Value.ToString());
                    komut.Parameters.AddWithValue("@kitapAdet", selectedRow.Cells["Adet"].Value.ToString());
                    SqlDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        string isim, kitapAdi, yazar, tur, sayfaSayisi, basimYili, yayinevi, kitapAdet;
                        isim = oku["id"].ToString().Replace(" ", "");
                        kitapAdi = oku["kitapAdi"].ToString();
                        yazar = oku["yazar"].ToString();
                        tur = oku["tur"].ToString().Replace(" ", "");
                        sayfaSayisi = oku["sayfaSayisi"].ToString().Replace(" ", "");
                        basimYili = oku["basimYili"].ToString().Replace(" ", "");
                        yayinevi = oku["yayinevi"].ToString().Replace(" ", "");
                        kitapAdet = oku["kitapAdet"].ToString().Replace(" ", "");

                        // Sonuç oluşturuldu
                        string result = "Kitap Bilgileri:" + "\n" + isim + "\n" + kitapAdi + "\n" + yazar + "\n" + tur + "\n" + sayfaSayisi + "\n" + basimYili
                        + "\n" + yayinevi + "\n" + kitapAdet;

                        label6.Text = result;
                    }
                    else
                    {
                        label6.Text = "Kitap bulunamadı.";
                    }
                    oku.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }
    }
}
