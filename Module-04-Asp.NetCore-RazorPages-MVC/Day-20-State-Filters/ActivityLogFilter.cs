using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WiproTraining.Day20.Filters
{
    // This custom action filter intercepts action executions in our patient pipeline.
    // By inheriting from ActionFilterAttribute, we hook directly into MVC pipeline stages.
    public class ActivityLogFilter : ActionFilterAttribute
    {
        // This method executes automatically immediately BEFORE our controller action runs!
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Simple trainee reminder comment: checking user parameters before letting them access the clinic files
            Console.WriteLine("Checking permissions before action runs...");

            base.OnActionExecuting(context);
        }

        // This method executes automatically immediately AFTER our controller action finishes!
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Simple trainee reminder comment: logging how long the page took to process once it's done rendering
            Console.WriteLine("Tracking activity metrics after action completes...");

            base.OnActionExecuted(context);
        }
    }
}
