using DroneMaintenance.BLL.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DroneMaintenance.API.Filters.ActionFilters
{
    public class NullArgumentFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;

        public NullArgumentFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
