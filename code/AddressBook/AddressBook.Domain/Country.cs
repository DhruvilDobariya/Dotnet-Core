using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Enter Country Name")]
        public string? CountryName { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please Enter Country Code")]
        public string CountryCode { get; set; } = null!;
    }
}
