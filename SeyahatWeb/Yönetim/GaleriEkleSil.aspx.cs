using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class GaleriEkleSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResimYukle_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string resimAd = FileUpload1.FileName.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/images/galeri/" + resimAd));
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

        protected void btnKaydet2_Click(object sender, EventArgs e)
        {

        }
    }
}