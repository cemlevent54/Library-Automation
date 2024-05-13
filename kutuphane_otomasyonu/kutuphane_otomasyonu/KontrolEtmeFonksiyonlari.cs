using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kutuphane_otomasyonu
{
    internal class KontrolEtmeFonksiyonlari
    {
        public class Kontrol
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-0PCHDQV;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;Encrypt=False");

            public static bool IsValidEmail(string email)
            {
                // Düzenli ifade (regex) kullanarak email geçerliliğini kontrol etme
                string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(email) && email.EndsWith("gmail.com", StringComparison.OrdinalIgnoreCase);
            }

            public static bool IsValidUsername(string username)
            {
                // Düzenli ifade (regex) kullanarak kullanıcı adı geçerliliğini kontrol etme
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(username);
            }

            public static bool IsValidPassword(string password)
            {
                // Düzenli ifade (regex) kullanarak şifre geçerliliğini kontrol etme
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(password);
            }
            public static void ShowFormInPanel<T>(Panel panel, T form = null) where T : Form, new()
            {
                if (panel.Controls.Count > 0 && panel.Controls[0] is T)
                    return;

                // Mevcut formu kaldır
                if (panel.Controls.Count > 0)
                    panel.Controls.RemoveAt(0);

                form = new T();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panel.Controls.Add(form);
                form.Show();

            }

            public void verileriTabloyaAktar(string sqlquery, DataGridView dataGridView)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand command = new SqlCommand(sqlquery, baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            public void verileriTabloyaAktar(string sqlquery, string aranan,DataGridView dataGridView)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand command = new SqlCommand(sqlquery, baglanti);
                command.Parameters.Add("@aranan", aranan);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }

            public void veriArama(string sqlquery, string arama, DataGridView dataGridView)
            {
                if (ConnectionState.Closed == baglanti.State)
                {
                    baglanti.Open();
                }

                SqlCommand komut = new SqlCommand(sqlquery, baglanti);
                komut.Parameters.Add("@aranan", "%"+arama +"%");
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
                baglanti.Close();
            }

        }
        
    }
}
