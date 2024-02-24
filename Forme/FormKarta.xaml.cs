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
    public partial class FormKarta : Window
    {

        
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FormKarta()
        {
            InitializeComponent();
            konekcija = kon.CreateConnection();
            PopuniComboBox();
        }


        
        public FormKarta(bool update, DataRowView row)
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
                string putnici = @"SELECT putnikID,ime FROM Putnik";
                SqlDataAdapter adapterPutnik = new SqlDataAdapter(putnici, konekcija);
                DataTable dataTablePutnik = new DataTable();
                adapterPutnik.Fill(dataTablePutnik);
                cbImePutnika.ItemsSource = dataTablePutnik.DefaultView;
                adapterPutnik.Dispose();
                dataTablePutnik.Dispose();

                string tipovi = @"SELECT tipKarteID,klasa FROM TipKarte";
                SqlDataAdapter adapterTip = new SqlDataAdapter(tipovi, konekcija);
                DataTable dataTableTip = new DataTable();
                adapterTip.Fill(dataTableTip);
                cbTipKarte.ItemsSource = dataTableTip.DefaultView;
                adapterTip.Dispose();
                dataTableTip.Dispose();

                string letovi = @"SELECT letID FROM Let";
                SqlDataAdapter adapterLet = new SqlDataAdapter(letovi, konekcija);
                DataTable dataTableLet = new DataTable();
                adapterLet.Fill(dataTableLet);
                cbLet.ItemsSource = dataTableLet.DefaultView;
                adapterLet.Dispose();
                dataTableLet.Dispose();
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

                cmd.Parameters.Add("@putnikID", SqlDbType.Int).Value = cbImePutnika.SelectedValue;
                cmd.Parameters.Add("@tipKarteID", SqlDbType.Int).Value = cbTipKarte.SelectedValue;
                cmd.Parameters.Add("@letID", SqlDbType.Int).Value = cbLet.SelectedValue;
                cmd.Parameters.Add("@cena", SqlDbType.Int).Value = txtCena.Text;
                cmd.Parameters.Add("@sediste", SqlDbType.Int).Value = txtSediste.Text;


                if (update)
                {
                    cmd.Parameters.Add("@kartaID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"UPDATE Karta SET letID=@letID,putnikID=@putnikID,tipKarteID=@tipKarteID,cena=@cena,sediste=@sediste  WHERE kartaID=@kartaID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Karta(putnikID,tipKarteID,letID,cena,sediste) VALUES (@putnikID,@tipKarteID,@letID,@cena,@sediste)";
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
