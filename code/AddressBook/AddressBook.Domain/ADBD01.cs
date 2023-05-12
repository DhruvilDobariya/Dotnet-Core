using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class ADBD01
    {
        [Key]
        public int D01F01 { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Enter Country Name")]
        [StringLength(250, ErrorMessage = "Country Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "Country Name must contains at least 2 character")]
        public string? D01F02 { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please Enter Country Code")]
        [StringLength(50, ErrorMessage = "Country Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "Country Code must contains at least 2 character")]
        public string D01F03 { get; set; } = null!;

        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D01F04 { get; set; }
    }
}
