using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitim.KimlikDogrulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NufusMudurluk.KPSPublicSoapClient servis = new NufusMudurluk.KPSPublicSoapClient();
            long kimlkNo = long.Parse(textBoxKimlikNo.Text);
            int dYil = Int32.Parse(textBoxDogumYil.Text);
            bool sonuc = servis.TCKimlikNoDogrula(kimlkNo, textBoxAd.Text, textBoxSoyad.Text, dYil);

            MessageBox.Show(sonuc.ToString());
        }
    }
}
