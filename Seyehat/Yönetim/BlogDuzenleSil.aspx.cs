using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Presenter.Modules.Seyehat.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seyehat.Yönetim
{
    public partial class BlogDuzenleSil : System.Web.UI.Page,IBlogView
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

            ViewState["Liste"] = "Default";
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

        //[WebMethod]
        //public static AracTanimDTO AracListesiGetir(int AracListesiId)
        //{
        //    var page = HttpContext.Current.Handler as AracTanim;
        //    var presenter = new AracTanimPresenter(page);
        //    return presenter.AracTanimGetir(AracListesiId);
        //}


        //[WebMethod]
        //public static List<MerkezDTO> AltBirimListele(int merkezId)
        //{
        //    if (merkezId == -1) return new List<MerkezDTO>();

        //    var thisPage = HttpContext.Current.Handler as AracTanim;
        //    var presenter = new AracTanimPresenter(thisPage);
        //    return presenter.MerkezleriListele(merkezId);
        //}
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

        public List<BlogDTO> BlogListe
        {
            set
            {
                gridBlog.DataSource = value;
                gridBlog.DataBind();
            }
        }

        //public string PlakaAra
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtPlakaAra.Text) ? null : (txtPlakaAra.Text.Trim());
        //    }
        //}

        //public string MarkaAra
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtMarkaAra.Text) ? null : (txtMarkaAra.Text.Trim());
        //    }
        //}

        //public string ModelAra
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtModelAra.Text) ? null : (txtModelAra.Text.Trim());
        //    }
        //}

        //public int MerkezIdAra
        //{
        //    get
        //    {
        //        return drpMerkezListesiAra.SelectedIndex > 0 ? int.Parse(drpMerkezListesiAra.SelectedItem.Value) : -1;
        //    }
        //}

        //public int SecilenAracId
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(hiddenSecilenAracListesiId.Value)
        //           ? -1
        //           : int.Parse(hiddenSecilenAracListesiId.Value);
        //    }
        //}

        //public string Plaka
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtPlaka.Text) ? null : (txtPlaka.Text.Trim());
        //    }
        //}

        //public string Marka
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtMarka.Text) ? null : (txtMarka.Text.Trim());
        //    }
        //}

        //public string Model
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtModel.Text) ? null : (txtModel.Text.Trim());
        //    }
        //}

        //public int SonKm
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtKm.Text) ? 0 : int.Parse(txtKm.Text.Trim());
        //    }
        //}

        //public int MerkezId
        //{
        //    get
        //    {
        //        return drpMerkezList.SelectedIndex > 0 ? int.Parse(drpMerkezList.SelectedItem.Value) : -1;
        //    }
        //}

        //public int PersonelId
        //{
        //    get
        //    {
        //        return drpPersonelList.SelectedIndex > 0 ? int.Parse(drpPersonelList.SelectedItem.Value) : -1;
        //    }
        //}

        //public string Aciklama
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(txtAciklama.Text) ? null : (txtAciklama.Text.Trim());
        //    }
        //}

        //public bool Aktif
        //{
        //    get
        //    {
        //        return chkAktifYeni.Checked;
        //    }
        //}

        //public List<AracTanimDTO> AracListe
        //{
        //    set
        //    {
        //        gridAracListesi.DataSource = value;
        //        gridAracListesi.DataBind();
        //    }
        //}




        #endregion

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
    }
}