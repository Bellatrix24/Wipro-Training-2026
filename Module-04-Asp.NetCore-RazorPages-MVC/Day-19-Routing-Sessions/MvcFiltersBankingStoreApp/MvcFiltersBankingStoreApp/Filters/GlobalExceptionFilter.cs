using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MvcFiltersBankingStoreApp.Services;

namespace MvcFiltersBankingStoreApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly LoggingService _loggingService;

        public GlobalExceptionFilter(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the unhandled exception using the injected service
            _loggingService.LogException(context.Exception.Message, context.Exception.StackTrace ?? string.Empty);

            // Mark the exception as handled to prevent runtime crash
            context.ExceptionHandled = true;

            // Render a friendly custom error view
            var result = new ViewResult
            {
                ViewName = "Error"
            };

            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                { "ErrorMessage", context.Exception.Message }
            };

            context.Result = result;
        }
    }
}
