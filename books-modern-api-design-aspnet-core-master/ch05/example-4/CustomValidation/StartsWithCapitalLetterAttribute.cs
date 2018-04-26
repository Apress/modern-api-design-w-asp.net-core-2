using System.ComponentModel.DataAnnotations;

namespace CustomValidation
{
    public class StartsWithCapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
       ValidationContext validationContext)
        {
            if (value?.ToString()[0] != value?.ToString().ToUpper()[0])
            {
                return new ValidationResult("Value must start with capital letter");
            }
            return ValidationResult.Success;
        }
    }
}
