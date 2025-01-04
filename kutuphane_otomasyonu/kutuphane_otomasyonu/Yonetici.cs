using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
        }
        public static string connectionString = ConfigurationManager.ConnectionStrings["kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connectionString);

        private yonetici_login adminlogin;
        private void btn_yoneticilogin_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel1, adminlogin);
        }

        private yonetici_signup adminsignup;
        private void btn_yoneticiSignUp_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel1, adminsignup);
        }
    }
}
