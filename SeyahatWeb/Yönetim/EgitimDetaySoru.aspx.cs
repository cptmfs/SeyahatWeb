using DTO.Modules.Seyehat;
using Entity.Seyehat;
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
    public partial class EgitimDetaySoru : System.Web.UI.Page,IEgitimDetayFormuSoruView
    {
        #region Presenter

        private EgitimDetayFormuSoruPresenter _presenter;

        protected EgitimDetayFormuSoruPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuSoruPresenter(this)); }
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
            if (Page.IsPostBack) return;
            this.Presenter.EgitimDetayFormuSoruListele();
            this.Presenter.EgitimDetayFormuSoruBaslikListele();
            ViewState["Liste"] = "Default";
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            ViewState["Liste"] = "Search";
            Presenter.AramaSonuclariniListele();
        }

        protected void gridEgitimDetayFormuSoru_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimDetayFormuSoru.PageIndex = e.NewPageIndex;

            switch (this.ListelemeViewState)
            {
                case 0:
                    this.Presenter.EgitimDetayFormuSoruListele();
                    break;
                case 1:
                    this.Presenter.AramaSonuclariniListele();
                    break;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuSoruKayitEkle();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruListele();
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: false);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }


        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var result = Presenter.EgitimDetayFormuSoruKayitGuncelle();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruListele();
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Güncellendi", result.Item2, requireRefresh: false);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var result = Presenter.EgitimDetayFormuSoruKayitSil();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruListele();
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Silindi", result.Item2, requireRefresh: false);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

        }

        #endregion

        #region AJAX - WebMethod

        [WebMethod]
        public static EgitimDetayFormuSoruDTO EgitimDetayFormuSoruGetir(int EgitimDetayFormuSoruId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuSoru;
            var presenter = new EgitimDetayFormuSoruPresenter((IEgitimDetayFormuSoruView)page);
            return presenter.EgitimDetayFormuSoruGetir(EgitimDetayFormuSoruId);
        }

        #endregion

        #region IEgitimDetayFormuSoruView Member
        public int? AramaSoruTuru
        {
            get
            {
                return drpSoruTuruArama.SelectedIndex > 0 ? int.Parse(drpSoruTuruArama.SelectedItem.Value) : -1;
            }
        }

        public int SecilenEgitimDetayFormuSoruId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuSoruId.Value)
                 ? -1
                 : int.Parse(hiddenSecilenEgitimDetayFormuSoruId.Value);
            }
        }

        public string Tanim
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtTanim.Text) ? null : (txtTanim.Text.Trim());
            }
        }

        public int? EgitimDetayFormuSoruBaslikId
        {
            get
            {
                return drpSoruTuru.SelectedIndex > 0 ? int.Parse(drpSoruTuru.SelectedItem.Value) : -1;
            }
        }

        public int? CevapTuru
        {
            get
            {
                return drpCevapTuru.SelectedIndex > 0 ? int.Parse(drpCevapTuru.SelectedItem.Value) : -1;
            }
        }
        public int? Sira
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtSira.Text) ? (int?)null : Convert.ToInt32(txtSira.Text.Trim());
            }
        }
        public int? TxtSatirSayisi
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtSatirSayisi.Text) ? (int?)null : Convert.ToInt32(txtSatirSayisi.Text.Trim());
            }
        }
        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListesi
        {
            set
            {
                gridEgitimDetayFormuSoru.DataSource = value;
                gridEgitimDetayFormuSoru.DataBind();
            }
        }
        public List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListesi
        {
            set
            {
                drpSoruTuru.DataValueField = "Id";
                drpSoruTuru.DataTextField = "Tanim";
                drpSoruTuru.DataSource = value;
                drpSoruTuru.DataBind();

                drpSoruTuruArama.DataValueField = "Id";
                drpSoruTuruArama.DataTextField = "Tanim";
                drpSoruTuruArama.DataSource = value;
                drpSoruTuruArama.DataBind();
            }
        }
        #endregion
    }
}