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
        }
    }
}
