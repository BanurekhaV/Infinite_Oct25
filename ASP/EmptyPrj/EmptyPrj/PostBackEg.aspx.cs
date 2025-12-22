using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyPrj
{
    public partial class PostBackEg : System.Web.UI.Page
    {
        int ClicksCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //let us check if the page is requested for the first time or not
            if (!IsPostBack)
            {
                txtcount.Text = "0";
            }
        }

        protected void BtnCount_Click(object sender, EventArgs e)
        {
            //option 1
            //ClicksCount = ClicksCount + 1;
            //txtcount.Text = ClicksCount.ToString();

            //option 2 using explicit viewstate variable
            //if (ViewState["clicks"] != null)
            //{
            //    ClicksCount = (int)ViewState["clicks"] + 1;
            //}

            //ViewState["clicks"] = ClicksCount;
            //txtcount.Text= ClicksCount.ToString();

            //option 3 using built-in viewstate object of the server controls
            ClicksCount= Convert.ToInt32(txtcount.Text)+1;
            txtcount.Text = ClicksCount.ToString();

        }
    }
}