using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class ADBD03
    {
        [Key]
        public int D03F01 { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        [StringLength(250, ErrorMessage = "City Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "City Name must contains at least 2 character")]
        public string D03F02 { get; set; } = null!;

        [Display(Name = "STD Code")]
        [StringLength(50, ErrorMessage = "STD Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "STD Code must contains at least 2 character")]
        public string? D03F03 { get; set; }

        [Display(Name = "Pin Code")]
        [StringLength(50, ErrorMessage = "Pin Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "Pin Code must contains at least 2 character")]
        public string? D03F04 { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State Name")]
        public int D03F05 { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D03F06 { get; set; }
    }
}
