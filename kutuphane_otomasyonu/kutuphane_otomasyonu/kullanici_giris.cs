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
    public partial class kullanici_giris : Form
    {
        public kullanici_giris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");


        private void btn_giris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            //kullanıcılar veritabanı kontrolü
            baglanti.Open();
            string sqlquery = "SELECT * FROM kullaniciTablosu " +
                "WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";

            SqlCommand komut = new SqlCommand(sqlquery, baglanti);
            komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", sifre);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.HasRows)
            {
                label13.Text = "var";
                // kodun içinde olacak işlemleri yaz

                kullaniciIslemleri kullaniciForm = new kullaniciIslemleri(kullaniciAdi);
                kullaniciForm.ShowDialog();
                //this.Hide();

            }
            else
            { // labela hata mesajı yazdır
                label13.Text = "yok";
            }

            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";


        }

        
    }
}
