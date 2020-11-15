﻿using System;
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
        public void GetContactsAddedInPeriod(string startdate, string endDate)
        {
            string query = $@"select c.*,ca.city,ca.state,ca.zip,t.ContactType,am.AddressBookName from contact c,contact_address ca,type t,addressbookmap am,contact_type ct where c.dateAdded between cast('{startdate}' as date)  and cast('{endDate}' as date) and c.Firstname=ca.FirstName and c.LastName=ca.lastName and c.Firstname=ct.FirstName and c.LastName=ct.lastName and t.TypeCode=ct.TypeCode and c.Firstname=am.FirstName and c.LastName=am.lastName";
            GetData(query);
        }
        public void GetData(string query)
        {
            //Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
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
                            model.DateAdded = reader.GetDateTime(5);
                            model.City = reader.GetString(6);
                            model.State = reader.GetString(7);
                            model.Zip = reader.GetInt32(8);
                            model.ContactType = reader.GetString(9);
                            model.AddressBookName = reader.GetString(10);
                            Console.WriteLine($"First Name: {model.FirstName}\nLast Name: {model.LastName}\nAddress: {model.Address}\nCity: {model.City}\nState: {model.State}\nZip: {model.Zip}\nPhone Number: {model.PhoneNumber}\nDateAdded:{model.DateAdded}\nEmail: {model.Email}\nContact Type: {model.ContactType}\nAddress Book Name : {model.AddressBookName}");
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
        public void GetNumberOfContactsByCityOrState()
        {
            Console.WriteLine("Enter:\n1.For city\n2.For state");
            int option = Convert.ToInt32(Console.ReadLine());
            string query = "";
            switch (option)
            {
                case 1:
                    query = $@"select City,count(City) as PeopleInCity from address_book group by City";
                    break;
                case 2:
                    query = $@"select State,count(State) as PeopleInCity from address_book group by State";
                    break;
            }
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string location = reader[0].ToString();
                            int count = reader.GetInt32(1);
                            Console.WriteLine($"City/State:{location}\nPeopleCount:{count}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
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
    }
}

