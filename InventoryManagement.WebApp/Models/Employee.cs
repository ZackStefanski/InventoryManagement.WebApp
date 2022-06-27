using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FIRST NAME")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LAST NAME")]
        public string LastName { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
