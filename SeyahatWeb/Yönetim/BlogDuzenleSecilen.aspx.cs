using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class BlogDuzenleSecilen : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;
        public string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = false;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(congBaglanti);
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update tblBlog set Baslik=@Baslik,Ozet=@Ozet,KategoriId=@KategoriId,Resim=@Resim,Detay=@Detay,Tarih=@Tarih where Id=@Id", baglanti);
            cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.ToString());
            cmd.Parameters.AddWithValue("@Ozet", txtOzet.Text.ToString());
            cmd.Parameters.AddWithValue("@KategoriId", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Resim", lblResim.Text.ToString());
            cmd.Parameters.AddWithValue("@Detay", txtBlogDetay.Text.ToString());
            cmd.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(lblTarih.Text.ToString()));
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("BlogDuzenleSil.aspx");
        }

        protected void btnYukle_Click(object sender, EventArgs e)
        {
                SqlConnection baglanti = new SqlConnection(congBaglanti);
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblBlog where Id=@Id", baglanti);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                SqlDataReader read = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Load(read);
                txtBaslik.Text = tbl.Rows[0]["Baslik"].ToString();
                txtOzet.Text = tbl.Rows[0]["Ozet"].ToString();
                DropDownList1.SelectedValue = tbl.Rows[0]["KategoriId"].ToString();
                lblResim.Text = tbl.Rows[0]["Resim"].ToString();
                txtBlogDetay.Text = tbl.Rows[0]["Detay"].ToString();
                lblTarih.Text = tbl.Rows[0]["Tarih"].ToString();

                baglanti.Close();
                btnGuncelle.Enabled = true;

        }

        protected void resimYukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string resimAd = FileUpload1.FileName.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/images/blog" + resimAd));
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
            btnGuncelle.Enabled = true;
        }
    }
}