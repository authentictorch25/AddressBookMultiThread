using System;
using System.Collections.Generic;

namespace AddressBookThread
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepository repository = new AddressBookRepository();
            //UC 17
            repository.UpdateExistingContactUsingName("Rahul", "Kumar", "Email", "rahul12345@gmail.com");
            //UC 18
            repository.GetContactsAddedInPeriod("2018-01-01", "2020-01-01");
            //UC 19
            repository.GetNumberOfContactsByCityOrState();
            //UC21
            AddressBookModel contactDetails1 = new AddressBookModel();
            contactDetails1.FirstName = "Rohit";
            contactDetails1.LastName = "Sharma";
            contactDetails1.Address = "Wankhede";
            contactDetails1.City = "Mumbai";
            contactDetails1.State = "Maharashtra";
            contactDetails1.Zip = 654567;
            contactDetails1.PhoneNumber = 3456453345;
            contactDetails1.Email = "rs@gmail.com";
            contactDetails1.DateAdded = Convert.ToDateTime("2019-01-10");
            contactDetails1.AddressBookName = "B";
            contactDetails1.ContactType = "B";
            contactDetails1.TypeCode = "B";
            AddressBookModel contactDetails2 = new AddressBookModel();
            contactDetails2.FirstName = "MS";
            contactDetails2.LastName = "Dhoni";
            contactDetails2.Address = "Chidambaram";
            contactDetails2.City = "Chennai";
            contactDetails2.State = "Tamil Nadu";
            contactDetails2.Zip = 546765;
            contactDetails2.PhoneNumber = 2345432345;
            contactDetails2.Email = "msd@gmail.com";
            contactDetails2.DateAdded = Convert.ToDateTime("2018-06-10");
            contactDetails2.AddressBookName = "A";
            contactDetails2.ContactType = "A";
            contactDetails2.TypeCode = "A";
            List<AddressBookModel> contactList = new List<AddressBookModel>();
            contactList.Add(contactDetails1);
            contactList.Add(contactDetails2);
            repository.AddMultipleContactsUsingThread(contactList);
        }
    }
}
