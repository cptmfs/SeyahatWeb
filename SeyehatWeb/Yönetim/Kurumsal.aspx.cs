using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyehatWeb.Yönetim
{
    public partial class Kurumsal : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update tabloKurumsal set Baslik=@Baslik,Ozet=@Ozet,Detay=@Detay where Id=@Id", baglanti);
            cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.ToString());
            cmd.Parameters.AddWithValue("@Ozet", txtOzet.Text.ToString());
            cmd.Parameters.AddWithValue("@Detay", txtDetay.Text.ToString());
            cmd.Parameters.AddWithValue("@Id", lblId.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("Kurumsal.aspx");
        }

        protected void btnYukle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from tabloKurumsal", baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(read);
            txtBaslik.Text = tbl.Rows[0]["Baslik"].ToString();
            txtOzet.Text = tbl.Rows[0]["Ozet"].ToString();
            txtDetay.Text = tbl.Rows[0]["Detay"].ToString();
            lblId.Text = tbl.Rows[0]["Id"].ToString();
            baglanti.Close();
            btnKaydet.Enabled = true;
        }
    }
}