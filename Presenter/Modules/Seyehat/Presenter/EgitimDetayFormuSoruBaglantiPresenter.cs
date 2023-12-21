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
    public class EgitimDetayFormuSoruBaglantiPresenter
    {
        #region Constructor & View

        protected IEgitimDetayFormuSoruBaglantiView View { get; private set; }

        public EgitimDetayFormuSoruBaglantiPresenter(IEgitimDetayFormuSoruBaglantiView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private EgitimDetayFormuSoruBaglantiService _EgitimDetayFormuSoruBaglantiService;

        protected EgitimDetayFormuSoruBaglantiService EgitimDetayFormuSoruBaglantiService
        {
            get { return _EgitimDetayFormuSoruBaglantiService ?? (_EgitimDetayFormuSoruBaglantiService = new EgitimDetayFormuSoruBaglantiService()); }
        }
        private EgitimDetayFormuSoruService _EgitimDetayFormuSoruService;

        protected EgitimDetayFormuSoruService EgitimDetayFormuSoruService
        {
            get { return _EgitimDetayFormuSoruService ?? (_EgitimDetayFormuSoruService = new EgitimDetayFormuSoruService()); }
        }
        #endregion

        #region Methods




        public void TurListele()
        {
            var liste = new List<TanimDTO>();
            liste.Add(new TanimDTO() { Aciklama = "Havalimanı Olay Bilgi Formu Soru Seçenekleri", Id = 1 });
            liste.Add(new TanimDTO() { Aciklama = "Deniz Limanı Olay Bilgi Formu Soru Seçenekleri", Id = 2 });
            liste.Add(new TanimDTO() { Aciklama = "Kara Hudut Kapıları Olay Bilgi Formu Soru Seçenekleri", Id = 3 });
            View.TurListesi = liste;

        }
        public List<EgitimDetayFormuSoruDTO> SoruListele() //Tüm Konuları pup up ın solunda listelemek için
        {
            var liste = EgitimDetayFormuSoruService.EgitimDetayFormuSoruListele();
            return liste.Any() ? liste.ToList() : new List<EgitimDetayFormuSoruDTO>();
        }



        public List<EgitimDetayFormuSoruBaglantiDTO> SoruGetir(int turId)
        {
            var soruList = EgitimDetayFormuSoruBaglantiService.EgitimDetayFormuSoruBaglantiListeleByTur(turId, true);

            return soruList;
        }

        public void SorulariGonder(List<int> secilenKonular, int turId)
        {
            EgitimDetayFormuSoruBaglantiService.SorulariGonder(secilenKonular, turId);
        }



        #endregion
    }
}
