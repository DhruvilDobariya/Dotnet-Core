using AddressBook.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain
{
    public class ADBD05
    {
        [Key]
        public int D05F01 { get; set; }

        [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "Please Enter Contact Name")]
        public string D05F02 { get; set; } = null!;

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please Enter Contact No")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter valid contact no")]
        public string D05F03 { get; set; } = null!;

        [Display(Name = "Whtasapp No")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter valid whatsapp no")]
        public string? D05F04 { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        public string D05F05 { get; set; } = null!;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter valid date")]
        public DateTime? D05F06 { get; set; }

        [Display(Name = "Age")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid age")]
        public int? D05F07 { get; set; }

        [Display(Name = "Gender")]
        [EnumDataType(typeof(GenderEnum), ErrorMessage = "Please enter valid gender")]
        public string? D05F08 { get; set; }

        [Display(Name = "Blood Group")]
        [EnumDataType(typeof(BloodGroupEnum), ErrorMessage = "Please enter valid blood group")]
        public string? D05F09 { get; set; }

        [Display(Name = "Facebook Id")]
        [DataType(DataType.Url, ErrorMessage = "Please enter valid URL")]
        public string? D05F10 { get; set; }

        [Display(Name = "Linkedin Id")]
        [DataType(DataType.Url, ErrorMessage = "Please enter valid URL")]
        public string? D05F11 { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Address must contains less then or equals to 500 character")]
        public string D05F12 { get; set; } = null!;

        [ForeignKey("ContactCategory")]
        [Display(Name = "Contact Category")]
        [Required(ErrorMessage = "Please Select Contact Category")]
        public int D05F13 { get; set; }

        [ForeignKey("Country")]
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please Select Country")]
        public int D05F14 { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State")]
        [Required(ErrorMessage = "Please Select State")]
        public int D05F15 { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Select City")]
        public int D05F16 { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Please Select User")]
        public int D05F17 { get; set; }
    }
}
