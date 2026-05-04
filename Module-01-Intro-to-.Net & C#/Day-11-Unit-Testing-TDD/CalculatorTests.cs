using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoApp; // Reference to my main app

namespace Demo.tests
{
    [TestClass] // This attribute tells MSTest this class contains tests
    public class CalculatorTests
    {
        [TestMethod] // This attribute tells MSTest this is a specific test case
        public void TestMethod1()
        {
            // 1. Arrange
            Calculator calc = new Calculator();
            int a = 2;
            int b = 6;
            int expected = 12;

            // 2. Act
            int actual = calc.Multiply(a, b);

            // 3. Assert
            Assert.AreEqual(expected, actual, "Multiplying 2 and 6 should be 12");
        }
    }
}
