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
    public partial class KitapSilme : Form
    {
        public KitapSilme()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);
        KontrolEtmeFonksiyonlari.Kontrol kontrol = new KontrolEtmeFonksiyonlari.Kontrol();

        

        

        private void KitapSilme_Load(object sender, EventArgs e)
        {
            //verileriYukle();
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu";
            kontrol.verileriTabloyaAktar(sqlquery, dataGridView1);
        }

        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox4.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE kitapAdi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE yazar LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE tur LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text;
            string sqlquery = "SELECT id AS 'Kitap ID',kitapAdi AS 'Kitap Adı', tur AS 'Tür', yazar AS 'Yazar', yayinevi AS 'Yayınevi' FROM kitapTablosu WHERE yayinevi LIKE @aranan";
            kontrol.veriArama(sqlquery, searchText, dataGridView1);
        }

        private string ReturnIdInfo_dgw()
        {
            string id = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = selectedRow.Cells["Kitap ID"].Value.ToString(); // Kitap ID sütununun adını doğru şekilde değiştirin.
            }
            return id;
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            string id = ReturnIdInfo_dgw();

            if (id != "")
            {
                try
                {
                    if(ConnectionState.Closed == baglanti.State)
                    {
                        baglanti.Open();
                    }
                    
                    string sqlquery = "DELETE FROM kitapTablosu WHERE id=@id";
                    SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    lbl_result.Text = "Kayıt silindi.";
                }
                catch (Exception ex)
                {
                    lbl_result.Text = "Hata: " + ex.Message;
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                lbl_result.Text = "Lütfen bir kayıt seçin.";
            }
        }
        private DataGridViewRow selectedRow;

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
