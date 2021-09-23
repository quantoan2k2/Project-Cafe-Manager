using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DbHelper
    {
        private static MySqlConnection connection;
        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection
                {
                    ConnectionString = "server=localhost;user id=hongquan;password=hongquan22;port=3306;database=MNCoffee;"
                };
            }
            return connection;
        }
        private DbHelper(){}
    }
}