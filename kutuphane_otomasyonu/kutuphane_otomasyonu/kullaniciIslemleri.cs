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
    public partial class kullaniciIslemleri : Form
    {
        public kullaniciIslemleri(string kullaniciadi)
        {
            InitializeComponent();
            this.username = kullaniciadi;
        }

        public string username;

        private void kullaniciIslemleri_Load(object sender, EventArgs e)
        {
            label1.Text = username;
            
        }
        private BilgiGuncelleme bilgiGuncelleme;
        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is BilgiGuncelleme)
                return;

            // Mevcut formu kaldır
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);

            bilgiGuncelleme = new BilgiGuncelleme(username);
            bilgiGuncelleme.TopLevel = false;
            bilgiGuncelleme.FormBorderStyle = FormBorderStyle.None;
            bilgiGuncelleme.Dock = DockStyle.Fill;
            panel2.Controls.Add(bilgiGuncelleme);
            bilgiGuncelleme.Show();

        }

        private KullaniciSilme kullaniciSilme;
        private void button5_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is KullaniciSilme)
                return;

            // Mevcut formu kaldır
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);

            kullaniciSilme = new KullaniciSilme(username);
            kullaniciSilme.TopLevel = false;
            kullaniciSilme.FormBorderStyle = FormBorderStyle.None;
            kullaniciSilme.Dock = DockStyle.Fill;
            panel2.Controls.Add(kullaniciSilme);
            kullaniciSilme.Show();
        }

        private KitapArama kitapArama;
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is KitapArama)
                return;

            // Mevcut formu kaldır
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);

            kitapArama = new KitapArama();
            kitapArama.TopLevel = false;
            kitapArama.FormBorderStyle = FormBorderStyle.None;
            kitapArama.Dock = DockStyle.Fill;
            panel2.Controls.Add(kitapArama);
            kitapArama.Show();
        }

        private OduncKitapAlma oduncKitap;
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is OduncKitapAlma)
                return;

            // Mevcut formu kaldır
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);

            oduncKitap = new OduncKitapAlma(username);
            oduncKitap.TopLevel = false;
            oduncKitap.FormBorderStyle = FormBorderStyle.None;
            oduncKitap.Dock = DockStyle.Fill;
            panel2.Controls.Add(oduncKitap);
            oduncKitap.Show();
        }

        private KitapIadeEtme kitapIadeEtme;
        private void button3_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count > 0 && panel2.Controls[0] is KitapIadeEtme)
                return;

            // Mevcut formu kaldır
            if (panel2.Controls.Count > 0)
                panel2.Controls.RemoveAt(0);

            kitapIadeEtme = new KitapIadeEtme(username);
            kitapIadeEtme.TopLevel = false;
            kitapIadeEtme.FormBorderStyle = FormBorderStyle.None;
            kitapIadeEtme.Dock = DockStyle.Fill;
            panel2.Controls.Add(kitapIadeEtme);
            kitapIadeEtme.Show();
        }
    }
}
