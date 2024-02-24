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
    public partial class FormStjuardesa : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormStjuardesa()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
        }

        public FormStjuardesa(bool update, DataRowView row)
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
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@plata", SqlDbType.Int).Value = txtPlata.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                if (update)
                {
                    cmd.Parameters.Add("@stjuardesaID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE Stjuardesa SET ime=@ime,prezime=@prezime, jmbg=@jmbg,plata=@plata,kontakt=@kontakt WHERE stjuardesaID=@stjuardesaID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Stjuardesa(ime,prezime,jmbg,plata,kontakt) VALUES (@ime,@prezime,@jmbg,@plata,@kontakt)";
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
