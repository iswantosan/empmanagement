using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Services.Models
{
    public class EmployeeDTO
    {        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
