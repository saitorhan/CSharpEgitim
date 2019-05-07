using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitim.StringSayiDonusum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string metin = textBoxNumber.Text;

            if (metin.Any(c => !Char.IsDigit(c)))
            {
                MessageBox.Show("Hatalı giriş");
                return;
            }
            int sayi = Convert.ToInt32(metin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string metin = textBoxNumber.Text;

            if (metin.Any(c => !Char.IsDigit(c)))
            {
                MessageBox.Show("Hatalı giriş");
                return;
            }

            int sayi = Int32.Parse(metin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string metin = textBoxNumber.Text;
            int sayi;

            bool tryParse = Int32.TryParse(metin, out sayi);
            if (tryParse)
            {
                MessageBox.Show("Doğru format");
            }
            else
            {
                MessageBox.Show("Yanlış format");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string metin = textBoxNumber.Text;

            int sayi = metin.ToInt32OrDefault(-1);
        }
    }
}
