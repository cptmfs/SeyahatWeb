using DTO.Modules.Seyehat;
using Entity.Seyehat;
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
    public partial class EgitimDetaySoruBaglanti : Page,IEgitimDetayFormuSoruBaglantiView
    {
        #region Presenter

        private EgitimDetayFormuSoruBaglantiPresenter _presenter;

        protected EgitimDetayFormuSoruBaglantiPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuSoruBaglantiPresenter(this)); }
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
            this.Presenter.TurListele();
            ViewState["Liste"] = "Default";
        }


        protected void gridEgitimDetayFormuSoruBaglanti_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimDetayFormuSoruBaglanti.PageIndex = e.NewPageIndex;

            switch (this.ListelemeViewState)
            {
                case 0:
                    this.Presenter.TurListele();
                    break;

            }
        }





        #endregion

        #region AJAX - WebMethod

        [WebMethod]
        public static List<EgitimDetayFormuSoruDTO> SoruListele() //Tüm konuları solda listeletmek için
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuSoruBaglanti;
            var presenter = new EgitimDetayFormuSoruBaglantiPresenter((IEgitimDetayFormuSoruBaglantiView)page);
            return presenter.SoruListele();
        }

        [WebMethod]
        public static List<EgitimDetayFormuSoruBaglantiDTO> SoruGetir(int TurId) //Seçilen konuları sağ tarafta listeletmek için
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuSoruBaglanti;
            var presenter = new EgitimDetayFormuSoruBaglantiPresenter((IEgitimDetayFormuSoruBaglantiView)page);
            return presenter.SoruGetir(TurId);
        }

        [WebMethod]
        public static void SorulariGonder(List<int> secilenler, int turId) //Seçilen konuları kaydetmek için
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuSoruBaglanti;
            var presenter = new EgitimDetayFormuSoruBaglantiPresenter((IEgitimDetayFormuSoruBaglantiView)page);
            presenter.SorulariGonder(secilenler, turId);
        }

        #endregion

        #region IEgitimDetayFormuSoruBaglantiView Member

        //public int SecilenEgitimDetayFormuSoruBaglantiId
        //{
        //    get
        //    {
        //        return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuSoruBaglantiId.Value)
        //         ? -1
        //         : int.Parse(hiddenSecilenEgitimDetayFormuSoruBaglantiId.Value);
        //    }
        //}


        public List<TanimDTO> TurListesi
        {
            set
            {
                gridEgitimDetayFormuSoruBaglanti.DataSource = value;
                gridEgitimDetayFormuSoruBaglanti.DataBind();
            }
        }

        #endregion
    }
}