using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kutuphane_otomasyonu
{
    public partial class yonetici_signup : Form
    {
        public yonetici_signup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");


        private void btn_uyeOl_Click(object sender, EventArgs e)
        {
            string pozisyon = "";

            try
            {
                if(ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }
                pozisyon = textBox3.Text;
                string kullaniciAdi = textBox10.Text;
                string sifre = textBox11.Text;

                string sqlquery = "INSERT into yoneticiTablosu (pozisyon,kullaniciAdi,sifre) " +
                    "VALUES (@pozisyon,@kullaniciAdi,@sifre)";
                SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                komut.Parameters.AddWithValue("@pozisyon", pozisyon);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                label12.Text = pozisyon + " adli kullanici sisteme kaydedildi.";
                komut.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                label12.Text = "hata: " + ex.Message;
            }

            finally
            {
                label12.Text = pozisyon + " adli kullanici sisteme kaydedildi.";
                baglanti.Close();
                textBox3.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
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
            textBox11.PasswordChar = '*';
        }
    }
}
