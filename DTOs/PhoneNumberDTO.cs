using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class PhoneNumberDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }

    }
}
