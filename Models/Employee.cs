using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int ID { get; }
        public int Index { get; set; }
        public string FullName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Position { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Street { get; }

        public List<PhoneNumber> PhoneNumbers { get; }
        public List<Email> Emails { get; }

        public Employee(int iD = 0, string firstName = "", string lastName = "", string position = "", string city = "", string zipCode = "", string street = "", List<PhoneNumber> phoneNumbers = null, List<Email> emails = null)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            City = city;
            ZipCode = zipCode;
            Street = street;
            PhoneNumbers = phoneNumbers;
            Emails = emails;

            FullName = FirstName + " " + LastName;
        }
    }
}
