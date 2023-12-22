using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Service.Modules.Seyehat;
using Service.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Presenter
{
    public class EgitimDetayFormuDetayPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuDetayView View { get; private set; }

        public EgitimDetayFormuDetayPresenter(IEgitimDetayFormuDetayView view)
        {
            View = view;
        }

        #endregion      

        #region Service

        private EgitimDetayFormuDetayService _olayBilgiFormuDetayService;
        protected EgitimDetayFormuDetayService EgitimDetayFormuDetayService
        {
            get { return _olayBilgiFormuDetayService ?? (_olayBilgiFormuDetayService = new EgitimDetayFormuDetayService()); }
        }
        private EgitimDetayFormuService _olayBilgiFormuService;
        protected EgitimDetayFormuService EgitimDetayFormuService
        {
            get { return _olayBilgiFormuService ?? (_olayBilgiFormuService = new EgitimDetayFormuService()); }
        }
        private EgitimDetayFormuSoruService _olayBilgiFormuSoruService;
        protected EgitimDetayFormuSoruService EgitimDetayFormuSoruService
        {
            get { return _olayBilgiFormuSoruService ?? (_olayBilgiFormuSoruService = new EgitimDetayFormuSoruService()); }
        }
        private VeriKaynagiService _veriKaynagiService;
        protected VeriKaynagiService VeriKaynagiService
        {
            get { return _veriKaynagiService ?? (_veriKaynagiService = new VeriKaynagiService()); }
        }  
        private EgitimDetayFormuSoruBaslikService _olayBilgiFormuSoruBaslikService;
        protected EgitimDetayFormuSoruBaslikService EgitimDetayFormuSoruBaslikService
        {
            get { return _olayBilgiFormuSoruBaslikService ?? (_olayBilgiFormuSoruBaslikService = new EgitimDetayFormuSoruBaslikService()); }
        }
        private EgitimDetayFormuSoruSecenekleriService _olayBilgiFormuSoruSecenekleriService;
        protected EgitimDetayFormuSoruSecenekleriService EgitimDetayFormuSoruSecenekleriService
        {
            get { return _olayBilgiFormuSoruSecenekleriService ?? (_olayBilgiFormuSoruSecenekleriService = new EgitimDetayFormuSoruSecenekleriService()); }
        }
        private KullaniciService _kullaniciService;

        protected KullaniciService KullaniciService
        {
            get { return _kullaniciService ?? (_kullaniciService = new KullaniciService()); }
        }

        private EgitimDetayFormuSoruBaglantiService _olayBilgiFormuSoruBaglantiService;
        protected EgitimDetayFormuSoruBaglantiService EgitimDetayFormuSoruBaglantiService
        {
            get { return _olayBilgiFormuSoruBaglantiService ?? (_olayBilgiFormuSoruBaglantiService = new EgitimDetayFormuSoruBaglantiService()); }
        }
        private EgitimTuruService _egitimTuruService;
        protected EgitimTuruService EgitimTuruService
        {
            get { return _egitimTuruService ?? (_egitimTuruService = new EgitimTuruService()); }
        }
        #endregion

        #region Methods

        public void LabelDoldur()
        {
            var form = EgitimDetayFormuService.EgitimDetayFormuGetir(View.SecilenEgitimDetayFormuId);

            View.LblOlusturulmaTarihi = form.OlusturulmaTarihi.ToShortDateString();
            View.LblOlusturanKullanici = KullaniciService.KullaniciGetir(form.OlusturanKullanici.Value).Name;
        }

        public List<EgitimDetayFormuDetayDTO> EgitimDetayFormuDetayListeleByForm()
        {
            return EgitimDetayFormuDetayService.EgitimDetayFormuDetayListeleByForm(View.SecilenEgitimDetayFormuId);

        }
        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListele()
        {
            return EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele();

        }
        public List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListele()
        {
            return EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikListele();

        }
        public List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListele()
        {
            var form = EgitimDetayFormuService.EgitimDetayFormuGetir(View.SecilenEgitimDetayFormuId);
            return EgitimDetayFormuSoruBaglantiService.EgitimDetayFormuSoruBaglantiListeleByTur(form.Tur.Value, true);

        }
        public List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListele(int soruId)
        {
            return EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriListeleBySoru(soruId);

        }
        public Tuple<bool, string> DegisiklikleriKaydet(List<EgitimDetayFormuDetayDTO> liste)
        {
            return EgitimDetayFormuDetayService.EgitimDetayFormuDetayTopluIslem(liste, View.SecilenEgitimDetayFormuId);
        }

        public List<VeriKaynagiDTO> VeriKaynagiListele(int formId)
        {
            var liste = VeriKaynagiService.VeriKaynaklariniList();
            var formDetay = EgitimDetayFormuDetayService.EgitimDetayFormuDetayGetirForVeriKaynagi(formId);
            if (formDetay != null)
            {
                foreach (var item in liste)
                {
                    if (item.Id == int.Parse(formDetay.Cevap))
                        item.SeciliMi = true;
                    else
                        item.SeciliMi = false;
                }
            }

            return liste;

        }
        public List<EgitimTuruDTO> EgitimTuruListele(int formId)
        {
            var liste = EgitimTuruService.EgitimTuruListele();
            var formDetay = EgitimDetayFormuDetayService.EgitimDetayFormuDetayGetirForSiniflanmisOlay(formId);
            if (formDetay != null)
            {
                foreach (var item in liste)
                {
                    if (item.Id == int.Parse(formDetay.Cevap))
                        item.SeciliMi = true;
                    else
                        item.SeciliMi = false;
                }
            }

            return (List<EgitimTuruDTO>)liste;


        }
        #endregion
    }
}
