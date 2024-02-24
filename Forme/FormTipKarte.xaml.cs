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
    public partial class FormTipKarte : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormTipKarte()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
        }

        public FormTipKarte(bool update, DataRowView row)
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

                cmd.Parameters.Add("@klasa", SqlDbType.NVarChar).Value = txtKlasa.Text;
                if (update)
                {
                    cmd.Parameters.Add("@tipKarteID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE TipKarte SET klasa=@klasa WHERE tipKarteID=@tipKarteID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO TipKarte(klasa) VALUES (@klasa)";
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
