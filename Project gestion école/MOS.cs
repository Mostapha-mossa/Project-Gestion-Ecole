using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace Project_gestion_école
{
    public class MOS
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public SqlDataReader dr;
        public void connecter()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=projcole;Integrated Security=True";
                con.Open();
            }
        }
        public void deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}