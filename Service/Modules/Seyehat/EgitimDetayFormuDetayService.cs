using DTO.Modules.Seyehat;
using Entity.Seyehat;
using Repository.Modules.Seyehat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class EgitimDetayFormuDetayService
    {
        #region Repository

        private EgitimDetayFormuDetayRepository _olayBilgiFormuDetayRepository;

        protected EgitimDetayFormuDetayRepository EgitimDetayFormuDetayRepository
        {
            get { return _olayBilgiFormuDetayRepository ?? (_olayBilgiFormuDetayRepository = new EgitimDetayFormuDetayRepository()); }
        }

        #endregion
        #region Service

        private EgitimDetayFormuService _olayBilgiFormuService;

        protected EgitimDetayFormuService EgitimDetayFormuService
        {
            get { return _olayBilgiFormuService ?? (_olayBilgiFormuService = new EgitimDetayFormuService()); }
        }

        #endregion

        #region Methods

        public EgitimDetayFormuDetayDTO EgitimDetayFormuDetayGetir(int olayBilgiFormuDetayId)
        {

            if (olayBilgiFormuDetayId <= 0) return null;
            var olayBilgiFormuDetay = EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayGetir(olayBilgiFormuDetayId);

            return olayBilgiFormuDetay == null
                ? null
                : new EgitimDetayFormuDetayDTO
                {
                    Id = olayBilgiFormuDetay.Id,
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap

                };
        }


        public List<EgitimDetayFormuDetayDTO> EgitimDetayFormuDetayListele()
        {
            var olayBilgiFormuDetayListesi = EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayListele()
                .Select(olayBilgiFormuDetay => new EgitimDetayFormuDetayDTO
                {
                    Id = olayBilgiFormuDetay.Id,
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap

                })
                .OrderBy(olayBilgiFormuDetay => olayBilgiFormuDetay.Id)
                .ToList();

            return olayBilgiFormuDetayListesi;
        }

        public List<EgitimDetayFormuDetayDTO> EgitimDetayFormuDetayListeleByForm(int formId)
        {
            var olayBilgiFormuDetayListesi = EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayListeleByForm(formId)
                .Select(olayBilgiFormuDetay => new EgitimDetayFormuDetayDTO
                {
                    Id = olayBilgiFormuDetay.Id,
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap

                })
                .OrderBy(olayBilgiFormuDetay => olayBilgiFormuDetay.Id)
                .ToList();

            return olayBilgiFormuDetayListesi;
        }
        public EgitimDetayFormuDetayDTO EgitimDetayFormuDetayGetirForVeriKaynagi(int formId)
        {
            if (formId <= 0) return null;
            var olayBilgiFormuDetay = EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayGetirForVeriKaynagi(formId);

            return olayBilgiFormuDetay == null
                ? null
                : new EgitimDetayFormuDetayDTO
                {
                    Id = olayBilgiFormuDetay.Id,
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap
                };

        }
        public EgitimDetayFormuDetayDTO EgitimDetayFormuDetayGetirForSiniflanmisOlay(int formId)
        {
            if (formId <= 0) return null;
            var olayBilgiFormuDetay = EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayGetirForSiniflanmisOlay(formId);

            return olayBilgiFormuDetay == null
                ? null
                : new EgitimDetayFormuDetayDTO
                {
                    Id = olayBilgiFormuDetay.Id,
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap
                };

        }
        public Tuple<bool, string> EgitimDetayFormuDetayEkle(EgitimDetayFormuDetayDTO olayBilgiFormuDetay)
        {
            if (olayBilgiFormuDetay == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuDetay = new EgitimDetayFormuDetay
            {
                EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                Cevap = olayBilgiFormuDetay.Cevap
            };

            try
            {
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayEkle(yeniEgitimDetayFormuDetay);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuDetayGuncelle(EgitimDetayFormuDetayDTO olayBilgiFormuDetay)
        {
            if (olayBilgiFormuDetay == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuDetay = new EgitimDetayFormuDetay
            {
                Id = olayBilgiFormuDetay.Id,
                Cevap = olayBilgiFormuDetay.Cevap
            };

            try
            {
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayGuncelle(yeniEgitimDetayFormuDetay);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuDetaySil(int olayBilgiFormuDetayId)
        {
            if (olayBilgiFormuDetayId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var olayBilgiFormuDetay = new EgitimDetayFormuDetay { Id = olayBilgiFormuDetayId };
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetaySil(olayBilgiFormuDetay);
                return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuDetayTopluSil(List<EgitimDetayFormuDetayDTO> olayBilgiFormuDetayListesi)
        {
            if (olayBilgiFormuDetayListesi.Count() == 0)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            foreach (var item in olayBilgiFormuDetayListesi)
            {
                var olayBilgiFormuDetay = new EgitimDetayFormuDetay { Id = item.Id };
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetaySil(olayBilgiFormuDetay);
            }

            return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");

        }
        public Tuple<bool, string> EgitimDetayFormuDetayTopluEkle(List<EgitimDetayFormuDetayDTO> olayBilgiFormuDetayListesi)
        {
            if (olayBilgiFormuDetayListesi.Count() == 0)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            foreach (var olayBilgiFormuDetay in olayBilgiFormuDetayListesi)
            {
                var yeniEgitimDetayFormuDetay = new EgitimDetayFormuDetay
                {
                    EgitimDetayFormuId = olayBilgiFormuDetay.EgitimDetayFormuId,
                    EgitimDetayFormuSoruBaglantiId = olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId,
                    Cevap = olayBilgiFormuDetay.Cevap
                };
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayEkle(yeniEgitimDetayFormuDetay);
            }

            return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");

        }
        public Tuple<bool, string> EgitimDetayFormuDetayTopluGuncelle(List<EgitimDetayFormuDetayDTO> olayBilgiFormuDetayListesi)
        {
            if (olayBilgiFormuDetayListesi.Count() == 0)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            foreach (var olayBilgiFormuDetay in olayBilgiFormuDetayListesi)
            {
                var yeniEgitimDetayFormuDetay = new EgitimDetayFormuDetay
                {
                    Id = olayBilgiFormuDetay.Id,
                    Cevap = olayBilgiFormuDetay.Cevap
                };
                EgitimDetayFormuDetayRepository.EgitimDetayFormuDetayGuncelle(yeniEgitimDetayFormuDetay);
            }

            return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");

        }


        public Tuple<bool, string> EgitimDetayFormuDetayTopluIslem(List<EgitimDetayFormuDetayDTO> olayBilgiFormuDetayListesi, int formId)
        {
            if (olayBilgiFormuDetayListesi.Count() == 0)
                return new Tuple<bool, string>(false, "Formda yeni bir değişiklik yapılmamıştır.");

            var kayitliListe = EgitimDetayFormuDetayListeleByForm(formId);

            var guncellenecekListe = new List<EgitimDetayFormuDetayDTO>();
            var kaydedilecekListe = new List<EgitimDetayFormuDetayDTO>();
            var silinecekListe = new List<EgitimDetayFormuDetayDTO>();

            foreach (var item in kayitliListe)
            {
                var kayit = olayBilgiFormuDetayListesi.Where(o => o.EgitimDetayFormuSoruBaglantiId == item.EgitimDetayFormuSoruBaglantiId).FirstOrDefault();
                if (kayit == null)
                    silinecekListe.Add(item);
                else
                {
                    kayit.Id = item.Id;
                    guncellenecekListe.Add(kayit);
                }

            }

            foreach (var olayBilgiFormuDetay in olayBilgiFormuDetayListesi)
            {
                if (!EgitimDetayFormuDetayRepository.KayitVarMi(olayBilgiFormuDetay.EgitimDetayFormuId.Value, olayBilgiFormuDetay.EgitimDetayFormuSoruBaglantiId.Value))
                    kaydedilecekListe.Add(olayBilgiFormuDetay);
            }

            EgitimDetayFormuDetayTopluEkle(kaydedilecekListe);
            EgitimDetayFormuDetayTopluGuncelle(guncellenecekListe);
            EgitimDetayFormuDetayTopluSil(silinecekListe);

            //var form = EgitimDetayFormuService.EgitimDetayFormuGetir(formId);
            //MailHelper.EgitimDetayFormuBilgileriGonder(form);
            return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");

        }

        #endregion
    }
}
