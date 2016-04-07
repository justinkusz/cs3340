
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;

    /// <summary>
    /// Summary description for ConnectionFactory
    /// </summary>
    public class ConnectionFactory
    {
        public static IDbCommand GetCommand(string dbType)
        {
            IDbConnection con;
            IDbCommand cmd;
            string connectionString;

            if (dbType.Equals("SQL_Server"))
            {
                con = new SqlConnection();
                cmd = new SqlCommand();
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringSqlServer"].ConnectionString;
            }
            else if(dbType.Equals("Access_Players")) // Access
            {
                con = new OleDbConnection();
                cmd = new OleDbCommand();
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAccessPlayers"].ConnectionString;
            }
            else // Access_Patients
            {
                con = new OleDbConnection();
                cmd = new OleDbCommand();
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAccessPatients"].ConnectionString;
            }


            con.ConnectionString = connectionString;
            cmd.Connection = con;
            return cmd;
        }

    }
