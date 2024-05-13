using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kutuphane_otomasyonu
{
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }




        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");
        private kullanici_giris girisFormu;
        private kullanici_uyeOl uyeFormu;

        
        private void btn_login_Click(object sender, EventArgs e)
        {
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel1,girisFormu);
        }

        

        private void btn_signup_Click(object sender, EventArgs e)
        { 
            KontrolEtmeFonksiyonlari.Kontrol.ShowFormInPanel(panel1, uyeFormu);
        }

        
    }
}
