using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ModelStates_Prj.Models
{
    public class User
    {
        [Required(ErrorMessage ="First Name is needed")]
        [DisplayName("First Name ")]
        [StringLength(30,ErrorMessage ="First Name cannot be more than 30 characters")]
        public string FName { get; set; }
        [DisplayName("Last Name ")]
        public string LName {  get; set; }
        [DisplayName("Users Age")]
        // [Range(21,45,ErrorMessage ="Age has to be between 21 and 45 only")]
      //  [Range(21,45)]
        public int age {  get; set; }
        [Required(ErrorMessage ="Email is a must")]
        [EmailAddress]
        [DisplayName("Email ID")]
        public string email {  get; set; }
    }
}