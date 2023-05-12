using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class ADBD02
    {
        [Key]
        public int D02F01 { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please Enter State Name")]
        [StringLength(250, ErrorMessage = "State Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "State Name must contains at least 2 character")]
        public string D02F02 { get; set; } = null!;

        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please Enter State Code")]
        [StringLength(50, ErrorMessage = "State Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "State Code must contains at least 2 character")]
        public string? D02F03 { get; set; }

        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Select Country Name")]
        public int D02F04 { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D02F05 { get; set; }
    }
}
