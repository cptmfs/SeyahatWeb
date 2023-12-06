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
    public class GaleriPresenter
    {
        #region Constructor & View

        protected IGaleriView View { get; private set; }

        public GaleriPresenter(IGaleriView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private GaleriService _galeriService;

        protected GaleriService GaleriService
        {
            get { return _galeriService ?? (_galeriService = new GaleriService()); }
        }


        #endregion

        #region Methods

        public void GaleriiListele()
        {
            View.GaleriListe = GaleriService.GaleriListele();
        }



        public void AramaSonuclariniListele(string baslik)
        {
            var galeriListe = GaleriService.GaleriFiltrele(baslik);


            View.GaleriListe = galeriListe.ToList();
        }

        public Tuple<bool, string> GaleriEkle()
        {
            var galeri = new GaleriDTO
            {
                Baslik=View.Baslik,
                KategoriId=View.KategoriId,
                Resim=View.Resim

            };
            return GaleriService.GaleriEkle(galeri);
        }

        public Tuple<bool, string> GaleriGuncelle()
        {
            var galeri = new GaleriDTO
            {
                Id = View.SecilenGaleriId,
                Baslik = View.Baslik,
                KategoriId = View.KategoriId,
                Resim = View.Resim
            };
            return GaleriService.GaleriGuncelle(galeri);
        }

        public Tuple<bool, string> GaleriKayitSil()
        {
            return GaleriService.GaleriSil(View.SecilenGaleriId);
        }

        // AJAX işlemleri için
        public GaleriDTO GaleriGetir(int id)
        {
            var galeri = GaleriService.GaleriGetir(id);
            return galeri;
        }

        #endregion
    }
}
