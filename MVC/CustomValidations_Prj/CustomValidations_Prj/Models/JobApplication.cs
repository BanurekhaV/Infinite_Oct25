using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CustomValidations_Prj.CustomValitions;
using CustomValidations_Prj.CustomValidations;

namespace CustomValidations_Prj.Models
{
    public class JobApplication
    {
        [Required]
        [DisplayName("Applicant Name")]
        public string name {  get; set; }
        [Display(Name ="Years of Experience")]
        [Range(3,10,ErrorMessage ="Experience must be between 3 and 10 Years")]
        public int experience {  get; set; }
        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        [ValidBirthDate(ErrorMessage ="DOB should be between 01/01/1998 and 31/12/2004 only")]
        public DateTime birthdate { get; set; }
        [Required]
        [Display(Name ="Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})$",
            ErrorMessage ="Invalid Email Format")]
        public string email {  get; set; }
        [GenderValidate(ErrorMessage ="Please select your correct Gender")]
        public string Gender { get; set; }
        [DisplayName("Expected Salary")]
        [RegularExpression(@"^(0(?!\.00)|[1-9]\d{0,6})\.\d{2}$",ErrorMessage =
            "Salary should be like 60000.45")]
        public decimal expsal {  get; set; }
        public List<CheckBox> Skills { get; set; }
        [Required]
        public string HavePassport {  get; set; }
    }
}