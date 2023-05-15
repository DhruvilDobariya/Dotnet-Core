using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain
{
    /// <summary>
    /// Book dbset
    /// </summary>
    public class BOSD03
    {
        /// <summary>
        /// BookId which is primary key of Book dbset
        /// </summary>
        [Key]
        public int D03F01 { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required(ErrorMessage = "Please enter title")]
        [MinLength(2, ErrorMessage = "Title must contains at least two character")]
        [StringLength(250, ErrorMessage = "Description must contains less then 250 characters")]
        public string D03F02 { get; set; } = null!;

        /// <summary>
        /// Price
        /// </summary>
        [Required(ErrorMessage = "Please enter price")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter valid currency")]
        public decimal D03F03 { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Required(ErrorMessage = "Please enter quantity")]
        public int D03F04 { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [StringLength(500, ErrorMessage = "Description must contains less then 500 characters")]
        public string D03F05 { get; set; } = string.Empty;

        /// <summary>
        /// AuthorId which is reference key of User dbset
        /// </summary>
        [Required(ErrorMessage = "Please enter author")]
        public int D03F06 { get; set; }

        /// <summary>
        /// UserId which is reference key of User dbset
        /// </summary>
        [Required(ErrorMessage = "Please enter user")]
        public int D03F07 { get; set; }
    }
}
