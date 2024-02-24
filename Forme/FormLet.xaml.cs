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

    public partial class FormLet : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormLet()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
            PopuniComboBox();
        }

        public FormLet(bool update, DataRowView row)
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

                txtvremeDolaska.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                txtvremePolaska.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                konekcija.Open();
                string piloti = @"SELECT pilotID,ime FROM Pilot";
                SqlDataAdapter adapter = new SqlDataAdapter(piloti, konekcija);
                DataTable dataTablePiloti = new DataTable();
                adapter.Fill(dataTablePiloti);
                cbImePilota.ItemsSource = dataTablePiloti.DefaultView;
                adapter.Dispose();
                dataTablePiloti.Dispose();

                string stjuardese = @"SELECT stjuardesaID,ime FROM Stjuardesa";
                SqlDataAdapter adapterStjuardesa = new SqlDataAdapter(stjuardese, konekcija);
                DataTable dataTableStjuardesa = new DataTable();
                adapterStjuardesa.Fill(dataTableStjuardesa);
                cbImeStjuardese.ItemsSource = dataTableStjuardesa.DefaultView;
                adapterStjuardesa.Dispose();
                dataTableStjuardesa.Dispose();

                string avioni = @"SELECT avionID,model FROM Avion";
                SqlDataAdapter adapterAvioni = new SqlDataAdapter(avioni, konekcija);
                DataTable dataTableAvioni = new DataTable();
                adapterAvioni.Fill(dataTableAvioni);
                cbAvion.ItemsSource = dataTableAvioni.DefaultView;
                adapterAvioni.Dispose();
                dataTableAvioni.Dispose();
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

                cmd.Parameters.Add("@pilotID", SqlDbType.Int).Value = cbImePilota.SelectedValue;
                cmd.Parameters.Add("@stjuardesaID", SqlDbType.Int).Value = cbImeStjuardese.SelectedValue;
                cmd.Parameters.Add("@avionID", SqlDbType.Int).Value = cbAvion.SelectedValue;
                cmd.Parameters.Add("@brojPutnika", SqlDbType.Int).Value = txtBrojPutnika.Text;
                cmd.Parameters.Add("@vremePolaska", SqlDbType.DateTime).Value = txtvremePolaska.Text;
                cmd.Parameters.Add("@vremeDolaska", SqlDbType.DateTime).Value = txtvremeDolaska.Text;
                cmd.Parameters.Add("@destinacija", SqlDbType.NVarChar).Value = txtDestinacija.Text;


                if (update)
                {
                    cmd.Parameters.Add("@letID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE Let SET pilotID=@pilotID,stjuardesaID=@stjuardesaID,avionID=@avionID,brojPutnika=@brojPutnika,vremePolaska=@vremePolaska,vremeDolaska=@vremeDolaska,destinacija=@destinacija  WHERE letID=@letID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Let(pilotID,stjuardesaID,avionID,brojPutnika,vremePolaska,vremeDolaska,destinacija) VALUES (@pilotID,@stjuardesaID,@avionID,@brojPutnika,@vremePolaska,@vremeDolaska,@destinacija)";
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
