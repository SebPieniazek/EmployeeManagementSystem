using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Email
    {
        public int ID { get; }
        public string EmailAddress { get; }
        public string Description { get; }
        public string EmailDescription { get; }

        public Email(int iD, string emailAddress, string description)
        {
            ID = iD;
            EmailAddress = emailAddress;
            Description = description;

            EmailDescription = EmailAddress + " " + Description;
        }
    }
}
