using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain
{
    public class ContactCategory
    {
        [Key]
        public int ContactCategoryId { get; set; }

        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Enter Contact Category")]
        public string ContactCategoryName { get; set; } = null!;
    }
}
