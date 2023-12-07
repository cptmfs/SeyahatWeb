using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class Ayarlar : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;
        public string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;  
        }


        protected void btnYukle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblAyarlar", baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(read);
            txtMail.Text = tbl.Rows[0]["Mail"].ToString();
            txtTelefon.Text = tbl.Rows[0]["Telefon"].ToString();
            txtAdress.Text = tbl.Rows[0]["Adres"].ToString();
            txtYoutube.Text = tbl.Rows[0]["Youtube"].ToString();
            txtInstagram.Text = tbl.Rows[0]["Instagram"].ToString();
            txtFacebook.Text = tbl.Rows[0]["Facebook"].ToString();
            lblLogo.Text = tbl.Rows[0]["Logo"].ToString();
            txtBlogDetay.Text = tbl.Rows[0]["SiteOzet"].ToString();
            lblId.Text = tbl.Rows[0]["Id"].ToString();

            baglanti.Close();
            btnKaydet.Enabled = true;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update tblAyarlar set Mail=@Mail,Telefon=@Telefon,Adres=@Adres,Youtube=@Youtube,Instagram=@Instagram,Facebook=@Facebook,Logo=@Logo,SiteOzet=@SiteOzet where Id=@Id", baglanti);
            cmd.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
            cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text.ToString());
            cmd.Parameters.AddWithValue("@Adres", txtAdress.Text.ToString());
            cmd.Parameters.AddWithValue("@Youtube", txtYoutube.Text.ToString());
            cmd.Parameters.AddWithValue("@Instagram", txtInstagram.Text.ToString());
            cmd.Parameters.AddWithValue("@Facebook", txtFacebook.Text.ToString());
            cmd.Parameters.AddWithValue("@Logo", lblLogo.Text.ToString());
            cmd.Parameters.AddWithValue("@SiteOzet", txtBlogDetay.Text.ToString());
            cmd.Parameters.AddWithValue("@Id", lblId.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("Ayarlar.aspx");
        }
        protected void btnResimYukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string resimAd = FileUpload1.FileName.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/images/" + resimAd));
                    lblLogo.Text = resimAd.ToString();
                }
                else
                {
                    lblLogo.Text = "Lütfen uygun formatta bir resim seçiniz. ( JPEG , JPG , PNG )";
                }
            }
            else
            {
                lblLogo.Text = "Lütfen resim seçiniz.";
            }
            btnKaydet.Enabled = true;

        }
    }
}