using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace FunnyDation.Service.Base
{
    public class DbUtility
    {  
        private static readonly ConnectionStringSettings Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"];
        private static readonly string ConnectionString = Connection.ConnectionString;

        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
