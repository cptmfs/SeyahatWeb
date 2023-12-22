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
    public partial class EgitimTuruTanim : Page, IEgitimTuruView
    {
        #region Presenter

        private EgitimTuruPresenter _presenter;

        protected EgitimTuruPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimTuruPresenter(this)); }
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

        protected void gridEgitimTuruListesi_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimTuruListesi.PageIndex = e.NewPageIndex;

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
            var result = Presenter.EgitimTuruKayitEkle();

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

            var result = Presenter.EgitimTuruKayitGuncelle();
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

            var result = Presenter.EgitimTuruKayitSil();
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

        public static EgitimTuruDTO EgitimTuruGetir(int EgitimTuruId)
        {
            var page = HttpContext.Current.Handler as EgitimTuruTanim;
            var presenter = new EgitimTuruPresenter(page);
            return presenter.EgitimTuruGetir(EgitimTuruId);
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


        public int SecilenEgitimTuruId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimTuruId.Value)
                        ? -1
                        : int.Parse(hiddenSecilenEgitimTuruId.Value);
            }

        }

        public string Tanim
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtAd.Text) ? null : (txtAd.Text.Trim());
            }
        }

        public List<EgitimTuruDTO> EgitimTuruListesi
        {
            set
            {
                gridEgitimTuruListesi.DataSource = value;
                gridEgitimTuruListesi.DataBind();
            }
        }

        #endregion
    }
}