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
    public class TurPaketPresenter
    {
        #region Constructor & View

        protected ITurPaketView View { get; private set; }

        public TurPaketPresenter(ITurPaketView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private TurPaketService _turPaketService;

        protected TurPaketService TurPaketService
        {
            get { return _turPaketService ?? (_turPaketService = new TurPaketService()); }
        }


        #endregion

        #region Methods

        public void TurPaketiListele()
        {
            View.TurPaketListe = TurPaketService.TurPaketListele();
        }



        public void AramaSonuclariniListele(string siteOzet)
        {
            var turPaketListe = TurPaketService.TurPaketFiltrele(siteOzet);


            View.TurPaketListe = turPaketListe.ToList();
        }

        public Tuple<bool, string> TurPaketEkle()
        {
            var turPaket = new TurPaketDTO
            {
                Adi=View.Adi,
                Fiyat=View.Fiyat,
                Detay=View.Detay,
                Lokasyon=View.Lokasyon,
                Resim=View.Resim,
                Sure = View.Sure
            };
            return TurPaketService.TurPaketEkle(turPaket);
        }

        public Tuple<bool, string> TurPaketGuncelle()
        {
            var turPaket = new TurPaketDTO
            {
                Id = View.SecilenTurPaketId,
                Adi = View.Adi,
                Fiyat = View.Fiyat,
                Detay = View.Detay,
                Lokasyon = View.Lokasyon,
                Resim = View.Resim,
                Sure = View.Sure


            };
            return TurPaketService.TurPaketGuncelle(turPaket);
        }

        public Tuple<bool, string> TurPaketKayitSil()
        {
            return TurPaketService.TurPaketSil(View.SecilenTurPaketId);
        }

        // AJAX işlemleri için
        public TurPaketDTO TurPaketGetir(int id)
        {
            var turPaket = TurPaketService.TurPaketGetir(id);
            return turPaket;
        }

        #endregion
    }
}
