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
    public partial class EgitimDetaySoruSecenekleri : Page, IEgitimDetayFormuSoruSecenekleriView
    {
        #region Presenter

        private EgitimDetayFormuSoruSecenekleriPresenter _presenter;

        protected EgitimDetayFormuSoruSecenekleriPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuSoruSecenekleriPresenter(this)); }
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
            this.Presenter.EgitimDetayFormuSoruSecenekleriListele();
            this.Presenter.EgitimDetayFormuSoruListele();
            ViewState["Liste"] = "Default";
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            ViewState["Liste"] = "Search";
            Presenter.AramaSonuclariniListele();
        }
        protected void gridEgitimDetayFormuSoruSecenekleri_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimDetayFormuSoruSecenekleri.PageIndex = e.NewPageIndex;

            switch (this.ListelemeViewState)
            {
                case 0:
                    this.Presenter.EgitimDetayFormuSoruSecenekleriListele();
                    break;

            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuSoruSecenekleriKayitEkle();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruSecenekleriListele();
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

            var result = Presenter.EgitimDetayFormuSoruSecenekleriKayitGuncelle();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruSecenekleriListele();
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

            var result = Presenter.EgitimDetayFormuSoruSecenekleriKayitSil();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruSecenekleriListele();
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
        public static EgitimDetayFormuSoruSecenekleriDTO EgitimDetayFormuSoruSecenekleriGetir(int EgitimDetayFormuSoruSecenekleriId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuSoruSecenekleri;
            var presenter = new EgitimDetayFormuSoruSecenekleriPresenter((IEgitimDetayFormuSoruSecenekleriView)page);
            return presenter.EgitimDetayFormuSoruSecenekleriGetir(EgitimDetayFormuSoruSecenekleriId);
        }

        #endregion

        #region IEgitimDetayFormuSoruSecenekleriView Member

        public int SecilenEgitimDetayFormuSoruSecenekleriId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuSoruSecenekleriId.Value)
                 ? -1
                 : int.Parse(hiddenSecilenEgitimDetayFormuSoruSecenekleriId.Value);
            }
        }

        public string Tanim
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtTanim.Text) ? null : (txtTanim.Text.Trim());
            }
        }


        public int? Sira
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtSira.Text) ? (int?)null : Convert.ToInt32(txtSira.Text.Trim());
            }
        }

        public List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListesi
        {
            set
            {
                gridEgitimDetayFormuSoruSecenekleri.DataSource = value;
                gridEgitimDetayFormuSoruSecenekleri.DataBind();
            }
        }
        public int? EgitimDetayFormuSoruId
        {
            get
            {
                return drpSoru.SelectedIndex > 0 ? int.Parse(drpSoru.SelectedItem.Value) : -1;
            }
        }

        public int? AramaSoruTanim
        {
            get
            {
                return drpSoruTanimArama.SelectedIndex > 0 ? int.Parse(drpSoruTanimArama.SelectedItem.Value) : -1;
            }
        }

        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListesi
        {
            set
            {
                drpSoru.DataValueField = "Id";
                drpSoru.DataTextField = "Tanim";
                drpSoru.DataSource = value;
                drpSoru.DataBind();

                drpSoruTanimArama.DataValueField = "Id";
                drpSoruTanimArama.DataTextField = "Tanim";
                drpSoruTanimArama.DataSource = value;
                drpSoruTanimArama.DataBind();
            }
        }
        #endregion
    }
}