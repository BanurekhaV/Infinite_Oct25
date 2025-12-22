using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyPrj
{
    public partial class PageLifeCycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page Load Event" + "<br/>");            
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("Page Init Complete" + "<br/>");
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page Pre Init" + "<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("Page Pre Load" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page Pre Render" + "<br/>");
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            Response.Write("Page Render" + "<br/>");
        }

    //    protected void Page_Unload(object sender, EventArgs e)
    //    {
    //        Response.Write("Page Unload" + "<br/>");
    //    }
    }
}