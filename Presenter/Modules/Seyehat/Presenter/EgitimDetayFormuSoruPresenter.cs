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
    public class EgitimDetayFormuSoruPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuSoruView View { get; private set; }

        public EgitimDetayFormuSoruPresenter(IEgitimDetayFormuSoruView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private EgitimDetayFormuSoruService _olayBilgiFormuSoruService;
        protected EgitimDetayFormuSoruService EgitimDetayFormuSoruService
        {
            get { return _olayBilgiFormuSoruService ?? (_olayBilgiFormuSoruService = new EgitimDetayFormuSoruService()); }
        }
        private EgitimDetayFormuSoruBaslikService _olayBilgiFormuSoruBaslikService;
        protected EgitimDetayFormuSoruBaslikService EgitimDetayFormuSoruBaslikService
        {
            get { return _olayBilgiFormuSoruBaslikService ?? (_olayBilgiFormuSoruBaslikService = new EgitimDetayFormuSoruBaslikService()); }
        }
        #endregion

        #region Methods

        public void EgitimDetayFormuSoruListele()
        {
            View.EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele();
        }
        public void EgitimDetayFormuSoruBaslikListele()
        {
            View.EgitimDetayFormuSoruBaslikListesi = EgitimDetayFormuSoruBaslikService.EgitimDetayFormuSoruBaslikListele();
        }
        public void EgitimDetayFormuSoruListele(int id)
        {
            View.EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele(id);
        }

        public void AramaSonuclariniListele()
        {
            var olayBilgiFormuSoruList = EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele();
            if (olayBilgiFormuSoruList != null)
            {
                if (View.AramaSoruTuru > 0)
                    View.EgitimDetayFormuSoruListesi = olayBilgiFormuSoruList.Where(i => i.EgitimDetayFormuSoruBaslikId == View.AramaSoruTuru).Any() ? olayBilgiFormuSoruList.Where(i => i.EgitimDetayFormuSoruBaslikId == View.AramaSoruTuru).ToList() : null;
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruKayitEkle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruDTO
            {
                Sira = View.Sira,
                Tanim = View.Tanim,
                EgitimDetayFormuSoruBaslikId = View.EgitimDetayFormuSoruBaslikId,
                CevapTuru = View.CevapTuru,
                TxtSatirSayisi = View.TxtSatirSayisi

            };

            return EgitimDetayFormuSoruService.EgitimDetayFormuSoruEkle(olayBilgiFormu);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruKayitGuncelle()
        {
            var olayBilgiFormu = new EgitimDetayFormuSoruDTO
            {
                Id = View.SecilenEgitimDetayFormuSoruId,
                Sira = View.Sira,
                Tanim = View.Tanim,
                EgitimDetayFormuSoruBaslikId = View.EgitimDetayFormuSoruBaslikId,
                CevapTuru = View.CevapTuru,
                TxtSatirSayisi = View.TxtSatirSayisi
            };

            return EgitimDetayFormuSoruService.EgitimDetayFormuSoruGuncelle(olayBilgiFormu);
        }

        public Tuple<bool, string> EgitimDetayFormuSoruKayitSil()
        {
            return EgitimDetayFormuSoruService.EgitimDetayFormuSoruSil(View.SecilenEgitimDetayFormuSoruId);
        }
        //public void AramaSonuclariniListele()
        //{
        //    var tanimList= EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele();
        //    if(tanimList!=null)
        //         if (!String.IsNullOrWhiteSpace(View.EgitimDetayFormuSoruArama))
        //            tanimList = tanimList.Where(tanim => tanim.Tanim.ToUpper().StartsWith(View.EgitimDetayFormuSoruArama.ToUpper().Trim())).ToList();
        //    View.EgitimDetayFormuSoruListesi = tanimList;
        //}

        // AJAX işlemleri için
        public EgitimDetayFormuSoruDTO EgitimDetayFormuSoruGetir(int id)
        {
            return EgitimDetayFormuSoruService.EgitimDetayFormuSoruGetir(id);
        }

        #endregion
    }
}
