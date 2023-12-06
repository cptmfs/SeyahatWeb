using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Service.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Presenter
{
    public class KurumsalPresenter
    {
        #region Constructor & View

        protected IKurumsalView View { get; private set; }

        public KurumsalPresenter(IKurumsalView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private KurumsalService _kurumsalService;

        protected KurumsalService KurumsalService
        {
            get { return _kurumsalService ?? (_kurumsalService = new KurumsalService()); }
        }


        #endregion

        #region Methods

        public void KurumsalListele()
        {
            View.KurumsalListe = KurumsalService.KurumsalListele();
        }

        public Tuple<bool, string> KurumsalEkle()
        {
            var kurumsal = new KurumsalDTO
            {
               Baslik=View.Baslik,
               Detay=View.Detay,
               Ozet=View.Ozet

            };
            return KurumsalService.KurumsalEkle(kurumsal);
        }

        public Tuple<bool, string> KurumsalGuncelle()
        {
            var kurumsal = new KurumsalDTO
            {
                Id = View.SecilenKurumsalBilgiId,
                Baslik = View.Baslik,
                Detay = View.Detay,
                Ozet = View.Ozet
            };
            return KurumsalService.KurumsalGuncelle(kurumsal);
        }

        public Tuple<bool, string> KurumsalKayitSil()
        {
            return KurumsalService.KurumsalSil(View.SecilenKurumsalBilgiId);
        }

        // AJAX işlemleri için
        public KurumsalDTO KurumsalGetir(int id)
        {
            var kurumsal = KurumsalService.KurumsalGetir(id);
            return kurumsal;
        }

        #endregion
    }
}
