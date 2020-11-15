using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookThread
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            string connectionString = @"Server=LAPTOP-V5IRNHKS\SQLEXPRESS; Initial Catalog =addressbook_service; User ID = akash; Password=akash2507";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
