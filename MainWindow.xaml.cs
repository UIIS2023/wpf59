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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFAerodrom.Forme;

namespace WPFAerodrom
{
    
    public partial class MainWindow : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private string ucitanaTabela;
        private bool update;
        private DataRowView row;



        //Pristupanje podacima iz baze (Add, Update, Delete)
        #region Select upiti
        private static string aviokompanijaSelect = @"SELECT aviokompanijaID as ID, ime as 'Naziv aviokompanije' FROM Aviokompanija";
        private static string avionSelect = @"SELECT avionID as ID, model as 'Model aviona', kapacitet as 'Kapacitet', aviokompanija.ime as 'Naziv aviokompanije' FROM Avion JOIN Aviokompanija ON Avion.aviokompanijaID=Aviokompanija.aviokompanijaID";
        private static string pilotSelect = @"SELECT pilotID as ID, ime + ' ' + prezime as 'Ime pilota', jmbg as 'JMBG', kontakt as 'Kontakt', plata as 'Plata' FROM Pilot";
        private static string stjuardesaSelect = @"SELECT stjuardesaID as ID, ime + ' ' + prezime as 'Ime stjuardese', jmbg as 'JMBG', kontakt as 'Kontakt', plata as 'Plata' FROM Stjuardesa";
        private static string kartaSelect = @"SELECT kartaID as ID, cena as 'Cena karte', Let.letID as 'ID leta', sediste as 'Sediste na avionu', Putnik.ime + ' ' + Putnik.prezime as 'Ime putnika', tipKarte.klasa as 'Klasa leta', Let.destinacija as 'Destinacija' FROM Karta
                                              JOIN Putnik ON Karta.putnikID = Putnik.putnikID
                                              JOIN Let ON Karta.letID = Let.letID
                                              JOIN TipKarte ON Karta.tipKarteID=TipKarte.tipKarteID";
        private static string letSelect = @"SELECT letID as ID, Pilot.ime + ' ' + Pilot.prezime as 'Ime pilota', Stjuardesa.ime + ' ' + Stjuardesa.prezime as 'Ime stjuardese', Avion.model as 'Model aviona',brojPutnika as 'Broj putnika', vremePolaska as 'Vreme polaska', vremeDolaska as 'Vreme dolaska', destinacija as 'Destinacija leta' FROM Let
                                            JOIN Pilot ON Let.pilotID=Pilot.pilotID
                                            JOIN Stjuardesa ON Let.stjuardesaID=Stjuardesa.stjuardesaID
                                            JOIN Avion ON Let.avionID=Avion.avionID";
        private static string tipKarteSelect = @"SELECT tipKarteID as ID, klasa as 'Klasa' FROM TipKarte";
        private static string putnikSelect = @"SELECT putnikID as ID, ime + ' ' + prezime as 'Ime putnika', kontakt as 'Kontakt' FROM Putnik";
        #endregion
        #region Select upiti sa uslovom
        private static string selectUslovPilot = @"SELECT * FROM Pilot WHERE pilotID=";
        private static string selectUslovPutnik = @"SELECT * FROM Putnik WHERE putnikID=";
        private static string selectUslovStjuardesa = @"SELECT * FROM Stjuardesa WHERE stjuardesaID=";
        private static string selectUslovAvion = @"SELECT * FROM Avion WHERE avionID=";
        private static string selectUslovAviokompanija = @"SELECT * FROM Aviokompanija WHERE aviokompanijaID=";
        private static string selectUslovKarta = @"SELECT * FROM Karta WHERE kartaID=";
        private static string selectUslovTipKarte = @"SELECT * FROM TipKarte WHERE tipKarteID=";
        private static string selectUslovLet = @"SELECT * FROM Let WHERE letID=";

        #endregion
        #region Delete upiti
        private static string pilotDelete = @"DELETE FROM Pilot where pilotID=";
        private static string putnikDelete = @"DELETE FROM Putnik where putnikID=";
        private static string avionDelete = @"DELETE FROM Avion where avionID=";
        private static string stjuardesaDelete = @"DELETE FROM Stjuardesa where stjuardesaID=";
        private static string aviokompanijaDelete = @"DELETE FROM Aviokompanija where aviokompanijaID=";
        private static string kartaDelete = @"DELETE FROM Karta WHERE kartaID=";
        private static string tipKarteDelete = @"DELETE FROM TipKarte WHERE tipKarteID=";
        private static string letDelete = @"DELETE FROM Let where letID=";
        #endregion



