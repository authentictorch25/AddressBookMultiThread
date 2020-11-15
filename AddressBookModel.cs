using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookThread
{
    public class AddressBookModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public double PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public string AddressBookName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
