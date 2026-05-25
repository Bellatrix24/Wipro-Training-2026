using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OnlineBookstoreApp.Validation
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("ISBN is required.");
            }

            var isbn = value.ToString()!.Replace("-", "");
            
            // ISBN-13 check: exactly 13 digits
            if (isbn.Length == 13 && Regex.IsMatch(isbn, @"^\d{13}$"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("ISBN must be a valid 13-digit number (e.g., 978-3-16-148410-0).");
        }
    }
}
