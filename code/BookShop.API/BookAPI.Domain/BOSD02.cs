using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain
{
    /// <summary>
    /// Customer dbset
    /// </summary>
    public class BOSD02
    {
        /// <summary>
        /// CustomerId which is primary key of Customer dbset
        /// </summary>
        [Key]
        public int D02F01 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Please enter title")]
        [MinLength(2, ErrorMessage = "Title must contains at least two character")]
        [StringLength(250, ErrorMessage = "Name must contains less then 250 characters")]
        public string D02F02 { get; set; } = null!;

        /// <summary>
        /// ConatctNo
        /// </summary>
        [StringLength(50, ErrorMessage = "Contact No must contains less then 50 characters")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter valid contact no")]
        public string D02F03 { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(250, ErrorMessage = "Address must contains less then 250 characters")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        public string D02F04 { get; set; } = null!;

        /// <summary>
        /// Address
        /// </summary>
        [StringLength(500, ErrorMessage = "Address must contains less then 500 characters")]
        public string D02F05 { get; set; } = string.Empty;

        /// <summary>
        /// UserId which is reference key of User dbset
        /// </summary>
        public int D02F06 { get; set; }
    }
}
