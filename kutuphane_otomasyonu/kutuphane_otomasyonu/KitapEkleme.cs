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
using System.Configuration;

namespace kutuphane_otomasyonu
{
    public partial class KitapEkleme : Form
    {
        public KitapEkleme()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);


        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if(ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }
                string sqlquery = "INSERT into kitapTablosu (id,kitapAdi,yazar,tur,sayfaSayisi,basimYili,yayinevi,kitapAdet) " +
                "VALUES (@id,@kitapAdi,@yazar,@tur,@sayfaSayisi,@basimYili,@yayinevi,@kitapAdet)";
                SqlCommand komut = new SqlCommand(sqlquery, baglanti);

                komut.Parameters.AddWithValue("@id", textBox1.Text);
                komut.Parameters.AddWithValue("@kitapAdi", textBox2.Text);
                komut.Parameters.AddWithValue("@yazar", textBox3.Text);
                komut.Parameters.AddWithValue("@tur", textBox4.Text);
                komut.Parameters.AddWithValue("sayfaSayisi", textBox5.Text);
                komut.Parameters.AddWithValue("@basimYili", textBox6.Text);
                komut.Parameters.AddWithValue("@yayinevi", textBox7.Text);
                komut.Parameters.AddWithValue("@kitapAdet", textBox8.Text);
                komut.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata var " +  ex.Message,"hata");
            }
            finally
            {
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }
    }
}
