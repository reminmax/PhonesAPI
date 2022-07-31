using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhonesAPI.Models;

namespace PhonesAPI.ValidationAttributes
{
    public class ModelNameAndOSAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phone = (PhoneManipulationDto)validationContext.ObjectInstance;
            if (phone.ModelName.Trim() == phone.OS.Trim())
            {
                return new ValidationResult("The model name and OS need to be different",
                    new[] { "PhoneManipulationDto" });
            }

            return ValidationResult.Success;
        }
    }
}
