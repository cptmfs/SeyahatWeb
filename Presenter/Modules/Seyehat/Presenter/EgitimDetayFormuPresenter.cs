using DTO.Modules.Seyehat;
using Infrastructure.Helper;
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
    public class EgitimDetayFormuPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuView View { get; private set; }

        public EgitimDetayFormuPresenter(IEgitimDetayFormuView view)
        {
            View = view;
        }

        #endregion      

        #region Service

        private EgitimDetayFormuService _olayBilgiFormuService;
        protected EgitimDetayFormuService EgitimDetayFormuService
        {
            get { return _olayBilgiFormuService ?? (_olayBilgiFormuService = new EgitimDetayFormuService()); }
        }
        private EgitimDetayFormuDetayService _olayBilgiFormuDetayService;
        protected EgitimDetayFormuDetayService EgitimDetayFormuDetayService
        {
            get { return _olayBilgiFormuDetayService ?? (_olayBilgiFormuDetayService = new EgitimDetayFormuDetayService()); }
        }
        private EgitimDetayFormuGuncellemeService _olayBilgiFormuGuncellemeService;
        protected EgitimDetayFormuGuncellemeService EgitimDetayFormuGuncellemeService
        {
            get { return _olayBilgiFormuGuncellemeService ?? (_olayBilgiFormuGuncellemeService = new EgitimDetayFormuGuncellemeService()); }
        }
        private KullaniciService _kullaniciYetkisiService;
        protected KullaniciService KullaniciYetkisiService
        {
            get { return _kullaniciYetkisiService ?? (_kullaniciYetkisiService = new KullaniciService()); }
        }
       
        #endregion

        #region Methods
        public void LabelDoldur()
        {
            var merkez = KullaniciYetkisiService.KullaniciGetir(SessionHelper.KullaniciId);
            View.LblMerkez = merkez == null ? "" : merkez.Name;
        }
        

        public void EgitimDetayFormuListele()
        {
            View.EgitimDetayFormuListesi = EgitimDetayFormuService.EgitimDetayFormuListele();
        }

        public Tuple<bool, string> EgitimDetayFormuKayitEkle()
        {
            var olayBilgiFormu = new EgitimDetayFormuDTO
            {
                Tur = View.Tur
            };

            return EgitimDetayFormuService.EgitimDetayFormuEkle(olayBilgiFormu);
        }
        public Tuple<bool, string> EgitimDetayFormuKayitEkleGM()
        {
            var olayBilgiFormu = new EgitimDetayFormuDTO
            {
                Tur = View.Tur
            };

            return EgitimDetayFormuService.EgitimDetayFormuEkle(olayBilgiFormu);
        }
        public Tuple<bool, string> EgitimDetayFormuKayitSil()
        {
            var sonuc = EgitimDetayFormuService.EgitimDetayFormuSil(View.SecilenEgitimDetayFormuId);
            if (sonuc.Item1)
            {
                // Form Detayları silinir
                var silinecekDetaylar = EgitimDetayFormuDetayService.EgitimDetayFormuDetayListeleByForm(View.SecilenEgitimDetayFormuId);
                EgitimDetayFormuDetayService.EgitimDetayFormuDetayTopluSil(silinecekDetaylar);

                // Form güncellemeleri silinir
                var silinecekGuncellemeler = EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeListeleByForm(View.SecilenEgitimDetayFormuId);
                EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeTopluSil(silinecekGuncellemeler);
            }

            return sonuc;
        }

        public Tuple<bool, string> EgitimDetayFormuGuncellemeKayitEkle()
        {
            var olayBilgiFormuGuncelleme = new EgitimDetayFormuGuncellemeDTO
            {
                EgitimDetayFormuId = View.SecilenEgitimDetayFormuId,
                Aciklama = View.Aciklama
            };

            return EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeEkle(olayBilgiFormuGuncelleme);
        }
        public Tuple<bool, string> EgitimDetayFormuGuncellemeKayitGuncelle()
        {
            var olayBilgiFormuGuncelleme = new EgitimDetayFormuGuncellemeDTO
            {
                Id = View.SecilenEgitimDetayFormuGuncellemeId,
                Aciklama = View.Aciklama
            };

            return EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeGuncelle(olayBilgiFormuGuncelleme);
        }
        public Tuple<bool, string> EgitimDetayFormuGuncellemeKayitSil()
        {
            return EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeSil(View.SecilenEgitimDetayFormuGuncellemeId);
        }
        //public void AramaSonuclariniListele()
        //{
        //    if (View.MerkezArama > 0)
        //        View.EgitimDetayFormuListesi = EgitimDetayFormuService.EgitimDetayFormuListeleByMerkez(View.MerkezArama);

        //}

        // AJAX işlemleri için
        public EgitimDetayFormuDTO EgitimDetayFormuGetir(int id)
        {
            return EgitimDetayFormuService.EgitimDetayFormuGetir(id);
        }
        public EgitimDetayFormuGuncellemeDTO EgitimDetayFormuGuncellemeGetir(int id)
        {
            return EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeGetir(id);
        }
        public List<EgitimDetayFormuGuncellemeDTO> EgitimDetayFormuGuncellemeListele(int formId)
        {
            return EgitimDetayFormuGuncellemeService.EgitimDetayFormuGuncellemeListeleByForm(formId);
        }

        public Tuple<bool, string> FormAcKapat()
        {
            var form = EgitimDetayFormuService.EgitimDetayFormuGetir(View.SecilenEgitimDetayFormuId);
            if (form.Aktif.Value)
            {
                return EgitimDetayFormuService.EgitimDetayFormuKapat(form.Id);
            }
            else
            {
                return EgitimDetayFormuService.EgitimDetayFormuAc(form.Id);
            }

        }
        #endregion
    }
}
