using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWTBMillinaire.Model;

namespace WWTBMillinaire.Control
{
    class Process
    {
        DataProvider dp = new DataProvider();
        SqlConnection con;
        public Process()
        {
            dp.Connection();
            con = dp.Con;
        }
        public bool Connection()
        {
            return dp.Connection();
        }
        public void DisConnection()
        {
            dp.DisConnection();
        }

        public SqlCommand c(string query, string[]parameter,object[]values)
        {
            SqlCommand cmd = new SqlCommand(query,con);
            if(Connection())
            {
                if(parameter!=null)
                {
                    for(int i =0;i<parameter.Length;i++)
                    {
                        cmd.Parameters.AddWithValue(parameter[i],values[i]);
                    }
                }
            }
            return cmd;
        }
        public SqlDataReader sqlDataReader(string query, string[] parameter, object[] values)
        {
            SqlDataReader reader = c(query,parameter,values).ExecuteReader();
            DisConnection();
            return reader;
        }
        public DataTable sqlView(string query, string[] parameter, object[] values)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(c(query,parameter,values));
            dap.Fill(dt);
            DisConnection();
            return dt;
        }
        public int sqlScalar(string query, string[] parameter, object[] values)
        {
            int s = Convert.ToInt32(c(query,parameter,values).ExecuteScalar());
            DisConnection();
            return s;
        }

        public int sqlNonQuery(string query, string[] parameter, object[] values)
        {
            int s = c(query, parameter, values).ExecuteNonQuery();
            DisConnection();
            return s;
        }

    }

}
