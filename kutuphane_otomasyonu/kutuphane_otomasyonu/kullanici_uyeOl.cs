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
    public partial class kullanici_uyeOl : Form
    {
        public kullanici_uyeOl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");


        private void btn_uyeOl_Click(object sender, EventArgs e)
        {
            string adi = textBox4.Text;
            string soyadi = textBox3.Text;
            // datetime ile doğum tarihi al
            string dogumtarihi;
            DateTime tarih = dateTimePicker1.Value;
            dogumtarihi = tarih.ToString("dd.MM.yyyy");
            string cinsiyet = "";
            if (radioButton1.Checked) cinsiyet = radioButton1.Text;
            else if (radioButton2.Checked) cinsiyet = radioButton2.Text;
            string telefonNumarasi = textBox7.Text;
            string email = textBox8.Text;
            string adres = textBox9.Text;
            string kullaniciAdi = textBox10.Text;
            string sifre = textBox11.Text;

            // veritabanına ekleme
            baglanti.Open();
            string sqlquery = "INSERT into kullaniciTablosu " +
                "(ad,soyad,dogumTarihi,cinsiyet,telefonNumarasi,email,adres,kullaniciAdi,sifre) " +
                "VALUES (@ad,@soyad,@dogumTarihi,@cinsiyet,@telefonNumarasi,@email,@adres,@kullaniciAdi,@sifre)";
            SqlCommand komut = new SqlCommand(sqlquery, baglanti);

            komut.Parameters.AddWithValue("@ad", adi);
            komut.Parameters.AddWithValue("@soyad", soyadi);
            komut.Parameters.AddWithValue("@dogumTarihi", dogumtarihi);
            komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@telefonNumarasi", telefonNumarasi);
            komut.Parameters.AddWithValue("@email", email);
            komut.Parameters.AddWithValue("@adres", adres);
            komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", sifre);



            komut.ExecuteNonQuery();

            baglanti.Close();

            label12.Text = adi + " adli kullanici sisteme kaydedildi.";
            //
            textBox4.Text = "";
            textBox3.Text = "";
            dogumtarihi = "";
            cinsiyet = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {

                MessageBox.Show("Lütfen ad alanına sayı girmeyin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {

                MessageBox.Show("Lütfen soyad alanına sayı girmeyin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                e.Handled = true;
            }

            else
            {
                e.Handled = false;
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



        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (!KontrolEtmeFonksiyonlari.Kontrol.IsValidPassword(textBox11.Text))
            {
                MessageBox.Show("Şifre en az bir küçük harf, bir büyük harf, bir özel karakter ve bir sayı içermelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox11.Focus();
            }
        }



        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //textBox11.UseSystemPasswordChar = true;
            textBox11.PasswordChar = '*';
        }
    }
}
