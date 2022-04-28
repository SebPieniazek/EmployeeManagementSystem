using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class PhoneNumber
    {
        public int ID { get; }
        public string Number { get; }
        public string Description { get; }
        public string PhoneNumberDescrpition { get; }

        public PhoneNumber(int iD, string number, string description)
        {
            ID = iD;
            Number = number;
            Description = description;

            PhoneNumberDescrpition = Number + " " + Description;
        }
    }
}
