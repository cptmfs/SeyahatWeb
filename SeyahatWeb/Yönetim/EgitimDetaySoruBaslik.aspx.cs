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
    public partial class EgitimDetaySoruBaslik : Page, IEgitimDetayFormuSoruBaslikView
    {
        #region Presenter

        private EgitimDetayFormuSoruBaslikPresenter _presenter;

        protected EgitimDetayFormuSoruBaslikPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuSoruBaslikPresenter(this)); }
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
            this.Presenter.EgitimDetayFormuSoruBaslikListele();
            ViewState["Liste"] = "Default";
        }


        protected void gridEgitimDetayFormuSoruBaslik_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimDetayFormuSoruBaslik.PageIndex = e.NewPageIndex;

            switch (this.ListelemeViewState)
            {
                case 0:
                    this.Presenter.EgitimDetayFormuSoruBaslikListele();
                    break;

            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuSoruBaslikKayitEkle();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruBaslikListele();
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            var result = Presenter.EgitimDetayFormuSoruBaslikKayitGuncelle();
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruBaslikListele();
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

            var result = Presenter.EgitimDetayFormuSoruBaslikKayitSil();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Temizle();", true);
            if (result.Item1)
            {
                this.Presenter.EgitimDetayFormuSoruBaslikListele();
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
        public static EgitimDetayFormuSoruBaslikDTO EgitimDetayFormuSoruBaslikGetir(int EgitimDetayFormuSoruBaslikId)
        {
            var page = HttpContext.Current.Handler as Entity.Seyehat.EgitimDetayFormuSoruBaslik;
            var presenter = new EgitimDetayFormuSoruBaslikPresenter((IEgitimDetayFormuSoruBaslikView)page);
            return presenter.EgitimDetayFormuSoruBaslikGetir(EgitimDetayFormuSoruBaslikId);
        }

        #endregion

        #region IEgitimDetayFormuSoruBaslikView Member

        public int SecilenEgitimDetayFormuSoruBaslikId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuSoruBaslikId.Value)
                 ? -1
                 : int.Parse(hiddenSecilenEgitimDetayFormuSoruBaslikId.Value);
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

        public List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListesi
        {
            set
            {
                gridEgitimDetayFormuSoruBaslik.DataSource = value;
                gridEgitimDetayFormuSoruBaslik.DataBind();
            }
        }

        #endregion
       
    }
}