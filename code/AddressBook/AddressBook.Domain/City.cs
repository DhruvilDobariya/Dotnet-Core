using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = null!;

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State Name")]
        public int StateId { get; set; }

        [Display(Name = "STD Code")]
        public string? Stdcode { get; set; }

        [Display(Name = "Pin Code")]
        public string? PinCode { get; set; }
    }
}
