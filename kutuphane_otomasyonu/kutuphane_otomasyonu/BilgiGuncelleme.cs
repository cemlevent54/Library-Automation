using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace kutuphane_otomasyonu
{
    public partial class BilgiGuncelleme : Form
    {
        public BilgiGuncelleme(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        public string username;

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void BilgiGuncelleme_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string kullaniciAdi = username;
                string sqlquery = "SELECT * FROM kullaniciTablosu WHERE kullaniciAdi=@kullaniciAdi";
                SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read()) {
                    textBox10.Text = oku["kullaniciAdi"].ToString().Replace(" ", "");
                    textBox11.Text = oku["sifre"].ToString().Replace(" ","");
                    textBox7.Text = oku["telefonNumarasi"].ToString().Replace(" ", "");
                    textBox8.Text = oku["email"].ToString().Replace(" ", "");
                    textBox9.Text = oku["adres"].ToString();
                }
                oku.Close();
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgi alınırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                
                baglanti.Close();
            }



        }

        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if(ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }
                string sqlquery = "UPDATE kullaniciTablosu set kullaniciAdi=@kullaniciAdi, " +
                    "sifre=@sifre, telefonNumarasi=@telefonNumarasi, email=@email, adres=@adres " +
                    "WHERE kullaniciAdi=@kullaniciAdi ";
                SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                komut.Parameters.AddWithValue("@kullaniciAdi", textBox10.Text);
                komut.Parameters.AddWithValue("@sifre", textBox11.Text);
                komut.Parameters.AddWithValue("@telefonNumarasi", textBox7.Text);
                komut.Parameters.AddWithValue("@email", textBox8.Text);
                komut.Parameters.AddWithValue("@adres", textBox9.Text);

                komut.ExecuteNonQuery();
                label3.Text = "Güncelleme başarıyla tamamlandi.";
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme yapılırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {

                MessageBox.Show("Lütfen sadece rakam girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 11)
            {
                MessageBox.Show("Telefon numarası 11 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
        }

        

        private void textBox8_Leave(object sender, EventArgs e)
        {
            string email = textBox8.Text;

            if (!KontrolEtmeFonksiyonlari.Kontrol.IsValidEmail(email))
            {
                MessageBox.Show("Geçerli bir email adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
        }

        

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (!KontrolEtmeFonksiyonlari.Kontrol.IsValidUsername(textBox10.Text))
            {
                MessageBox.Show("Kullanıcı adı en az bir büyük harf, bir küçük harf ve bir sayı içermelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox10.Focus();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.PasswordChar = '*';
        }

        

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (!KontrolEtmeFonksiyonlari.Kontrol.IsValidPassword(textBox11.Text))
            {
                MessageBox.Show("Şifre en az bir küçük harf, bir büyük harf, bir özel karakter ve bir sayı içermelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox11.Focus();
            }
        }

        
    }
}
