using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CustomValidations_Prj.Models;

namespace CustomValidations_Prj.CustomValidations
{
    public class SkillValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<CheckBox> selected_skills = value as List<CheckBox>;
            int count = selected_skills == null ? 0 : (from s in selected_skills
                                                       where s.IsChecked == true
                                                       select s).Count();

            if (count >= 3)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}