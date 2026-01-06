using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTML_Helpers_Prj.Models
{
    public class Student
    {
        [Display(Name="Students Roll Number")]
        public int RNO { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}