using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Service.Modules.Seyehat;
using System;


namespace Presenter.Modules.Seyehat.Presenter
{
    public class EgitimDetayFormuSoruBaslikPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuSoruBaslikView View { get; private set; }

        public EgitimDetayFormuSoruBaslikPresenter(IEgitimDetayFormuSoruBaslikView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private EgitimDetayFormuSoruBaslikService _olayBilgiFormuSoruBaslikService;
        protected EgitimDetayFormuSoruBaslikService EgitimDetayFormuSoruBaslikService
        {
            get { return _olayBilgiFormuSoruBaslikService ?? (_olayBilgiFormuSoruBaslikService = new EgitimDetayFormuSoruBaslikService()); }
        }
        #endregion

        #region Methods

        public void EgitimDetayFormuSoruBaslikListele()
        {
            View.EgitimDetayFormuSoruBaslikListesi = EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikListele();
        }
        public void EgitimDetayFormuSoruBaslikListele(int id)
        {
            View.EgitimDetayFormuSoruBaslikListesi = EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikListele(id);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaslikKayitEkle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruBaslikDTO
            {
                Sira = View.Sira,
                Tanim = View.Tanim
            };

            return EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikEkle(olayBilgiFormu);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaslikKayitGuncelle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruBaslikDTO
            {
                Id = View.SecilenEgitimDetayFormuSoruBaslikId,
                Sira = View.Sira,
                Tanim = View.Tanim

            };

            return EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikGuncelle(olayBilgiFormu);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaslikKayitSil()
        {
            return EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikSil(View.SecilenEgitimDetayFormuSoruBaslikId);
        }

        // AJAX işlemleri için
        public EgitimDetayFormuSoruBaslikDTO EgitimDetayFormuSoruBaslikGetir(int id)
        {
            return EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikGetir(id);
        }

        #endregion
    }
}
