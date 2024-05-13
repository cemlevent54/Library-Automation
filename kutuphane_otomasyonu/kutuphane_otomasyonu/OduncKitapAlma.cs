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
using static kutuphane_otomasyonu.KontrolEtmeFonksiyonlari;

namespace kutuphane_otomasyonu
{
    public partial class OduncKitapAlma : Form
    {
        public OduncKitapAlma(string username)
        {
            InitializeComponent();
            this.username=username;
        }
        private string username;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();

        private void OduncKitapAlma_Load(object sender, EventArgs e)
        {
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', yazar AS 'Yazar' FROM kitapTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox4.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', yazar AS 'Yazar' FROM kitapTablosu WHERE kitapAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', yazar AS 'Yazar' FROM kitapTablosu WHERE yazar LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private DataGridViewRow selectedRow;
        
        // kitap odunc alma
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }
                if (selectedRow == null)
                {
                    label4.Text = "secim yok";
                }
                else { 
                    string oduncVerilecekKitapID = selectedRow.Cells["Kitap ID"].Value.ToString().Replace(" ", "");
                    string time = "";
                    DateTime simdi = DateTime.Now;
                    time = simdi.ToString("dd/MM/yyyy");
                    string oduncAlanKullaniciAdi = username;
                    string kitapAdet = "";
                    string oduncVerilecekKitapAdi = selectedRow.Cells["Kitap Adı"].Value.ToString();
                    oduncVerilecekKitapAdi = System.Text.RegularExpressions.Regex.Replace(oduncVerilecekKitapAdi, @"\s+", " ").Trim();
                    string oduncVerilenTarih = time.Replace(" ","");
                    // islemleri buraya yap

                    string sqlUserQuery = "SELECT * FROM kullaniciTablosu WHERE kullaniciAdi=@aranan";
                    SqlCommand komutUser = new SqlCommand(sqlUserQuery, baglanti);
                    komutUser.Parameters.AddWithValue("@aranan", oduncAlanKullaniciAdi);
                    SqlDataReader readUser = komutUser.ExecuteReader();

                    if (readUser.Read())
                    {
                        string kullanici = readUser["kullaniciAdi"].ToString().Replace(" ", "");
                        readUser.Close();
                        string sqlBookQuery = "SELECT * FROM kitapTablosu WHERE id=@id";
                        SqlCommand komutBook = new SqlCommand(sqlBookQuery, baglanti);
                        komutBook.Parameters.AddWithValue("@id", selectedRow.Cells["Kitap ID"].Value.ToString());
                        SqlDataReader readBook = komutBook.ExecuteReader();
                        if (readBook.Read())
                        {
                            string kitapAdi = readBook["kitapAdi"].ToString();
                            string kitapid = readBook["id"].ToString().Replace(" ", "");
                            string kitapAdeti = readBook["kitapAdet"].ToString().Replace(" ", "");
                            readBook.Close();
                            kitapAdeti = (int.Parse(kitapAdeti) -1).ToString();

                            string sqlUpdateQuery = "UPDATE kitapTablosu SET kitapAdet=@kitapAdet WHERE id=@id";
                            SqlCommand komutUpdate = new SqlCommand(sqlUpdateQuery, baglanti);
                            komutUpdate.Parameters.AddWithValue("@kitapAdet", kitapAdeti);
                            komutUpdate.Parameters.AddWithValue("@id", kitapid);
                            komutUpdate.ExecuteNonQuery();

                            string sqlInsertQuery = "INSERT into oduncKitaplar (kullaniciAdi,id,oduncTarih) " +
                                "VALUES (@kullaniciAdi,@id,@oduncTarih)";
                            SqlCommand komutInsert = new SqlCommand(sqlInsertQuery, baglanti);
                            komutInsert.Parameters.AddWithValue("@kullaniciAdi", kullanici);
                            komutInsert.Parameters.AddWithValue("@id", kitapid);
                            komutInsert.Parameters.AddWithValue("@oduncTarih", oduncVerilenTarih);
                            komutInsert.ExecuteNonQuery();
                            label4.Text = kitapAdi + " adli kitabı " + time + " tarihi itibariyle aldınız.\nKeyifli Okumalar!";
                            string sqltablequery = "SELECT kitapAdet AS 'Adet',id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', yazar AS 'Yazar' FROM kitapTablosu";
                            kontrol.verileriTabloyaAktar(sqltablequery, dataGridView1);
                        }
                        else label4.Text = "Kitap bulunamadı.";
                    }
                    else label4.Text = "Kullanıcı bulunamadı.";
                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Tıklanan hücrenin satırını seç
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }
    }
}
