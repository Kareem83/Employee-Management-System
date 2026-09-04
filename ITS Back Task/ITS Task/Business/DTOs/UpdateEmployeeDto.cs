using System.ComponentModel.DataAnnotations;

namespace ITS_Task.Business.DTOs
{
    public class UpdateEmployeeDto
    {


        [Required]
        public string FullName { get; set; } = string.Empty;


        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Department { get; set; } = string.Empty;


        [Required]
        public string JobTitle { get; set; } = string.Empty;


        [Required]
        public DateTime HireDate { get; set; }

       
    }
}