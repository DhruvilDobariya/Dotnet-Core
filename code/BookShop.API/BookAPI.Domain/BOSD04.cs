using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain
{
    /// <summary>
    /// User dbset
    /// </summary>
    public class BOSD04
    {
        /// <summary>
        /// UserId which is primary key of User dbset
        /// </summary>
        [Key]
        public int D04F01 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Please enter name")]
        [MinLength(2, ErrorMessage = "Name must contains at least two character")]
        [StringLength(50, ErrorMessage = "Name must contains less then 50 characters")]
        public string D04F02 { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        [StringLength(50, ErrorMessage = "Email must contains less then 50 characters")]
        public string D04F03 { get; set; } = null!;

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password, ErrorMessage = "Please enter valid password")]
        [StringLength(50, ErrorMessage = "Password must contains less then 50 characters")]
        public string D04F04 { get; set; } = string.Empty!;
    }
}
