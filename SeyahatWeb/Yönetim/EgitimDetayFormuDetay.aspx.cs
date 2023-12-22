using DTO.Modules.Seyehat;
using Infrastructure.Enum;
using Infrastructure.Helper;
using Presenter.Modules.Seyehat.Interface;
using Presenter.Modules.Seyehat.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yönetim
{
    public partial class EgitimDetayFormuDetay : System.Web.UI.Page, IEgitimDetayFormuDetayView
    {
        #region Presenter

        private EgitimDetayFormuDetayPresenter _presenter;

        protected EgitimDetayFormuDetayPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new EgitimDetayFormuDetayPresenter(this)); }
        }

        #endregion

        #region Property
        public int ListelemeViewState
        {
            get { return Equals(ViewState["Liste"], "Default") ? 0 : 1; }
            set { ViewState["Liste"] = value; }
        }



        #endregion

        #region Ajax
        [WebMethod]
        public static List<VeriKaynagiDTO> VeriKaynagiListele(int formId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuDetay;
            var presenter = new EgitimDetayFormuDetayPresenter(page);
            return presenter.VeriKaynagiListele(formId);
        }
        [WebMethod]
        public static List<EgitimTuruDTO> EgitimTuruListele(int formId)
        {
            var page = HttpContext.Current.Handler as EgitimDetayFormuDetay;
            var presenter = new EgitimDetayFormuDetayPresenter(page);
            return presenter.EgitimTuruListele(formId);
        }
        #endregion

        #region Page - Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            this.Presenter.LabelDoldur();
            TabloOlustur();
            ViewState["Liste"] = "Default";
        }



        public void TabloOlustur()
        {
            var baslikListesi = this.Presenter.EgitimDetayFormuSoruBaslikListele();
            var kayitliListe = this.Presenter.EgitimDetayFormuDetayListeleByForm();
            var sorubaglanti = this.Presenter.EgitimDetayFormuSoruBaglantiListele();
            var sorular = this.Presenter.EgitimDetayFormuSoruListele();

            StringBuilder html = new StringBuilder();
            html.Append("<table class='table table-bordered table-responsive' style='vertical-align: middle; font-size:small'>");
            foreach (var baslik in baslikListesi)
            {
                html.Append("<tr bgcolor='#fcf8e3'>");
                html.Append("<th width='100%' colspan='16' >");
                html.Append(baslik.Tanim);
                html.Append("</th>");
                html.Append("</tr>");

                foreach (var sb in sorubaglanti)
                {
                    foreach (var soru in sorular.Where(s => s.EgitimDetayFormuSoruBaslikId == baslik.Id && s.Id == sb.EgitimDetayFormuSoruId))
                    {
                        html.Append("<tr>");
                        html.Append("<td width='20%' height='25px' colspan='4' bgcolor='#fcf8e3' font-weight:400 align='left'>");
                        html.Append(soru.Tanim);
                        html.Append("</td>");

                        var kayitliDeger = kayitliListe.Count() == 0 ? false : kayitliListe.Any(a => a.EgitimDetayFormuSoruBaglantiId == sb.Id);//Detayda bu soruya ait kayıt var mı?
                        var cevapTuru = soru.CevapTuru;

                        switch (cevapTuru)
                        {
                            case 1:   // cevap türü metinse 
                                if (kayitliDeger) // kayıt varsa doldur
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<textarea rows=\"" + soru.TxtSatirSayisi + "\"  name=\"txt" + sb.Id + "\"   class=\"form-control\"  \" >");
                                    html.Append(kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault().Cevap);
                                    html.Append("</textarea>");
                                    html.Append("</td>");
                                }
                                else // kayıt yoksa boş txt
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<textarea rows=\"" + soru.TxtSatirSayisi + "\" name=\"txt" + sb.Id + "\"   class=\"form-control\" \">");
                                    html.Append("</textarea>");
                                    html.Append("</td>");
                                }

                                break;

                            case 2:   // cevap türü radioButton Var / Yok / Bilinmiyor

                                var var = "";
                                var yok = "";
                                var bilinmiyor = "";

                                if (kayitliDeger)  // kayıt varsa doldur
                                {
                                    var kayitliCevap = kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault();

                                    if (kayitliCevap.Cevap == "1") // Var seçeneği ise
                                        var = "checked";
                                    else if (kayitliCevap.Cevap == "2") // Bilinmiyor seçeneği ise
                                        bilinmiyor = "checked";
                                    else if (kayitliCevap.Cevap == "0") // Yok seçeneği ise
                                        yok = "checked";
                                }

                                html.Append("<td width='20%' height='25px' align=\"center\" colspan='4'>");
                                html.Append("<input type=\"radio\" id=\"var\" name=\"rdVarYok" + sb.Id + "\"  value=\"1\" " + var + ">");
                                html.Append("<label for=\"var\"> Var </label>");
                                html.Append("</td>");

                                html.Append("<td width='20%' height='25px' align=\"center\" colspan='4'>");
                                html.Append("<input type=\"radio\" id=\"yok\" name=\"rdVarYok" + sb.Id + "\"  value=\"0\" " + yok + ">");
                                html.Append("<label for=\"yok\"> Yok </label>");
                                html.Append("</td>");

                                html.Append("<td width='20%' height='25px' align=\"center\" colspan='4'>");
                                html.Append("<input type=\"radio\" id=\"bilinmiyor\" name=\"rdVarYok" + sb.Id + "\"  value=\"2\" " + bilinmiyor + ">");
                                html.Append("<label for=\"bilinmiyor\"> Bilinmiyor </label>");
                                html.Append("</td>");
                                break;

                            case 3:   // cevap türü dropdown

                                var secenekList = this.Presenter.EgitimDetayFormuSoruSecenekleriListele(soru.Id);
                                var kayitliCvp = kayitliDeger ? kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault() : null;

                                html.Append("<td width='80%' height='25px' colspan='12'>");
                                html.Append("<select class=\"form-control\" name=\"nm" + sb.Id + "\" id=\"drp" + sb.Id + "\" > ");
                                html.Append("<option value=\"-1\" > Seçiniz..  </option>");
                                foreach (var secenek in secenekList)
                                {
                                    if (kayitliCvp == null)
                                        html.Append("<option value=\"" + secenek.Id + "\" > " + secenek.Tanim + " </option>");
                                    else if (kayitliCvp.Cevap == secenek.Id.ToString())
                                        html.Append("<option value=\"" + secenek.Id + "\" selected> " + secenek.Tanim + " </option>");

                                }

                                html.Append("</select>");
                                html.Append("</td>");
                                break;

                            case 4:   // cevap türü kısa metinse 
                                if (kayitliDeger) // kayıt varsa doldur
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<textarea rows=\"" + soru.TxtSatirSayisi + "\" name=\"txt" + sb.Id + "\"  class=\"form-control\" \"  >");
                                    html.Append(kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault().Cevap);
                                    html.Append("</textarea>");
                                    html.Append("</td>");
                                }
                                else // kayıt yoksa boş txt
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<textarea rows=\"" + soru.TxtSatirSayisi + "\" name=\"txt" + sb.Id + "\"   class=\"form-control\" \">");
                                    html.Append("</textarea>");
                                    html.Append("</td>");
                                }

                                break;

                            case 5:   // cevap türü tarihdr 
                                if (kayitliDeger) // kayıt varsa doldur
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"date\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" \" value=\"" + kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault().Cevap + "\" >");

                                    html.Append("</td>");
                                }
                                else // kayıt yoksa boş txt
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"date\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" >");

                                    html.Append("</td>");
                                }

                                break;

                            case 6:   // cevap türü tarih saattir 
                                if (kayitliDeger) // kayıt varsa doldur
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"datetime-local\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" \" value=\"" + kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault().Cevap + "\" >");

                                    html.Append("</td>");
                                }
                                else // kayıt yoksa boş txt
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"datetime-local\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" >");

                                    html.Append("</td>");
                                }

                                break;

                            case 7:   // cevap türü rakamsa
                                if (kayitliDeger) // kayıt varsa doldur
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"number\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" \" value=\"" + kayitliListe.Where(k => k.EgitimDetayFormuSoruBaglantiId == sb.Id).FirstOrDefault().Cevap + "\" >");
                                    html.Append("</td>");
                                }
                                else // kayıt yoksa boş txt
                                {
                                    html.Append("<td width='80%' height='25px' colspan='12'>");
                                    html.Append("<input type=\"number\" style=\"width: 200px\" name=\"txt" + sb.Id + "\"  class=\"form-control\" >");
                                    html.Append("</td>");
                                }

                                break;

                        }

                        html.Append("</tr>");

                    }
                }
                //bool secenekKoy = false;


            }
            html.Append("</table>");

            litTable.Text = html.ToString();

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var sorubaglanti = this.Presenter.EgitimDetayFormuSoruBaglantiListele();
            var sorular = this.Presenter.EgitimDetayFormuSoruListele();
            List<EgitimDetayFormuDetayDTO> liste = new List<EgitimDetayFormuDetayDTO>();
            string cvp = "";
            foreach (var sb in sorubaglanti)
            {
                foreach (var soru in sorular.Where(s => s.Id == sb.EgitimDetayFormuSoruId))
                {
                    switch (soru.CevapTuru)
                    {
                        case 1:
                            var text = Request.Form["txt" + sb.Id];
                            cvp = text == null ? "" : text.ToString();
                            break;

                        case 2:
                            var rdVarYok = Request.Form["rdVarYok" + sb.Id];
                            cvp = rdVarYok == null ? "" : rdVarYok.ToString();
                            break;

                        case 3:
                            var drp = Request.Form["nm" + sb.Id];
                            if (drp != "-1")
                                cvp = drp == null ? "" : drp.ToString();
                            break;
                        case 4:
                            var text2 = Request.Form["txt" + sb.Id];
                            cvp = text2 == null ? "" : text2.ToString();
                            break;
                        case 5:
                            var text3 = Request.Form["txt" + sb.Id];
                            cvp = text3 == null ? "" : text3.ToString();
                            break;
                        case 6:
                            var text4 = Request.Form["txt" + sb.Id];
                            cvp = text4 == null ? "" : text4.ToString();
                            break;
                        case 7:
                            var text5 = Request.Form["txt" + sb.Id];
                            cvp = text5 == null ? "" : text5.ToString();
                            break;

                    }

                    if (!String.IsNullOrWhiteSpace(cvp))
                    {
                        var yeniDetay = new EgitimDetayFormuDetayDTO()
                        {
                            EgitimDetayFormuSoruBaglantiId = sb.Id,
                            EgitimDetayFormuId = SecilenEgitimDetayFormuId,
                            Cevap = cvp
                        };

                        liste.Add(yeniDetay);
                    }
                }
            }


            // Kullanıcı Ekleme İşlemi Başarılı Oldu ise...
            var result = Presenter.DegisiklikleriKaydet(liste);

            if (result.Item1)
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Basari, "Başarılı", result.Item2, requireRefresh: true);
            }
            else
            {
                MesajHelper.PopupMesajGoster(this, PopupMesajTipleri.Hata, "Başarısız", result.Item2, requireRefresh: false);
            }

            this.Presenter.EgitimDetayFormuDetayListeleByForm();
        }

        #endregion

        #region IEgitimDetayFormuDetayView Member


        public int SecilenEgitimDetayFormuId
        {
            get
            {
                int olayBilgiFormuId = -1;
                if (!String.IsNullOrWhiteSpace(Request.QueryString["olayBilgiFormuId"]))
                    olayBilgiFormuId = int.Parse(Request.QueryString["olayBilgiFormuId"]);
                return olayBilgiFormuId;
            }
        }

        public string LblMerkez
        {
            set
            {
                lblBirim.Text = value;
            }
        }

        public string LblOlusturulmaTarihi
        {
            set
            {
                lblOlusturulmaTarihi.Text = value;
            }
        }

        public string LblOlusturanKullanici
        {
            set
            {
                lblOlusturanKullanici.Text = value;
            }
        }

        #endregion
    }
}