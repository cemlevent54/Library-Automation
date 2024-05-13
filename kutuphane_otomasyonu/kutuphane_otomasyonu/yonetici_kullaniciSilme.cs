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
    public partial class yonetici_kullaniciSilme : Form
    {
        public yonetici_kullaniciSilme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
        

        private void yonetici_kullaniciSilme_Load(object sender, EventArgs e)
        {
            //verileriYukle();
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'İsim', email AS 'E-mail' FROM kullaniciTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'İsim', email AS 'E-mail' FROM kullaniciTablosu WHERE kullaniciAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText,dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'İsim', email AS 'E-mail' FROM kullaniciTablosu WHERE email LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        
        
        private string ReturnUserNameInfo_dgw()
        {
            string name = "";

            if (selectedRow != null) // selectedRow değişkenini kontrol etmek için null olup olmadığını kontrol edin
            {
                name = selectedRow.Cells["Kullanıcı Adı"].Value.ToString(); // İsim sütununun adını doğru şekilde değiştirin.
            }
            return name;
        }

        private void btn_kullaniciSil_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = ReturnUserNameInfo_dgw(); // Doğru fonksiyonu çağırın

            if (!string.IsNullOrEmpty(kullaniciAdi)) // İsimin boş olup olmadığını kontrol edin
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) // ConnectionState.Closed kontrolü
                    {
                        baglanti.Open();
                    }

                    string sqlquery = "DELETE FROM kullaniciTablosu WHERE kullaniciAdi=@kullaniciAdi";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    int affectedRows = komut.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        label4.Text = "Kayıt silindi.";
                    }
                    else
                    {
                        label4.Text = "Kayıt bulunamadı veya silinemedi.";
                    }
                    kontrol.verileriTabloyaAktar("SELECT kullaniciAdi AS 'Kullanıcı Adı', ad AS 'İsim', email AS 'E-mail' FROM kullaniciTablosu", dataGridView1);
                }
                catch (Exception ex)
                {
                    label4.Text = "Hata: " + ex.Message;
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                label4.Text = "Lütfen bir kayıt seçin.";
            }
        }

        private DataGridViewRow selectedRow;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Tıklanan hücrenin satırını seç
                // Seçilen satırı selectedRow değişkenine atayabilirsiniz
                selectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }
    }
}
