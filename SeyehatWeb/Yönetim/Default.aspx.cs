using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyehatWeb.Yönetim
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AuthToken"] != null
            //           && (Request.Cookies["AuthToken"].Value != ""))
            //{
            //    var son = Session["AuthToken"];

            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Login.aspx");
            //    }
            //    else
            //    {
            //        Session["AuthToken"] = Guid.NewGuid();
            //        Response.Cookies["AuthToken"].Value = null;
            //    }
            //}
        }
    }
}