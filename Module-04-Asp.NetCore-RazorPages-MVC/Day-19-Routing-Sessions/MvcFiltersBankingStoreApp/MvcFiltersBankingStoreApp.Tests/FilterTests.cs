using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Xunit;
using MvcFiltersBankingStoreApp.Filters;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Tests
{
    public class FilterTests
    {
        [Fact]
        public void RequestLoggingFilter_ShouldLogRequestOnActionExecuted()
        {
            // Arrange
            var loggingService = new LoggingService();
            var filter = new RequestLoggingFilter(loggingService);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = "/Products";
            httpContext.Request.Method = "GET";
            httpContext.Response.StatusCode = 200;

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var actionExecutedContext = new ActionExecutedContext(actionContext, new List<IFilterMetadata>(), null!);

            var initialCount = LoggingService.RequestLogs.Count;

            // Act
            filter.OnActionExecuted(actionExecutedContext);

            // Assert
            Assert.Equal(initialCount + 1, LoggingService.RequestLogs.Count);
            Assert.Contains("GET /Products - Status: 200", LoggingService.RequestLogs[LoggingService.RequestLogs.Count - 1]);
        }

        [Fact]
        public void GlobalExceptionFilter_ShouldLogExceptionAndReturnErrorView()
        {
            // Arrange
            var loggingService = new LoggingService();
            var filter = new GlobalExceptionFilter(loggingService);

            var httpContext = new DefaultHttpContext();
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new Exception("Simulated unhandled exception")
            };

            var initialCount = LoggingService.ExceptionLogs.Count;

            // Act
            filter.OnException(exceptionContext);

            // Assert
            Assert.True(exceptionContext.ExceptionHandled);
            Assert.IsType<ViewResult>(exceptionContext.Result);
            
            var viewResult = (ViewResult)exceptionContext.Result;
            Assert.Equal("Error", viewResult.ViewName);
            Assert.Equal("Simulated unhandled exception", viewResult.ViewData["ErrorMessage"]);
            Assert.Equal(initialCount + 1, LoggingService.ExceptionLogs.Count);
        }

        [Fact]
        public void SimpleAuthenticationFilter_ShouldRedirectToLogin_WhenNotLoggedIn()
        {
            // Arrange
            var authService = new AuthService();
            var filter = new SimpleAuthenticationFilter(authService);

            var httpContext = new DefaultHttpContext(); // Guest mode (no query string)
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var authContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

            // Act
            filter.OnAuthorization(authContext);

            // Assert
            Assert.IsType<RedirectToActionResult>(authContext.Result);
            var redirectResult = (RedirectToActionResult)authContext.Result;
            Assert.Equal("Login", redirectResult.ActionName);
            Assert.Equal("Account", redirectResult.ControllerName);
        }

        [Fact]
        public void RoleAuthorizationFilter_ShouldRestrictAccess_WhenNotAdmin()
        {
            // Arrange
            var roleService = new UserRoleService();
            var filter = new RoleAuthorizationFilter(roleService);

            var httpContext = new DefaultHttpContext(); // Standard user role (no query parameter)
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var authContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

            // Act
            filter.OnAuthorization(authContext);

            // Assert
            Assert.IsType<ContentResult>(authContext.Result);
            var contentResult = (ContentResult)authContext.Result;
            Assert.Equal(403, contentResult.StatusCode);
            Assert.Contains("Access Denied", contentResult.Content ?? string.Empty);
        }
    }
}
