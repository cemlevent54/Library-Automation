using System;
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
    public partial class yoneticiIslemleri : Form
    {
        public yoneticiIslemleri()
        {
            InitializeComponent();
        }

        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private KitapEkleme kitapEkleme;
        private void btn_kitapEkle_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kitapEkleme);
        }

        private KitapGoruntuleme kitapGoruntuleme;
        private void btn_KitapGoruntule_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kitapGoruntuleme);
        }

        private KullaniciGoruntuleme kullaniciGoruntuleme;
        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kullaniciGoruntuleme);
        }

        private KitapSilme kitapSilme;
        private void btn_kitapSil_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kitapSilme);
        }

        private yonetici_kullaniciSilme kullaniciSil;
        private void btn_sil_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kullaniciSil);

        }

        private yonetici_kullaniciEkleme kullaniciEkleme;
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, kullaniciEkleme);
        }

        ////--------------

        private OduncKitapTakip oduncKitapTakip;
        private void btn_odunc_Click(object sender, EventArgs e)
        {
            // kullaniciAdi, ID, kitapAdı ile listview oluştur. ıd'den kitapadına ulaş
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, oduncKitapTakip);
        }

        private yonetici_Arsiv yonetici_Arsiv;
        private void btn_odunKitapArsivi_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel3, yonetici_Arsiv);
        }

        
    }
}
