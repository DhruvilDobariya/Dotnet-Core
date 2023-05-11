using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; } = null!;

        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Select Country Name")]
        public int CountryId { get; set; }

        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please Enter State Code")]
        public string? StateCode { get; set; }
    }
}
