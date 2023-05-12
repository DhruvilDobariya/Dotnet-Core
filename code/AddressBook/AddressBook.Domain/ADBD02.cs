using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    /// <summary>
    /// State DbSet
    /// </summary>
    public class ADBD02
    {
        /// <summary>
        /// StateId which is primary key of State DbSet
        /// </summary>
        [Key]
        public int D02F01 { get; set; }

        /// <summary>
        /// StateName
        /// </summary>
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please Enter State Name")]
        [StringLength(250, ErrorMessage = "State Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "State Name must contains at least 2 character")]
        public string D02F02 { get; set; } = null!;

        /// <summary>
        /// StateCode
        /// </summary>
        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please Enter State Code")]
        [StringLength(50, ErrorMessage = "State Code must contains less then or equals to 50 character")]
        [MinLength(2, ErrorMessage = "State Code must contains at least 2 character")]
        public string? D02F03 { get; set; }

        /// <summary>
        /// CountryName
        /// </summary>
        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please Select Country Name")]
        public int D02F04 { get; set; }

        /// <summary>
        /// UserId which is reference key of User DbSet
        /// </summary>
        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D02F05 { get; set; }
    }
}
