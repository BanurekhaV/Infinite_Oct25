using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Caching_Prj
{
    public partial class CacheForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetProductsByName(string productname)
        {
            SqlConnection con = new SqlConnection("Data Source=laptop-tjj7d977; initial catalog=infinite;" +
                "integrated security=true;");
            SqlDataAdapter da =new SqlDataAdapter("spGetProductByName", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Productname";
            param1.Value = productname;
            
            da.SelectCommand.Parameters.Add(param1);

            DataSet ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductsByName(DDL.SelectedValue);

        }
    }
}