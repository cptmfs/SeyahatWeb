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
    public partial class BlogEkle : System.Web.UI.Page
    {
        DateTime bugun = DateTime.Now;
        string congBaglanti = WebConfigurationManager.ConnectionStrings["GoTripConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTarih.Text=bugun.ToString(); 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string resimAd = FileUpload1.FileName.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/images/blog/" + resimAd));
                    lblResim.Text = resimAd.ToString();
                }
                else
                {
                    lblResim.Text = "Lütfen uygun formatta bir resim seçiniz. ( JPEG , JPG , PNG )";
                }
            }
            else
            {
                lblResim.Text = "Lütfen resim seçiniz.";
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblBlog(Baslik,Ozet,KategoriId,Resim,Detay,Tarih) values (@Baslik,@Ozet,@KategoriId,@Resim,@Detay,@Tarih)", baglanti);
            cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.ToString());
            cmd.Parameters.AddWithValue("@Ozet", txtOzet.Text.ToString());
            cmd.Parameters.AddWithValue("@KategoriId", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Resim", lblResim.Text.ToString());
            cmd.Parameters.AddWithValue("@Detay", txtBlogDetay.Text.ToString());
            cmd.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(lblTarih.Text.ToString()));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("BlogDuzenleSil.aspx");
        }
    }
}