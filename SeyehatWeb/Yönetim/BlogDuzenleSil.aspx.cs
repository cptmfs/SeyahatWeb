using DTO.Modules.SeyehatWeb;
using Presenter.Modules.SeyehatWeb.Interface;
using Presenter.Modules.SeyehatWeb.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyehatWeb.Yönetim
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
        protected void gridBlog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }

        //protected void btnAra_Click(object sender, EventArgs e)
        //{
        //    ViewState["Liste"] = "Search";
        //    this.Presenter.AramaSonuclariniListele();
        //}

        //protected void btnKaydet_Click(object sender, EventArgs e)
        //{
        //    if (!Page.IsValid) return;

        //    // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
        //    var result = Presenter.AracTanimKayitEkle();

        //    if (result.Item1)
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
        //    }
        //    else
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
        //    }

        //    this.Presenter.AraclariListele(SessionHelper.MerkezId);
        //}

        //protected void gridAracListesi_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gridAracListesi.PageIndex = e.NewPageIndex;

        //    switch (this.ListelemeViewState)
        //    {
        //        case 0:
        //            this.Presenter.AraclariListele(SessionHelper.MerkezId);
        //            break;
        //        case 1:
        //            this.Presenter.AramaSonuclariniListele(SessionHelper.MerkezId);
        //            break;
        //    }
        //}

        //protected void btnGuncelle_Click(object sender, EventArgs e)
        //{
        //    if (!Page.IsValid) return;


        //    var result = Presenter.AracTanimKayitGuncelle();
        //    if (result.Item1)
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Güncellendi", result.Item2, requireRefresh: true);
        //    }
        //    else
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
        //    }

        //    this.Presenter.AracListele(SecilenAracId, SessionHelper.MerkezId);

        //}

        //protected void btnSil_Click(object sender, EventArgs e)
        //{
        //    if (!Page.IsValid) return;


        //    var result = Presenter.AracTanimKayitSil();
        //    if (result.Item1)
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Silindi", result.Item2, requireRefresh: true);
        //    }
        //    else
        //    {
        //        MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
        //    }
        //    this.Presenter.AraclariListele(SessionHelper.MerkezId);
        //}
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
                return String.IsNullOrWhiteSpace(Baslik) ? null : (Baslik.Trim());
            }
        }

        public string Ozet
        {
            get
            {
                return String.IsNullOrWhiteSpace(Ozet) ? null : (Ozet.Trim());
            }
        }

        public int? KategoriId
        {
            get
            {
                return KategoriId.Value > 0 ? KategoriId.Value : -1;
            }
        }
        public string Resim
        {
            get
            {
                return String.IsNullOrWhiteSpace(Resim) ? null : (Resim.Trim());
            }
        }

        public string Detay
        {
            get
            {
                return String.IsNullOrWhiteSpace(Detay) ? null : (Detay.Trim());
            }
        }

        public DateTime? Tarih
        {
            get
            {
                return String.IsNullOrWhiteSpace(Tarih.ToString()) ? null : Tarih;
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