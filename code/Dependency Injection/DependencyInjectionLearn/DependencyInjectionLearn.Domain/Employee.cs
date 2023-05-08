using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionLearn.Domain
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter employee name")]
        [StringLength(250, ErrorMessage = "employee name must contains less the 250 character")]
        public string EmployeeName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        [StringLength(250, ErrorMessage = "employee name must contains less the 250 character")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter valid contact no")]
        [StringLength(250, ErrorMessage = "employee name must contains less the 250 character")]
        public string ContactNo { get; set; }
    }
}