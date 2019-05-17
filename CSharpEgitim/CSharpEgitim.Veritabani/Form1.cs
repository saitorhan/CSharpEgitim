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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        void RefreshData()
        {
            dataGridViewRecords.Rows.Clear();

            SqlConnection sqlConnection = new SqlConnection(GlobalVariables.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("select Id, Name from Urunler", sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                dataGridViewRecords.Rows.Add(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1));
            }
            sqlConnection.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.ShowDialog();

            if (urun.Result)
            {
                RefreshData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count == 0)
            {
                return;
            }

            object value = dataGridViewRecords.SelectedRows[0].Cells[0].Value;

            Urun urun = new Urun(Convert.ToInt32(value));
            urun.ShowDialog();

            if (urun.Result)
            {
                RefreshData();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count == 0)
            {
                return;
            }

            object value = dataGridViewRecords.SelectedRows[0].Cells[0].Value;

            SqlConnection sqlConnection = new SqlConnection(GlobalVariables.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("delete Urunler where Id = @id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", value);


            try
            {
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Ürün silindi");
                RefreshData();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ürün silinemedi");
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
