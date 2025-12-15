using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pustok.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
     _roles = roles;
    }

   public void OnAuthorization(AuthorizationFilterContext context)
   {
    var user = context.HttpContext.User;

      if (!user.Identity?.IsAuthenticated ?? true)
        {
   context.Result = new RedirectToActionResult("Login", "Account", null);
    return;
   }

     if (_roles.Length > 0 && !_roles.Any(role => user.IsInRole(role)))
   {
       context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
    return;
      }
        }
    }
}
