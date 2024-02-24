using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFAerodrom
{
    public class Konekcija
    {
        public SqlConnection CreateConnection()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"SYSTEM-DS2001\SQLEXPRESS01",
                InitialCatalog = "Aerodrom",
                IntegratedSecurity = true
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;

        }
    }
}
