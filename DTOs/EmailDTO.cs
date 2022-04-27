using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class EmailDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }
    }
}
