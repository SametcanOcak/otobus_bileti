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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string TheValue
        {
            get { return textBox1.Text; }

        }

        SqlConnection baglanti = new SqlConnection("Data Source =.; Initial Catalog = giris; Integrated Security = True");
        SqlCommand komut;

        string oldText = string.Empty;

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://yardim.obilet.com/hc/article_attachments/6225371968924";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM bilet WHERE koltuk_no = @koltuk_no ", baglanti );
            check_User_Name.Parameters.AddWithValue("@koltuk_no", textBox1.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            if (UserExist > 0) 
            {
                MessageBox.Show("Bu koltuk daha önce alınmış");
            }
            else
            {
                DialogResult = DialogResult.OK;

            }
            baglanti.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                button1.PerformClick();
            }
        }
    }
}
