using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seyehat.Yönetim
{
    public partial class PaketEkle : System.Web.UI.Page
    {
        string congBaglanti = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType=="image/jpeg" || FileUpload1.PostedFile.ContentType=="image/jpg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string resimAd = FileUpload1.FileName.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/images/"+resimAd));
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
            SqlCommand cmd = new SqlCommand("Insert into tblTurPaket(Adi,Fiyat,Sure,Lokasyon,Resim,Detay) values (@Adi,@Fiyat,@Sure,@Lokasyon,@Resim,@Detay)", baglanti);
            cmd.Parameters.AddWithValue("@Adi",txtTurAd.Text.ToString());
            cmd.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(txtTurFiyat.Text.ToString()));
            cmd.Parameters.AddWithValue("@Sure", Convert.ToInt32(txtTurSure.Text.ToString()));
            cmd.Parameters.AddWithValue("@Lokasyon", txtTurKonum.Text.ToString());
            cmd.Parameters.AddWithValue("@Resim", lblResim.Text.ToString());
            cmd.Parameters.AddWithValue("@Detay", txtTurDetay.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("PaketDuzenleSil.aspx");
        }
    }
}