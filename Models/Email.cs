
namespace EmployeeManagementSystem.Models
{
    public class Email
    {
        public int ID { get; }
        public string EmailAddress { get; }
        public string Description { get; }
        public string EmailDescription { get; }

        public Email(int iD = 0, string emailAddress = "", string description = "")
        {
            ID = iD;
            EmailAddress = emailAddress;
            Description = description;

            EmailDescription = EmailAddress + " " + Description;
        }
    }
}
