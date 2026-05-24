using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Xunit;
using AdvancedRoutingEcommerceApp.RouteConstraints;

namespace AdvancedRoutingEcommerceApp.Tests
{
    public class RoutingTests
    {
        [Theory]
        [InlineData("d3b07384-d113-4956-d5e3-9c8088000000", true)]
        [InlineData("00000000-0000-0000-0000-000000000000", true)]
        [InlineData("invalid-guid", false)]
        [InlineData("", false)]
        public void GuidRouteConstraint_ShouldValidateCorrectly(string value, bool expectedResult)
        {
            // Arrange
            var constraint = new GuidRouteConstraint();
            var values = new RouteValueDictionary { { "id", value } };

            // Act
            var result = constraint.Match(null, null, "id", values, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("electronics", true)]
        [InlineData("books", true)]
        [InlineData("ELECTRONICS", true)]
        [InlineData("Books", true)]
        [InlineData("furniture", false)]
        [InlineData("", false)]
        public void CategoryRouteConstraint_ShouldValidateCorrectly(string value, bool expectedResult)
        {
            // Arrange
            var constraint = new CategoryRouteConstraint();
            var values = new RouteValueDictionary { { "category", value } };

            // Act
            var result = constraint.Match(null, null, "category", values, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("100-500", true)]
        [InlineData("0-1000", true)]
        [InlineData("10-50", true)]
        [InlineData("50-10", false)]
        [InlineData("-10-50", false)]
        [InlineData("100", false)]
        [InlineData("abc-def", false)]
        [InlineData("", false)]
        public void PriceRangeRouteConstraint_ShouldValidateCorrectly(string value, bool expectedResult)
        {
            // Arrange
            var constraint = new PriceRangeRouteConstraint();
            var values = new RouteValueDictionary { { "priceRange", value } };

            // Act
            var result = constraint.Match(null, null, "priceRange", values, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
