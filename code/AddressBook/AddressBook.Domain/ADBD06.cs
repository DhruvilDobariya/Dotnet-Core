using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain
{
    /// <summary>
    /// User DbSet
    /// </summary>
    public class ADBD06
    {
        /// <summary>
        /// UserId which is primary key of User DbSet
        /// </summary>
        [Key]
        public int D06F01 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(250, ErrorMessage = "Name must contains less then or equals to 250 character")]
        [MinLength(2, ErrorMessage = "Name must contains at least 2 character")]
        public string D06F02 { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        public string D06F03 { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Please enter valid password")]
        public string D06F04 { get; set; } = null!;
    }
}
