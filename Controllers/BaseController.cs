using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userID = context.HttpContext.Session.GetString("UserID");
        if (string.IsNullOrEmpty(userID))
        {
            context.Result = new RedirectResult("/login");
        }
        base.OnActionExecuting(context);
    }
}
