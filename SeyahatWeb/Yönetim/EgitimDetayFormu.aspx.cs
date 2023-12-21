using DTO.Modules.Seyehat;
using DTO.Modules.SeyehatWeb;
using Infrastructure.Enum;
using Infrastructure.Helper;
using Presenter.Modules.Seyehat.Interface;
using Presenter.Modules.Seyehat.Presenter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class EgitimDetayFormu :Page, IEgitimDetayFormuView
    {
        #region Presenter

        private EgitimDetayFormuPresenter _presenter;

        protected EgitimDetayFormuPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuPresenter(this)); }
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
            this.Presenter.LabelDoldur();
            drpMerkez.SelectedValue = SessionHelper.KullaniciAdi.ToString();
            ViewState["Liste"] = "Default";
        }

        protected void gridEgitimDetayFormu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEgitimDetayFormu.PageIndex = e.NewPageIndex;
            this.Presenter.EgitimDetayFormuListele();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuKayitEkle();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.EgitimDetayFormuListele();
        }


        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var result = Presenter.EgitimDetayFormuKayitSil();
            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Silindi", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }
            this.Presenter.EgitimDetayFormuListele();
        }

        #endregion

        #region AJAX - WebMethod

        [WebMethod]
        public static EgitimDetayFormuDTO EgitimDetayFormuGetir(int EgitimDetayFormuId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormu;
            var presenter = new EgitimDetayFormuPresenter(page);
            return presenter.EgitimDetayFormuGetir(EgitimDetayFormuId);
        }
        [WebMethod]
        public static List<EgitimDetayFormuGuncellemeDTO> EgitimDetayFormuGuncellemeListele(int formId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormu;
            var presenter = new EgitimDetayFormuPresenter(page);
            return presenter.EgitimDetayFormuGuncellemeListele(formId);
        }
        [WebMethod]
        public static EgitimDetayFormuGuncellemeDTO EgitimDetayFormuGuncellemeGetir(int EgitimDetayFormuGuncellemeId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormu;
            var presenter = new EgitimDetayFormuPresenter(page);
            return presenter.EgitimDetayFormuGuncellemeGetir(EgitimDetayFormuGuncellemeId);
        }

        #endregion

        #region IEgitimDetayFormuView Member

        public int SecilenEgitimDetayFormuId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuId.Value)
                  ? -1
                  : int.Parse(hiddenSecilenEgitimDetayFormuId.Value);
            }
        }
        public int SecilenEgitimDetayFormuGuncellemeId
        {
            get
            {
                return String.IsNullOrWhiteSpace(hiddenSecilenEgitimDetayFormuGuncellemeId.Value)
                  ? -1
                  : int.Parse(hiddenSecilenEgitimDetayFormuGuncellemeId.Value);
            }
        }
        public string Aciklama
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtAciklama.Text) ? null : (txtAciklama.Text.Trim());
            }
        }
        public List<EgitimDetayFormuDTO> EgitimDetayFormuListesi
        {
            set
            {
                gridEgitimDetayFormu.DataSource = value;
                gridEgitimDetayFormu.DataBind();
            }
        }
        
        public int MerkezArama
        {
            get
            {
                return -1;
            }
        }

        public string LblMerkez
        {
            set
            {
                lblBirim.Text = value;
            }
        }

        public int KullaniciAdi
        {
            get
            {
                return -1;
            }
        }
        public int Tur
        {
            get
            {
                return drpTur.SelectedIndex > 0 ? int.Parse(drpTur.SelectedItem.Value) : -1;
            }
        }





    #endregion


    protected void btnGuncellemeSil_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuGuncellemeKayitSil();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.EgitimDetayFormuListele();
        }

        protected void btnGuncellemeKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuGuncellemeKayitEkle();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.EgitimDetayFormuListele();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.EgitimDetayFormuGuncellemeKayitGuncelle();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.EgitimDetayFormuListele();
        }

        protected void gridEgitimDetayFormu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var form = e.Row.DataItem as EgitimDetayFormuDTO;
            var acKapat = e.Row.FindControl("A2") as HtmlAnchor;
            var acKapatIkon = e.Row.FindControl("acKapatIkon") as HtmlImage;
            var sil = e.Row.FindControl("A3") as HtmlAnchor;

            if (form == null) return;

            if (form.Aktif.Value)
            {
                e.Row.Cells[6].BackColor = Color.FromName("yellowGreen");
                acKapatIkon.Attributes.Add("src", "/img/gCons/lock.png");
                acKapat.Attributes.Add("title", "Süreci Sonlandır");

            }

            else
            {
                e.Row.Cells[6].BackColor = Color.FromName("tomato");
                acKapat.Attributes.Add("title", "Süreci Yeniden Başlat");
                acKapatIkon.Attributes.Add("src", "/img/gCons/unlock.png");
                sil.Attributes.Remove("data-bs-toggle");
                sil.Attributes.Add("title", "Eğitim Detay Formu sonlandırıldığı için silme işlemi yapılamaz. ");
                sil.Attributes.Remove("href");
            }

        }

        protected void btnFormAcKapat_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.FormAcKapat();

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }
            this.Presenter.EgitimDetayFormuListele();
        }
    }
}