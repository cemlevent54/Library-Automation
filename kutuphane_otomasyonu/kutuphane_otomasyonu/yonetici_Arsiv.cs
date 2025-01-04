using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class yonetici_Arsiv : Form
    {
        public yonetici_Arsiv()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();
        private void yonetici_Arsiv_Load(object sender, EventArgs e)
        {
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', id AS 'ID',kitapAdi AS 'Kitap Adı',oduncTarih AS 'Ödünç Alınan Tarih', iadeTarih AS 'İade Edilen Tarih' FROM oduncKitapArsivi";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            // search by kullaniciAdi
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', id AS 'ID',kitapAdi AS 'Kitap Adı',oduncTarih AS 'Ödünç Alınan Tarih', iadeTarih AS 'İade Edilen Tarih' FROM oduncKitapArsivi WHERE kullaniciAdi LIKE @aranan;";
            kontrol.veriArama(sqlquery, textBox1.Text, dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // search by ID
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', id AS 'ID',kitapAdi AS 'Kitap Adı',oduncTarih AS 'Ödünç Alınan Tarih', iadeTarih AS 'İade Edilen Tarih' FROM oduncKitapArsivi WHERE id LIKE @aranan;";
            kontrol.veriArama(sqlquery, textBox2.Text, dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // search by kitapAdi
            string sqlquery = "SELECT kullaniciAdi AS 'Kullanıcı Adı', id AS 'ID',kitapAdi AS 'Kitap Adı',oduncTarih AS 'Ödünç Alınan Tarih', iadeTarih AS 'İade Edilen Tarih' FROM oduncKitapArsivi WHERE kitapAdi LIKE @aranan;";
            kontrol.veriArama(sqlquery, textBox3.Text, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            label1.Text = row.Cells["Kullanıcı Adı"].Value.ToString();
        }
    }
}
