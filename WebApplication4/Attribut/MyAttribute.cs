using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Attribut
{
    public class MyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            if(value.ToString() == "Kotek")
                return  ValidationResult.Success;
            return new ValidationResult("To nie jest kotek");
        }
    }
}