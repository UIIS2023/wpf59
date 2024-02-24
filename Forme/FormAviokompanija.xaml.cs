using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFAerodrom.Forme
{
    public partial class FormAviokompanija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormAviokompanija()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
        }

        public FormAviokompanija(bool update, DataRowView row)
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
            this.update = update;
            this.row = row;
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;
                if (update)
                {
                    cmd.Parameters.Add("@aviokompanijaID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE Aviokompanija SET ime=@ime WHERE aviokompanijaID=@aviokompanijaID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Aviokompanija(ime) VALUES (@ime)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Invalid input", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
