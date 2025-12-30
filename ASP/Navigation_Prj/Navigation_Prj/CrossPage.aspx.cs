using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navigation_Prj
{
    public partial class CrossPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
            {
                TextBox txtname = (TextBox)PreviousPage.FindControl("txtName");
                lblName.Text = "Welcome " + txtname.Text;
            }
            else
            {
                Response.Redirect("CrossPageIndex.aspx");
            }
        }
    }
}