using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Abdalli_multisport
{
    class Access
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        public void connection()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=DESKTOP-01GH79M\SQLEXPRESS;Initial Catalog=date_Clube;Integrated Security=true";
                con.Open();
            }
        }

        public void Deconnection()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
