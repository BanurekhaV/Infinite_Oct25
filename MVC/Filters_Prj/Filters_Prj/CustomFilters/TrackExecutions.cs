using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data;

namespace Filters_Prj.CustomFilters
{
    public class TrackExecutions : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "\n" +
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                "----> " + filterContext.ActionDescriptor.ActionName + " ----> " +
                "On Action Executing \t - " + DateTime.Now.ToString() + "\n";

            LogExecutionDetails(msg);
                
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = "\n" +
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                "----> " + filterContext.ActionDescriptor.ActionName + " ----> " +
                "On Action Executed \t - " + DateTime.Now.ToString() + "\n";

            LogExecutionDetails(msg);
        }
       
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = "\n" +
                filterContext.RouteData.Values["controller"].ToString() +
                "----> " + filterContext.RouteData.Values["action"].ToString() + " ----> On Result Executing \t - " 
                + DateTime.Now.ToString() + "\n";

            LogExecutionDetails(msg);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = "\n" +
               filterContext.RouteData.Values["controller"].ToString() +
               "----> " + filterContext.RouteData.Values["action"].ToString() + " ----> On Result Executed \t - " 
               + DateTime.Now.ToString() + "\n";

            LogExecutionDetails(msg);
        }
        public void OnException(ExceptionContext context)
        {
            string msg = "\n" +
               context.RouteData.Values["controller"].ToString() +
               "----> " + context.RouteData.Values["action"].ToString() + " ----> " +
               "On Exception \t - " + DateTime.Now.ToString() + "\n";

            LogExecutionDetails(msg);
        }

        //creating a method for logging the data
        private void LogExecutionDetails(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/DataLog/Data1.txt"), data);  
        }
    }
}