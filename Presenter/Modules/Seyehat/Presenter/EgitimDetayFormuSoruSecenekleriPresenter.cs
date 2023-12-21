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
    public class EgitimDetayFormuSoruSecenekleriPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuSoruSecenekleriView View { get; private set; }

        public EgitimDetayFormuSoruSecenekleriPresenter(IEgitimDetayFormuSoruSecenekleriView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private EgitimDetayFormuSoruSecenekleriService _olayBilgiFormuSoruSecenekleriService;
        protected EgitimDetayFormuSoruSecenekleriService EgitimDetayFormuSoruSecenekleriService
        {
            get { return _olayBilgiFormuSoruSecenekleriService ?? (_olayBilgiFormuSoruSecenekleriService = new EgitimDetayFormuSoruSecenekleriService()); }
        }
        private EgitimDetayFormuSoruService _olayBilgiFormuSoruService;

        protected EgitimDetayFormuSoruService EgitimDetayFormuSoruService
        {
            get { return _olayBilgiFormuSoruService ?? (_olayBilgiFormuSoruService = new EgitimDetayFormuSoruService()); }
        }
        #endregion

        #region Methods

        public void EgitimDetayFormuSoruSecenekleriListele()
        {
            View.EgitimDetayFormuSoruSecenekleriListesi = EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriListele();
        }
        public void EgitimDetayFormuSoruListele()
        {
            View.EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruService.EgitimDetayFormuDrpOlanSoruListele();
        }
        public void EgitimDetayFormuSoruSecenekleriListele(int id)
        {
            View.EgitimDetayFormuSoruSecenekleriListesi = EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriListele(id);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriKayitEkle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruSecenekleriDTO
            {
                Sira = View.Sira,
                Tanim = View.Tanim,
                EgitimDetayFormuSoruId = View.EgitimDetayFormuSoruId
            };

            return EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriEkle(olayBilgiFormu);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriKayitGuncelle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruSecenekleriDTO
            {
                Id = View.SecilenEgitimDetayFormuSoruSecenekleriId,
                Sira = View.Sira,
                Tanim = View.Tanim,
                EgitimDetayFormuSoruId = View.EgitimDetayFormuSoruId

            };

            return EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriGuncelle(olayBilgiFormu);
        }

        public void AramaSonuclariniListele()
        {
            var olayBilgiFormuSoruSecenekList = EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriListele();
            if (olayBilgiFormuSoruSecenekList != null)
            {
                if (View.AramaSoruTanim > 0)
                    View.EgitimDetayFormuSoruSecenekleriListesi = olayBilgiFormuSoruSecenekList.Where(i => i.EgitimDetayFormuSoruId == View.AramaSoruTanim).Any() ? olayBilgiFormuSoruSecenekList.Where(i => i.EgitimDetayFormuSoruId == View.AramaSoruTanim).ToList() : null;
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriKayitSil()
        {
            return EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriSil(View.SecilenEgitimDetayFormuSoruSecenekleriId);
        }

        // AJAX işlemleri için
        public EgitimDetayFormuSoruSecenekleriDTO EgitimDetayFormuSoruSecenekleriGetir(int id)
        {
            return EgitimDetayFormuSoruSecenekleriService.EgitimDetayFormuSoruSecenekleriGetir(id);
        }

        #endregion
    }
}
