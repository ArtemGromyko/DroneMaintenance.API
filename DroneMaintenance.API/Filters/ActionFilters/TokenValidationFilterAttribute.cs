using DroneMaintenance.BLL.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Filters.ActionFilters
{
    public class TokenValidationFilterAttribute : IAsyncActionFilter
    {
        private readonly IUsersService _usersService;

        public TokenValidationFilterAttribute(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.User.Identity.IsAuthenticated)
            {
                await next();
                return;
            }

            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            var idString = claimsIdentity.FindFirst("Id").Value;
            var id = new Guid(idString);

            var userEntity = await _usersService.GetUserAsync(id);
            if (userEntity.Token == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            await next();
        }
    }
}
