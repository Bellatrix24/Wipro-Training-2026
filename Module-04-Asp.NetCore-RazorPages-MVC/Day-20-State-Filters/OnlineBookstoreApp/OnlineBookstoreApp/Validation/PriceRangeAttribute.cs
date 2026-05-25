using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreApp.Validation
{
    public class PriceRangeAttribute : ValidationAttribute
    {
        private readonly double _min;
        private readonly double _max;

        public PriceRangeAttribute(double min = 1.00, double max = 500.00)
        {
            _min = min;
            _max = max;
            ErrorMessage = $"Price must be between ${_min:F2} and ${_max:F2}.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && decimal.TryParse(value.ToString(), out var price))
            {
                if (price >= (decimal)_min && price <= (decimal)_max)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
