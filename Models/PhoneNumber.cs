
namespace EmployeeManagementSystem.Models
{
    public class PhoneNumber
    {
        public int ID { get; }
        public string Number { get; }
        public string Description { get; }
        public string PhoneNumberDescription { get; }

        public PhoneNumber(int iD = 0, string number = "", string description = "")
        {
            ID = iD;
            Number = number;
            Description = description;

            PhoneNumberDescription = Number + " " + Description;
        }
    }
}
