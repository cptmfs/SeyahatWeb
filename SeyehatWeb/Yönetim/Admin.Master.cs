using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyehatWeb.Yönetim
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["Kullanici"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                else
                {
                    lblKullanici.Text = Session["Kullanici"].ToString();
                    lblKullanici2.Text = Session["Kullanici"].ToString();
                }
            
        }

        protected void btnCikis_Click1(object sender, EventArgs e)
        {
            
        }

        protected void btnCik_Click(object sender, EventArgs e)
        {
            Session.Remove("Kullanici");
            Session.Abandon();
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}