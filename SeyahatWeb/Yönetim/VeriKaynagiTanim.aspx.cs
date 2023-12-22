using DTO.Modules.Seyehat;
using Infrastructure.Enum;
using Infrastructure.Helper;
using Presenter.Modules.Seyehat.Interface;
using Presenter.Modules.Seyehat.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class VeriKaynagiTanim : Page, IVeriKaynagiView
    {
        #region Presenter

        private VeriKaynagiPresenter _presenter;

        protected VeriKaynagiPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new VeriKaynagiPresenter(this)); }
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

            this.Presenter.VeriKaynaklariniListele();
            ViewState["Liste"] = "Default";
        }

        protected void gridVeriKaynagiListesi_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridVeriKaynagiListesi.PageIndex = e.NewPageIndex;

            switch (this.ListelemeViewState)
            {
                case 0:
                    this.Presenter.VeriKaynaklariniListele();
                    break;
                case 1:
                    this.Presenter.AramaSonuclariniListele();
                    break;
            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            ViewState["Liste"] = "Search";
            this.Presenter.AramaSonuclariniListele();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.VeriKaynagiKayitEkle();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.VeriKaynaklariniListele();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var result = Presenter.VeriKaynagiKayitGuncelle();
            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Güncellendi", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.VeriKaynaklariniListele();
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var result = Presenter.VeriKaynagiKayitSil();
            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Silindi", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.VeriKaynaklariniListele();
        }

        #endregion

        #region AJAX - WebMethod

        [WebMethod]

        public static VeriKaynagiDTO VeriKaynagiGetir(int VeriKaynagiId)
        {
            var page = HttpContext.Current.Handler as VeriKaynagiTanim;
            var presenter = new VeriKaynagiPresenter(page);
            return presenter.VeriKaynagiGetir(VeriKaynagiId);
        }

        #endregion

        #region IOlumNedeniView Members        


        public string TanimAra
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtAdAra.Text) ? null : (txtAdAra.Text.Trim());
            }
        }


        public int SecilenVeriKaynagiId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenVeriKaynagiId.Value)
                        ? -1
                        : int.Parse(hiddenSecilenVeriKaynagiId.Value);
            }

        }

        public string Tanim
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtAd.Text) ? null : (txtAd.Text.Trim());
            }
        }

        public List<VeriKaynagiDTO> VeriKaynagiListesi
        {
            set
            {
                gridVeriKaynagiListesi.DataSource = value;
                gridVeriKaynagiListesi.DataBind();
            }
        }

        #endregion
    }
}