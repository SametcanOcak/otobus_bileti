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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source =.; Initial Catalog = giris; Integrated Security = True");
        SqlCommand komut;
        int bilet_fiyat = 80;
        string ucret;
        string oldtext = string.Empty;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Tüm bilgileri doldurmanız gerekiyor !");
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into bilet (ad,soyad,tc,yas,telefon,cinsiyet,nereden,nereye,saat,tarih,fiyat,koltuk_no) VALUES (@ad,@soyad,@tc,@yas,@telefon,@cinsiyet,@nereden,@nereye,@saat,@tarih,@fiyat,@koltuk_no)", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
                komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@tc", textBox1.Text);
                komut.Parameters.AddWithValue("@yas", textBox4.Text);
                komut.Parameters.AddWithValue("@telefon", textBox5.Text);
                komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                komut.Parameters.AddWithValue("@nereden", comboBox2.Text);
                komut.Parameters.AddWithValue("@nereye", comboBox3.Text);
                komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@fiyat", textBox7.Text);
                komut.Parameters.AddWithValue("@koltuk_no", textBox6.Text);
                komut.Parameters.AddWithValue("@saat", comboBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Biletiniz başarılı bir şekilde eklenmiştir. İyi yolculuklar dileriz.");



            }
            baglanti.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Form2_Load(this,new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form4 form2 = new Form4())
            {
                if (form2.ShowDialog()==DialogResult.OK)
                {
                    textBox6.Text = form2.TheValue;
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ucret = bilet_fiyat.ToString();
            textBox7.Text = ucret + " TL ";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
