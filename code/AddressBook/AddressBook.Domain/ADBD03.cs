using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    /// <summary>
    /// City DbSet
    /// </summary>
    public class ADBD03
    {
        /// <summary>
        /// CityId which is primary key of State DbSet
        /// </summary>
        [Key]
        public int D03F01 { get; set; }

        /// <summary>
        /// CityName
        /// </summary>
        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        [StringLength(250, ErrorMessage = "City Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "City Name must contains at least 2 character")]
        public string D03F02 { get; set; } = null!;

        /// <summary>
        /// STDCode
        /// </summary>
        [Display(Name = "STD Code")]
        [StringLength(50, ErrorMessage = "STD Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "STD Code must contains at least 2 character")]
        public string? D03F03 { get; set; }

        /// <summary>
        /// PinCode
        /// </summary>
        [Display(Name = "Pin Code")]
        [StringLength(50, ErrorMessage = "Pin Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "Pin Code must contains at least 2 character")]
        public string? D03F04 { get; set; }

        /// <summary>
        /// StateName
        /// </summary>
        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State Name")]
        public int D03F05 { get; set; }

        /// <summary>
        /// UserId which is reference key of User DbSet
        /// </summary>
        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D03F06 { get; set; }
    }
}
