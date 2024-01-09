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

namespace otobusbileti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source =.; Initial Catalog = giris; Integrated Security = True");
        public static string k_adi = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://previews.123rf.com/images/borisnd/borisnd1805/borisnd180500065/102584829-bus-travel-company-logo-design-emblem-of-excursion-or-tourist-bus-rental-organisation-travel.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("select * from yonetici where k_adi= '" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", baglanti);
            SqlDataReader drs = giris.ExecuteReader();
            if (drs.Read())
            {
                k_adi = drs["k_adi"].ToString();
                MessageBox.Show("Giriş Başarılı.");
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış !");
            }
            baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
