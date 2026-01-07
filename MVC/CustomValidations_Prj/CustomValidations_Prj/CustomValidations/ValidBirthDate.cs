using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CustomValidations_Prj.Models;

namespace CustomValidations_Prj.CustomValitions
{
    public class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime entered_dob = Convert.ToDateTime(value);
            DateTime mindt = Convert.ToDateTime("01/01/1998");
            DateTime maxdt = Convert.ToDateTime("31/12/2004");

            if (entered_dob >= mindt && entered_dob <= maxdt)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}