using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Authentication_Prj.CustomFilters
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filtercontext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filtercontext.HttpContext.Session["UserName"])))
            {
                filtercontext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if(context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                //redirect the user to the login page of account controller
                context.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller", "Account" },
                        {"action", "Login" }
                    });

                //if we want to redirect to some error page
                //context.Result = new ViewResult()
                //    {
                //    ViewName = "Error"
                //};
            }
        }
    }
}