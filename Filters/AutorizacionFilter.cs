cat > Filters/AutorizacionFilter.cs << 'EOF'
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GuayabitosMvc.Filters
{
    public class AutorizacionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.Session.GetInt32("UserId");
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();
            
            if (controller == "Login" && (action == "Index" || action == "Setup"))
            {
                return;
            }
            
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
EOF