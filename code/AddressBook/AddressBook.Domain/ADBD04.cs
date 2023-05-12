using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class ADBD04
    {
        [Key]
        public int D04F01 { get; set; }

        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Enter Contact Category")]
        [StringLength(250, ErrorMessage = "Contact Category must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "Contact Category must contains at least 2 character")]
        public string D04F02 { get; set; } = null!;

        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D04F03 { get; set; }
    }
}