        //Konstruktor koji se pokrece kada se pokrene program, ucitava tabelu Let i inicijalizuje xaml 
        public MainWindow()
        {         
            InitializeComponent();
            konekcija = kon.CreateConnection();
            UcitajPodatke(letSelect);        
        }



        
        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Greska pri ucitavanju tabele", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }



        
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(pilotSelect))
            {
                prozor = new FormPilot();
                prozor.ShowDialog();
                UcitajPodatke(pilotSelect);
            }
            else if (ucitanaTabela.Equals(putnikSelect))
            {
                prozor = new FormPutnik();
                prozor.ShowDialog();
                UcitajPodatke(putnikSelect);
            }
            else if (ucitanaTabela.Equals(avionSelect))
            {
                prozor = new FormAvion();
                prozor.ShowDialog();
                UcitajPodatke(avionSelect);
            }
            else if (ucitanaTabela.Equals(stjuardesaSelect))
            {
                prozor = new FormStjuardesa();
                prozor.ShowDialog();
                UcitajPodatke(stjuardesaSelect);
            }
            else if (ucitanaTabela.Equals(aviokompanijaSelect))
            {
                prozor = new FormAviokompanija();
                prozor.ShowDialog();
                UcitajPodatke(aviokompanijaSelect);
            }
            else if (ucitanaTabela.Equals(letSelect))
            {
                prozor = new FormLet();
                prozor.ShowDialog();
                UcitajPodatke(letSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                prozor = new FormKarta();
                prozor.ShowDialog();
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                prozor = new FormTipKarte();
                prozor.ShowDialog();
                UcitajPodatke(tipKarteSelect);
            }
        }

        
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(pilotSelect))
            {
                PopuniFormu(selectUslovPilot);
                UcitajPodatke(pilotSelect);
            }
            else if (ucitanaTabela.Equals(putnikSelect))
            {
                PopuniFormu(selectUslovPutnik);
                UcitajPodatke(putnikSelect);
            }
            else if (ucitanaTabela.Equals(avionSelect))
            {
                PopuniFormu(selectUslovAvion);
                UcitajPodatke(avionSelect);
            }
            else if (ucitanaTabela.Equals(stjuardesaSelect))
            {
                PopuniFormu(selectUslovStjuardesa);
                UcitajPodatke(stjuardesaSelect);
            }
            else if (ucitanaTabela.Equals(aviokompanijaSelect))
            {
                PopuniFormu(selectUslovAviokompanija);
                UcitajPodatke(aviokompanijaSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                PopuniFormu(selectUslovKarta);
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                PopuniFormu(selectUslovTipKarte);
                UcitajPodatke(tipKarteSelect);
            }
            else if (ucitanaTabela.Equals(letSelect))
            {
                PopuniFormu(selectUslovLet);
                UcitajPodatke(letSelect);
            }
        }

        
        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(pilotSelect))
            {
                ObrisiZapis(pilotDelete);
                UcitajPodatke(pilotSelect);
            }
            else if (ucitanaTabela.Equals(putnikSelect))
            {
                ObrisiZapis(putnikDelete);
                UcitajPodatke(putnikSelect);
            }
            else if (ucitanaTabela.Equals(avionSelect))
            {
                ObrisiZapis(avionDelete);
                UcitajPodatke(avionSelect);
            }
            else if (ucitanaTabela.Equals(stjuardesaSelect))
            {
                ObrisiZapis(stjuardesaDelete);
                UcitajPodatke(stjuardesaSelect);
            }
            else if (ucitanaTabela.Equals(aviokompanijaSelect))
            {
                ObrisiZapis(aviokompanijaDelete);
                UcitajPodatke(aviokompanijaSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                ObrisiZapis(kartaDelete);
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(tipKarteSelect))
            {
                ObrisiZapis(tipKarteDelete);
                UcitajPodatke(tipKarteSelect);
            }
            else if (ucitanaTabela.Equals(letSelect))
            {
                ObrisiZapis(letDelete);
                UcitajPodatke(letSelect);
            }
        }



        
        private void btnPutnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(putnikSelect);
        }
        private void btnPilot_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(pilotSelect);
        }
        private void btnAvion_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(avionSelect);
        }
        private void btnStjuardesa_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(stjuardesaSelect);
        }
        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kartaSelect);
        }
        private void btnAviokompanija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(aviokompanijaSelect);
        }
        private void btnLet_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(letSelect);
        }
        private void btnTipKarte_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(tipKarteSelect);
        }

        
        private void PopuniFormu(object selectUslov)
        {
            try
            {
                konekcija.Open();
                update = true;
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Dispose();
                if (reader.Read())
                {
                    if (ucitanaTabela.Equals(putnikSelect))
                    {
                        FormPutnik formPutnik = new FormPutnik(update, row);
                        formPutnik.txtIme.Text = reader["ime"].ToString();
                        formPutnik.txtPrezime.Text = reader["prezime"].ToString();
                        formPutnik.txtKontakt.Text = reader["kontakt"].ToString();
                        formPutnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(pilotSelect))
                    {
                        FormPilot formPilot = new FormPilot(update, row);
                        formPilot.txtIme.Text = reader["ime"].ToString();
                        formPilot.txtPrezime.Text = reader["prezime"].ToString();
                        formPilot.txtJMBG.Text = reader["jmbg"].ToString();
                        formPilot.txtPlata.Text = reader["plata"].ToString();
                        formPilot.txtKontakt.Text = reader["kontakt"].ToString();
                        formPilot.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(stjuardesaSelect))
                    {
                        FormStjuardesa formStjuardesa = new FormStjuardesa(update, row);
                        formStjuardesa.txtIme.Text = reader["ime"].ToString();
                        formStjuardesa.txtPrezime.Text = reader["prezime"].ToString();
                        formStjuardesa.txtJMBG.Text = reader["jmbg"].ToString();
                        formStjuardesa.txtPlata.Text = reader["plata"].ToString();
                        formStjuardesa.txtKontakt.Text = reader["kontakt"].ToString();
                        formStjuardesa.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(aviokompanijaSelect))
                    {
                        FormAviokompanija formAviokompanija = new FormAviokompanija(update, row);
                        formAviokompanija.txtIme.Text = reader["ime"].ToString();
                        formAviokompanija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(tipKarteSelect))
                    {
                        FormTipKarte formTipKarte = new FormTipKarte(update, row);
                        formTipKarte.txtKlasa.Text = reader["klasa"].ToString();
                        formTipKarte.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(avionSelect))
                    {
                        FormAvion formAvion = new FormAvion(update, row);
                        formAvion.txtModel.Text = reader["model"].ToString();
                        formAvion.txtKapacitet.Text = reader["kapacitet"].ToString();
                        formAvion.cbImeAviokompanije.SelectedValue = reader["aviokompanijaID"].ToString();
                        formAvion.ShowDialog();
                    }            
                    else if (ucitanaTabela.Equals(letSelect))
                    {
                        FormLet formLet = new FormLet(update, row);
                        formLet.txtBrojPutnika.Text = reader["brojPutnika"].ToString();
                        formLet.txtDestinacija.Text = reader["destinacija"].ToString();
                        formLet.cbAvion.SelectedValue = reader["avionID"].ToString();
                        formLet.cbImePilota.SelectedValue = reader["pilotID"].ToString();
                        formLet.cbImeStjuardese.SelectedValue = reader["stjuardesaID"].ToString();
                        formLet.txtvremeDolaska.Text = reader["vremeDolaska"].ToString();
                        formLet.txtvremePolaska.Text = reader["vremePolaska"].ToString();
                        formLet.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kartaSelect))
                    {
                        FormKarta formKarta = new FormKarta(update, row);
                        formKarta.txtCena.Text = reader["cena"].ToString();
                        formKarta.txtSediste.Text = reader["sediste"].ToString();
                        formKarta.cbImePutnika.SelectedValue = reader["putnikID"].ToString();
                        formKarta.cbTipKarte.SelectedValue = reader["tipKarteID"].ToString();
                        formKarta.cbLet.SelectedValue = reader["letID"].ToString();
                        formKarta.ShowDialog();
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        

       

        private void ObrisiZapis(string deleteUslov)
        {
            try
            {
                konekcija.Open();
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = deleteUslov + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
