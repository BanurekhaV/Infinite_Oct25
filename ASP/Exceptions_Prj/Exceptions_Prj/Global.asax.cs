using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Exceptions_Prj
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            //Server.ClearError();
            //// Response.Write(ex.GetType());
            //Server.Transfer("apperr.html");

            //to handle other unhandled exceptions if any
           // HttpException lstex = Server.GetLastError() as HttpException;
          //  if(lstex.GetHttpCode()==403)
            //{
            //    Server.Transfer("~/err.aspx");
            //}

            //logging errors onto the file
            Exception ex = Server.GetLastError();
            Server.ClearError();
            string str = "";
            str+= str + " " + ex.Message + " " +ex.Source + " "+ ex.StackTrace;
            string path = "C:\\Infinite_Oct25\\ASP\\Errorfile.txt";
            File.WriteAllText(path, str);
            Server.Transfer("~/PageNotFound.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}