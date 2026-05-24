using System;

namespace CalculatorLibrary
{
    /// <summary>
    /// A simple calculator class providing basic mathematical operations.
    /// Designed for beginners and students to learn unit testing.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two double-precision floating-point numbers.
        /// </summary>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second number from the first.
        /// </summary>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two double-precision floating-point numbers.
        /// </summary>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides the first number by the second.
        /// Throws DivideByZeroException if the divisor is zero.
        /// </summary>
        public double Divide(double a, double b)
        {
            // Simple division by zero check for double types
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return a / b;
        }
    }
}
