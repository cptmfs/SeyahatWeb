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
    public class AyarlarPresenter
    {
        #region Constructor & View

        protected IAyarView View { get; private set; }

        public AyarlarPresenter(IAyarView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private AyarlarService _ayarlarService;

        protected AyarlarService AyarlarService
        {
            get { return _ayarlarService ?? (_ayarlarService = new AyarlarService()); }
        }


        #endregion

        #region Methods

        public void AyarlariListele()
        {
            View.AyarListe = AyarlarService.AyarListele();
        }



        public void AramaSonuclariniListele(string siteOzet)
        {
            var ayarListe = AyarlarService.AyarFiltrele(siteOzet);


            View.AyarListe = ayarListe.ToList();
        }

        public Tuple<bool, string> AyarEkle()
        {
            var ayar = new AyarlarDTO
            {
                SiteOzet = View.SiteOzet,
                Adres=View.Adres,
                Facebook=View.Facebook,
                Logo = View.Logo,
                Mail=View.Mail,
                Telefon= View.Telefon,
                Youtube= View.Youtube

            };
            return AyarlarService.AyarEkle(ayar);
        }

        public Tuple<bool, string> AyarGuncelle()
        {
            var arac = new AyarlarDTO
            {
                Id = View.SecilenAyarId,
                SiteOzet = View.SiteOzet,
                Adres = View.Adres,
                Facebook = View.Facebook,
                Logo = View.Logo,
                Mail = View.Mail,
                Telefon = View.Telefon,
                Youtube = View.Youtube


            };
            return AyarlarService.AyarGuncelle(arac);
        }

        public Tuple<bool, string> AyarKayitSil()
        {
            return AyarlarService.AyarSil(View.SecilenAyarId);
        }

        // AJAX işlemleri için
        public AyarlarDTO AyarGetir(int id)
        {
            var arac = AyarlarService.AyarGetir(id);
            return arac;
        }

        #endregion
    }
}
