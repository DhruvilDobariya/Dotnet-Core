using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    /// <summary>
    /// Contact Category DbSet
    /// </summary>
    public class ADBD04
    {
        /// <summary>
        /// ContactCategoryId which is primary key of ContactCategory DbSet
        /// </summary>
        [Key]
        public int D04F01 { get; set; }

        /// <summary>
        /// ContactCategoryName
        /// </summary>
        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Enter Contact Category")]
        [StringLength(250, ErrorMessage = "Contact Category must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "Contact Category must contains at least 2 character")]
        public string D04F02 { get; set; } = null!;

        /// <summary>
        /// UserId which is reference key of User DbSet
        /// </summary>
        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D04F03 { get; set; }
    }
}
