using System.ComponentModel.DataAnnotations;

namespace BookAPI.Domain
{
    /// <summary>
    /// Author dbset
    /// </summary>
    public class BOSD01
    {
        /// <summary>
        /// AuthorId which is primary key of Author dbset
        /// </summary>
        [Key]
        public int D01F01 { get; set; }

        /// <summary>
        /// AuthorName
        /// </summary>
        [Required(ErrorMessage = "Please enter author name")]
        [MinLength(2, ErrorMessage = "Author name must contains at least two character")]
        [StringLength(45, ErrorMessage = "Description must contains less then 45 characters")]
        public string D01F02 { get; set; } = null!;

        /// <summary>
        /// UserId which is reference key of User dbset
        /// </summary>
        public int D01F03 { get; set; }
    }
}
