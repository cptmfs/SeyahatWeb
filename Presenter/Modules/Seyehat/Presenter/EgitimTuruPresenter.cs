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
    public class EgitimTuruPresenter
    {
        #region Constructor & View

        protected IEgitimTuruView View { get; private set; }

        public EgitimTuruPresenter(IEgitimTuruView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private EgitimTuruService _EgitimTuruService;

        protected EgitimTuruService EgitimTuruService
        {
            get { return _EgitimTuruService ?? (_EgitimTuruService = new EgitimTuruService()); }
        }
        #endregion

        #region Methods

        public void VeriKaynaklariniListele()
        {
            View.EgitimTuruListesi = EgitimTuruService.EgitimTuruListele().ToList();
        }


        public void AramaSonuclariniListele()
        {
            var EgitimTuruListesi = EgitimTuruService.EgitimTuruListele();

            if (!String.IsNullOrWhiteSpace(View.TanimAra))
                EgitimTuruListesi = EgitimTuruListesi.Where(EgitimTuru => EgitimTuru.Tanim.ToUpper().StartsWith(View.TanimAra.ToUpper().Trim()));

            View.EgitimTuruListesi = EgitimTuruListesi.ToList();
        }

        public Tuple<bool, string> EgitimTuruKayitEkle()
        {
            var EgitimTuru = new EgitimTuruDTO
            {
                Tanim = View.Tanim
            };
            return EgitimTuruService.EgitimTuruEkle(EgitimTuru);
        }

        public Tuple<bool, string> EgitimTuruKayitGuncelle()
        {
            var EgitimTuru = new EgitimTuruDTO
            {
                Id = View.SecilenEgitimTuruId,
                Tanim = View.Tanim
            };
            return EgitimTuruService.EgitimTuruGuncelle(EgitimTuru);
        }

        public Tuple<bool, string> EgitimTuruKayitSil()
        {
            return EgitimTuruService.EgitimTuruSil(View.SecilenEgitimTuruId);
        }

        // AJAX işlemleri için1
        public EgitimTuruDTO EgitimTuruGetir(int id)
        {
            return EgitimTuruService.EgitimTuruGetir(id);
        }

        #endregion
    }
}
