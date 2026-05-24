using System;
using System.ComponentModel.DataAnnotations;

namespace TagHelpersValidationApp.Validation
{
    // Natural comment: Custom validation attribute to check that Password and Confirm Password properties match.
    [AttributeUsage(AttributeTargets.Class)]
    public class PasswordMatchAttribute : ValidationAttribute
    {
        public string PasswordProperty { get; }
        public string ConfirmPasswordProperty { get; }

        public PasswordMatchAttribute(string passwordProperty, string confirmPasswordProperty)
        {
            PasswordProperty = passwordProperty;
            ConfirmPasswordProperty = confirmPasswordProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var type = value.GetType();
            var passwordProp = type.GetProperty(PasswordProperty);
            var confirmPasswordProp = type.GetProperty(ConfirmPasswordProperty);

            if (passwordProp == null || confirmPasswordProp == null)
            {
                return new ValidationResult($"Property {PasswordProperty} or {ConfirmPasswordProperty} not found.");
            }

            var passwordValue = passwordProp.GetValue(value) as string;
            var confirmPasswordValue = confirmPasswordProp.GetValue(value) as string;

            if (passwordValue != confirmPasswordValue)
            {
                return new ValidationResult(ErrorMessage ?? "Passwords do not match.", new[] { ConfirmPasswordProperty });
            }

            return ValidationResult.Success;
        }
    }
}
