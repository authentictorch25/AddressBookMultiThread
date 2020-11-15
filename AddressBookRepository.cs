using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookThread
{
    public class AddressBookRepository
    {
        public static SqlConnection connection { get; set; }

        public void RetrieveAllContactDetails()
        {
            //Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spGetAllContacts", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.PhoneNumber = reader.GetInt64(3);
                            model.Email = reader.GetString(4);
                            model.City = reader.GetString(5);
                            model.State = reader.GetString(6);
                            model.Zip = reader.GetInt32(7);
                            model.ContactType = reader.GetString(8);
                            model.AddressBookName = reader.GetString(9);
                            Console.WriteLine($"First Name: {model.FirstName}\nLast Name: {model.LastName}\nAddress: {model.Address}\nCity: {model.City}\nState: {model.State}\nZip: {model.Zip}\nPhone Number: {model.PhoneNumber}\nEmail: {model.Email}\nContact Type: {model.ContactType}\nAddress Book Name : {model.AddressBookName}");
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State.Equals("Open"))
                connection.Close();
            }
        }
        public bool UpdateExistingContactUsingName(string firstName, string lastName, string column, string newValue)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = $@"update dbo.contact set {column}='{newValue}' where FirstName='{firstName}' and LastName='{lastName}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State.Equals("Open"))
                    connection.Close();
            }
        }
    }
}

