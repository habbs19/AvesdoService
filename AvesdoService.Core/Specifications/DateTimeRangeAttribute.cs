using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Specifications
{
    public sealed class DateTimeRangeAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime result; 
            if(DateTime.TryParse(Convert.ToString(value),out result))
            {
                if(result > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Order date cannot be in the past.");
        }
    }
}
