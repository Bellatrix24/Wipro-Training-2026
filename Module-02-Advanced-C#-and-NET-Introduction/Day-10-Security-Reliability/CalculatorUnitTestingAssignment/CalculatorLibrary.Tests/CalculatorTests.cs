using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLibrary.Tests
{
    /// <summary>
    /// Unit tests verifying the functionality of the Calculator class.
    /// Covers various mathematical edge cases, precision delta validation,
    /// negative numbers, and exception validation.
    /// </summary>
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new Calculator();
        private const double Delta = 0.0001;

        [TestMethod]
        public void Add_ReturnsCorrectSum()
        {
            // Act & Assert
            double result = _calculator.Add(15.3, 24.5);
            Assert.AreEqual(39.8, result, Delta);
        }

        [TestMethod]
        public void Add_WithZero_ReturnsSameNumber()
        {
            // Act & Assert
            double result = _calculator.Add(125.75, 0);
            Assert.AreEqual(125.75, result, Delta);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectDifference()
        {
            // Act & Assert
            double result = _calculator.Subtract(50.5, 20.25);
            Assert.AreEqual(30.25, result, Delta);
        }

        [TestMethod]
        public void Subtract_WithZero_ReturnsSameNumber()
        {
            // Act & Assert
            double result = _calculator.Subtract(99.99, 0);
            Assert.AreEqual(99.99, result, Delta);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectProduct()
        {
            // Act & Assert
            double result = _calculator.Multiply(5.5, 4.0);
            Assert.AreEqual(22.0, result, Delta);
        }

        [TestMethod]
        public void Multiply_WithZero_ReturnsZero()
        {
            // Act & Assert
            double result = _calculator.Multiply(88.8, 0);
            Assert.AreEqual(0.0, result, Delta);
        }

        [TestMethod]
        public void Divide_ReturnsCorrectQuotient()
        {
            // Act & Assert
            double result = _calculator.Divide(100.0, 8.0);
            Assert.AreEqual(12.5, result, Delta);
        }

        [TestMethod]
        public void Divide_WithDecimalNumbers_ReturnsCorrectResult()
        {
            // Act & Assert
            double result = _calculator.Divide(7.5, 2.5);
            Assert.AreEqual(3.0, result, Delta);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Act & Assert
            var exception = Assert.ThrowsException<DivideByZeroException>(() =>
            {
                _calculator.Divide(10.0, 0);
            });

            // Verify exception message is correct
            Assert.AreEqual("Cannot divide by zero.", exception.Message);
        }

        [TestMethod]
        public void Operations_WithNegativeNumbers_ReturnCorrectResults()
        {
            // Add
            Assert.AreEqual(-10.0, _calculator.Add(-7.0, -3.0), Delta);
            Assert.AreEqual(2.0, _calculator.Add(-5.0, 7.0), Delta);

            // Subtract
            Assert.AreEqual(-4.0, _calculator.Subtract(-7.0, -3.0), Delta);
            Assert.AreEqual(-12.0, _calculator.Subtract(-5.0, 7.0), Delta);

            // Multiply
            Assert.AreEqual(21.0, _calculator.Multiply(-7.0, -3.0), Delta);
            Assert.AreEqual(-35.0, _calculator.Multiply(-5.0, 7.0), Delta);

            // Divide
            Assert.AreEqual(2.33333, _calculator.Divide(-7.0, -3.0), Delta);
            Assert.AreEqual(-0.71428, _calculator.Divide(-5.0, 7.0), Delta);
        }
    }
}
