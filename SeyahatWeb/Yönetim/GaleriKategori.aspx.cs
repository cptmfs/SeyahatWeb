using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class GaleriKategori : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblGaleriKategori(Adi) values (@Adi)", baglanti);
            cmd.Parameters.AddWithValue("@Adi", txtAd.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("GaleriKategori.aspx");
        }
    }
}