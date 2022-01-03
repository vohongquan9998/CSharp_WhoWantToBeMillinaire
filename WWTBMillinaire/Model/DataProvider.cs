using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace WWTBMillinaire.Model
{
    class DataProvider
    {
        private SqlConnection con;
        string connectionString = ConfigurationManager.ConnectionStrings["A"].ConnectionString.ToString();

        public SqlConnection Con { get => con; set => con = value; }

        public bool Connection()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                return true;
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void DisConnection()
        {
            con.Close();
            con.Dispose();
        }
    }
}
