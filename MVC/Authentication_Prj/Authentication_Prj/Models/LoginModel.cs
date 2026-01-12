using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Authentication_Prj.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please enter user name")]
        [Display(Name ="User Name")]
        public string UserName {  get; set; }
        [Required(ErrorMessage ="Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}