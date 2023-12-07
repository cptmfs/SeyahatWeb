using DTO.Modules.SeyehatWeb;
using Presenter.Modules.SeyehatWeb.Interface;
using Service.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Presenter
{
    public class GaleriKategoriPresenter
    {
        #region Constructor & View

        protected IGaleriKategoriView View { get; private set; }

        public GaleriKategoriPresenter(IGaleriKategoriView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private GaleriKategoriService _galeriKategoriService;

        protected GaleriKategoriService GaleriKategoriService
        {
            get { return _galeriKategoriService ?? (_galeriKategoriService = new GaleriKategoriService()); }
        }


        #endregion

        #region Methods

        public void GaleriKategoriiListele()
        {
            View.GaleriKategoriListe = GaleriKategoriService.GaleriKategoriListele();
        }

        public Tuple<bool, string> GaleriKategoriEkle()
        {
            var galeriKategori = new GaleriKategoriDTO
            {
                Adi=View.Adi
            };
            return GaleriKategoriService.GaleriKategoriEkle(galeriKategori);
        }

        public Tuple<bool, string> GaleriKategoriGuncelle()
        {
            var galeriKategori = new GaleriKategoriDTO
            {
                Id = View.SecilenGaleriKategoriId,
                Adi=View.Adi

            };
            return GaleriKategoriService.GaleriKategoriGuncelle(galeriKategori);
        }

        public Tuple<bool, string> GaleriKategoriKayitSil()
        {
            return GaleriKategoriService.GaleriSil(View.SecilenGaleriKategoriId);
        }

        // AJAX işlemleri için
        public GaleriKategoriDTO GaleriKategoriGetir(int id)
        {
            var galeriKategori = GaleriKategoriService.GaleriKategoriGetir(id);
            return galeriKategori;
        }

        #endregion
    }
}
