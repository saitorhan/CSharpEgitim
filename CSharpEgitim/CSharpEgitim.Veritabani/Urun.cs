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

namespace CSharpEgitim.Veritabani
{
    public partial class Urun : Form
    {
        public bool Result { get; set; }
        public int Id { get; set; }
        public bool Update { get; set; }
        public Urun()
        {
            InitializeComponent();
            Update = false;
        }

        public Urun(int UrunId)
        {
            InitializeComponent();
            Update = true;
            Id = UrunId;

            SqlConnection sqlConnection = new SqlConnection(GlobalVariables.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("select Name from Urunler where Id = @id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", Id);

            try
            {
                sqlConnection.Open();
                string urunName = sqlCommand.ExecuteScalar().ToString();
                textBoxName.Text = urunName;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata oluştu");
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(GlobalVariables.ConnectionString);
            SqlCommand sqlCommand;

            if (Update)
            {
                sqlCommand = new SqlCommand("UPDATE Urunler set Name = @ad where Id = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ad", textBoxName.Text);
                sqlCommand.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                sqlCommand = new SqlCommand("INSERT INTO Urunler(Name) values(@ad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ad", textBoxName.Text);
            }


            try
            {
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                Result = true;
                MessageBox.Show("Ürün kaydedildi");
                Close();
            }
            catch (Exception exception)
            {
                Result = false;
                MessageBox.Show("Ürün kaydedilmedi");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }

        }
    }
}
