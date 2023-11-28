using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyehatWeb
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblKullanici where UserName=@UserName and Password=@Password", baglanti);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.ToString());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["Kullanici"] = reader["UserName"].ToString();
                Response.Redirect("~/Yönetim/Default.aspx");
            }
            else
            {
                lblHatalıGiris.Text = "Kullanıcı adı veya şifre hatalıdır.!!";
            }
            reader.Close();
            baglanti.Close();
            baglanti.Dispose();
            
        }
    }
}