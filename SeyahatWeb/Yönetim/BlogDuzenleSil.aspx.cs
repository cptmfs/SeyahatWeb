using DTO.Modules.SeyehatWeb;
using Infrastructure.Enum;
using Infrastructure.Helper;
using Presenter.Modules.SeyehatWeb.Interface;
using Presenter.Modules.SeyehatWeb.Presenter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class BlogDuzenleSil : Page,IBlogView
    {
        #region Presenter

        private BlogPresenter _presenter;

        protected BlogPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new BlogPresenter(this)); }
        }

  

        #endregion

        #region Property

        public int ListelemeViewState
        {
            get { return Equals(ViewState["Liste"], "Default") ? 0 : 1; }
            set { ViewState["Liste"] = value; }
        }


        #endregion

        #region Page - Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            this.Presenter.BlogiListele();
            this.Presenter.KategoriListele();

            ViewState["Liste"] = "Default";
        }
        protected void btnYukle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(uploadBlogResmi.FileName))
            {
                try
                {
                    string[] contentTypes = { "image/jpeg", "image/pjpeg", "image/png", "image/bmp" };
                    FileInfo fi = new FileInfo(uploadBlogResmi.FileName);
                    string ext = fi.Extension;
                    if (contentTypes.Contains(uploadBlogResmi.PostedFile.ContentType))
                    {
                        if (uploadBlogResmi.PostedFile.ContentLength <= 1048576)
                        {
                            // Dosya adını oluştur
                            string resimAdi = String.Format("{0}.jpg", uploadBlogResmi.FileName);

                            // Resmi proje içindeki bir klasöre kaydet
                            string resimYolu = Server.MapPath("~/images/blog/") + resimAdi;


                            try
                            {
                                //Stream st = uploadBlogResmi.PostedFile.InputStream;
                                //S3SunucuTransferHelper.DosyaYukle(st, FotografUrl, ConfigurationManager.AppSettings["PersonelResimleriBucket"], "image/jpg");
                                uploadBlogResmi.SaveAs(resimYolu);
                                Resim=resimYolu;
                                Presenter.BlogResmiYukle();

                            }
                            catch
                            {
                                Resim = null;

                                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Fotoğraf Yüklenemedi",
                                                             "Kayıt işlemi yapıldı ancak fotoğraf yükleme işlemi sırasında bir hata oluştu.");

                                return;
                            }

                            MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Kayıt Başarılı",
                                                         "Kayıt işlemi başarıyla tamamlanmıştır.");

                        }
                        else
                        {
                            MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Uyari, "Fotoğraf Boyutu Büyük",
                                                             "Yüklenecek fotoğraf en fazla 1 MB büyüklüğünde olmalıdır.",
                                                             requireRefresh: false);
                        }
                    }
                    else
                    {
                        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Uyari, "Uyumsuz Dosya",
                                                             "Yüklenecek fotoğraf .jpeg, .jpg, .png ya da .bmp tipinde olmalıdır.",
                                                             requireRefresh: false);
                    }
                }
                catch (Exception exp)
                {
                    MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Hata Oluştu",
                                                 exp.InnerException.Message.Contains("UNIQUE KEY")
                                                     ? "Belirtilen başvuru sistemde kayıtlıdır."
                                                     : "Kayıt işlemi sırasında bir hata meydana geldi.",
                                                 requireRefresh: false);
                }
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Uyari, "Dosya Seçilmedi",
                                                                           "Yüklenecek dosyayı seçerek kaydet işlemine devam ediniz.",
                                                                           requireRefresh: false);
            }
        }

        protected void gridBlog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var blog = e.Row.DataItem as BlogDTO;

            if (blog == null) return;
            var resimyolu = "";
            var dosyaYolu = System.IO.Path.GetFileName(blog.Resim);
            // Resmin fiziksel yolu
            var resimFizikselYolu = "~/images/blog/" + dosyaYolu;
            if (resimFizikselYolu != null)
                resimyolu = resimFizikselYolu;
            else
                resimyolu = "/img/nopersonelimage.jpg";

            (e.Row.FindControl("BlogResim") as Image).ImageUrl = resimyolu;
        }
        protected void gridBlog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.BlogEkle();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.BlogiListele();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region AJAX - WebMethod
        [WebMethod]
        public static BlogDTO BlogGetirAjax(int BlogId)
        {
            var page = HttpContext.Current.Handler as BlogDuzenleSil;
            var presenter = new BlogPresenter(page);
            return presenter.BlogGetir(BlogId);
        }



        #endregion

        #region IBlogListView Member

        public string BlogAra
        {
            get
            {
                return String.IsNullOrWhiteSpace(Baslik) ? null : (Baslik.Trim());
            }
        }

        public int SecilenBlogId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenBlogId.Value)
                   ? -1
                   : int.Parse(hiddenSecilenBlogId.Value);
            }
        }

        public string Baslik
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtBaslik.Text) ? null : (txtBaslik.Text.Trim());
            }
        }

        public string Ozet
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtOzet.Text) ? null : (txtOzet.Text.Trim());
            }
        }

        public int? KategoriId
        {
            get
            {
                return drpBlogKategori.SelectedIndex >0 ? int.Parse(drpBlogKategori.SelectedItem.Value): -1;
            }
        }
        public string Resim
        {
            get; set;
        }

        public string Detay
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtDetay.Text) ? null : (txtDetay.Text.Trim());
            }
        }

        public DateTime? Tarih
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtTarih.Text)
                   ? (DateTime?)null
                   : DateTime.Parse(txtTarih.Text.Trim());
            }
        }
        public BlogKategoriDTO BlogKategori
        {
            get
            {
                return (drpBlogKategori.SelectedIndex == 0)
                           ? null
                           : new BlogKategoriDTO
                           {
                               Id = int.Parse(drpBlogKategori.SelectedItem.Value),
                               Ad = drpBlogKategori.SelectedItem.Text
                           };
            }
            set
            {
                drpBlogKategori.Visible = true;

                if (value == null)
                    drpBlogKategori.SelectedIndex = 0;
                else
                {
                    drpBlogKategori.SelectedIndex =
                        drpBlogKategori.Items.IndexOf(
                            drpBlogKategori.Items.FindByValue(value.Id.ToString()));

                    if (drpBlogKategori.SelectedIndex == 0)
                    {
                        drpBlogKategori.Visible = false;
                        drpBlogKategori.Visible = true;
                    }
                }
            }
        }
        public List<BlogKategoriDTO> KategoriListesi
        {
            set
            {
                drpBlogKategori.DataTextField = "Ad";
                drpBlogKategori.DataValueField = "Id";
                drpBlogKategori.DataSource = value;
                drpBlogKategori.DataBind();
            }
        }
        public List<BlogDTO> BlogListe
        {
            set
            {
                gridBlog.DataSource = value;
                gridBlog.DataBind();
            }
        }






        #endregion


    }
}