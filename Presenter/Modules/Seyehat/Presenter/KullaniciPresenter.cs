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
    public class KullaniciPresenter
    {
        #region Constructor & View

        protected IKullaniciView View { get; private set; }

        public KullaniciPresenter(IKullaniciView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private KullaniciService _kullaniciService;

        protected KullaniciService KullaniciService
        {
            get { return _kullaniciService ?? (_kullaniciService = new KullaniciService()); }
        }


        #endregion

        #region Methods

        public void KullaniciiListele()
        {
            View.KullaniciListe = KullaniciService.KullaniciListele();
        }

        public bool KullaniciKontrol(string userName , string password)
        {
            var kullanici = KullaniciService.KullaniciFiltrele(userName).FirstOrDefault();

            if (kullanici.Password==password)
            {
                 return true;
            }
            else
            {
                return false;
            }
        }


        public void AramaSonuclariniListele(string userName)
        {
            var kullaniciListe = KullaniciService.KullaniciFiltrele(userName);


            View.KullaniciListe = kullaniciListe.ToList();
        }

        public Tuple<bool, string> KullaniciEkle()
        {
            var kullanici = new KullaniciDTO
            {
                UserName=View.UserName,
                Password=View.Password, 
                Name=View.Name,
                Surname=View.Surname,
                EMail=View.EMail

            };
            return KullaniciService.KullaniciEkle(kullanici);
        }

        public Tuple<bool, string> KullaniciGuncelle()
        {
            var kullanici = new KullaniciDTO
            {
                Id = View.SecilenKullaniciId,
                UserName = View.UserName,
                Password = View.Password,
                Name = View.Name,
                Surname = View.Surname,
                EMail = View.EMail


            };
            return KullaniciService.KullaniciGuncelle(kullanici);
        }

        public Tuple<bool, string> KullaniciKayitSil()
        {
            return KullaniciService.KullaniciSil(View.SecilenKullaniciId);
        }

        // AJAX işlemleri için
        public KullaniciDTO KullaniciGetir(int id)
        {
            var kullanici = KullaniciService.KullaniciGetir(id);
            return kullanici;
        }

        #endregion
    }
}
