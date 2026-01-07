using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CustomValidations_Prj.CustomValidations
{
    public class BirthDateValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthday = (DateTime)value;
            if (birthday.Year < 1998)
                return new ValidationResult("Seems you are a bit old for this Job...");
            if(birthday.Year >2004)
                return new ValidationResult("Seems you are very young for this Job...");
            if(birthday.Month == 4)
                return new ValidationResult("Sorry, We cannot accept April Borns...");
            return ValidationResult.Success;
        }
    }
}