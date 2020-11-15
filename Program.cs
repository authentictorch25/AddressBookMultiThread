using System;

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
            //UC20
            AddressBookModel contactDetails = new AddressBookModel();
            contactDetails.FirstName = "samrat";
            contactDetails.LastName = "pandey";
            contactDetails.Address = "Chennai";
            contactDetails.City = "chennai";
            contactDetails.State = "Karnataka";
            contactDetails.Zip = 45895;
            contactDetails.PhoneNumber = 654645465478;
            contactDetails.Email = "viratkohli@gmail.com";
            contactDetails.DateAdded = Convert.ToDateTime("2019-06-10");
            contactDetails.AddressBookName = "BCCI";
            contactDetails.ContactType = "CRICKETER";
            contactDetails.TypeCode = "CRI";
            Console.WriteLine(repository.AddContactDetailsIntoDataBase(contactDetails) ? "Contact added successfully" : "Contact was not added");
        }
    }
}
