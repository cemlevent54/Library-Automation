using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void btn_kullanici_Click(object sender, EventArgs e)
        {
            Kullanici kullaniciFormu = new Kullanici();
            kullaniciFormu.ShowDialog();
            //this.Hide();
        }

        private void btn_yonetici_Click(object sender, EventArgs e)
        {
            Yonetici yoneticiFormu = new Yonetici();
            yoneticiFormu.ShowDialog();
            //this.Hide();
        }
    }
}
