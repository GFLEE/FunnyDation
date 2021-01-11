using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FunnyDation.Service.Base
{
    public class DbUtility
    {  
        //private static readonly ConnectionStringSettings Connection = 
        //    ConfigurationManager.ConnectionStrings["DefaultConnection"];
        //private static readonly string ConnectionString = Connection.ConnectionString;

        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=Test1;User ID=sa;Password=AbCd123456;");
            connection.Open();
            return connection;
        }
    }
}
