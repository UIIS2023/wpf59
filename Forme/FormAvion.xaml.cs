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
    public partial class FormAvion : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormAvion()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
            PopuniComboBox();
        }

        public FormAvion(bool update, DataRowView row)
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
            this.update = update;
            this.row = row;
            PopuniComboBox();
        }

        private void PopuniComboBox()
        {
            try
            {
                konekcija.Open();
                string aviokompanije = @"SELECT aviokompanijaID,ime FROM Aviokompanija";
                SqlDataAdapter adapter = new SqlDataAdapter(aviokompanije, konekcija);
                DataTable dataTableAviokompanije = new DataTable();
                adapter.Fill(dataTableAviokompanije);
                cbImeAviokompanije.ItemsSource = dataTableAviokompanije.DefaultView;
                adapter.Dispose();
                dataTableAviokompanije.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno upisivanje vrednosti u ComboBox", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

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

                cmd.Parameters.Add("@model", SqlDbType.NVarChar).Value = txtModel.Text;
                cmd.Parameters.Add("@kapacitet", SqlDbType.NVarChar).Value = txtKapacitet.Text;
                cmd.Parameters.Add("@aviokompanijaID", SqlDbType.Int).Value = cbImeAviokompanije.SelectedValue;
                if (update)
                {
                    cmd.Parameters.Add("@avionID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE Avion SET model=@model,kapacitet=@kapacitet,aviokompanijaID=@aviokompanijaID WHERE avionID=@avionID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Avion(model,kapacitet,aviokompanijaID) VALUES (@model,@kapacitet,@aviokompanijaID)";
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
