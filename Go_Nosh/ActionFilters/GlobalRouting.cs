using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Go_Nosh.NewFolder
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["Controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Customer"))
                {
                    context.Result = new RedirectToActionResult("Index", "Customers", null);
                }
                else if (_claimsPrincipal.IsInRole("Owner"))
                {
                    context.Result = new RedirectToActionResult("Index", "Owners", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

      
    }

}
