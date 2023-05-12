using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain
{
    public class ADBD06
    {
        [Key]
        public int D06F01 { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(250, ErrorMessage = "Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "Name must contains at least 2 character")]
        public string D06F02 { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        public string D06F03 { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Please enter valid password")]
        public string D06F04 { get; set; } = null!;
    }
}
