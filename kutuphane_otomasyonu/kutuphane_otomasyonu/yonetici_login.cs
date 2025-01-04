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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace kutuphane_otomasyonu
{
    public partial class yonetici_login : Form
    {
        public yonetici_login()
        {
            InitializeComponent();
        }
        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        //private yoneticiIslemleri yoneticiislem;
        private void btn_giris_Click(object sender, EventArgs e)
        {
            try
            {
                if(ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }
                string kullaniciAdi = textBox1.Text;
                string sifre = textBox2.Text;

                string sqlquery = "SELECT * FROM yoneticiTablosu " +
                "WHERE kullaniciAdi = @kullaniciAdi AND sifre = @sifre";

                SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.HasRows)
                {
                    label13.Text = "var";
                    // kodun içinde olacak işlemleri yaz
                    yoneticiIslemleri yoneticiislem = new yoneticiIslemleri();
                    yoneticiislem.ShowDialog();
                    //this.Hide();
                }
                else
                { // labela hata mesajı yazdır
                    label13.Text = "yok";
                }

                

            }
            catch (Exception ex) 
            {
                label13.Text = ex.Message;
            }

            finally
            {
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
