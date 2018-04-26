using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomValidation
{
    public class PersonDto : IValidatableObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private bool StartsWithCaps(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value[0].Equals(value.ToUpper()[0]);
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const string message = "Value must start with capital letter";
            var results = new List<ValidationResult>();
            if (!StartsWithCaps(FirstName))
            {
                yield return new ValidationResult(message, new[] { nameof(FirstName) });
            }
            if (!StartsWithCaps(LastName))
            {
                yield return new ValidationResult(message, new[] { nameof(LastName) });
            }
        }
    }
}
