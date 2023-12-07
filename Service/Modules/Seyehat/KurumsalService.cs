using DTO.Modules.SeyehatWeb;
using Entity.Seyehat;
using Repository.Modules.SeyehatWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.SeyehatWeb
{
    public class KurumsalService
    {
        #region Repository

        private KurumsalRepository _kurumsalRepository;

        protected KurumsalRepository KurumsalRepository
        {
            get { return _kurumsalRepository ?? (_kurumsalRepository = new KurumsalRepository()); }
        }



        #endregion

        #region Methods

        public KurumsalDTO KurumsalGetir(int kurumsalId)
        {
            if (kurumsalId <= 0) return null;

            var kurumsal = KurumsalRepository.KurumsalBilgiGetir(kurumsalId);

            return kurumsal == null ? null : new KurumsalDTO
            {
                Id = kurumsal.Id,
                Baslik=kurumsal.Baslik,
                Detay=kurumsal.Detay,
                Ozet = kurumsal.Ozet
            };

        }

        public List<KurumsalDTO> KurumsalListele()
        {
            var kurumsalListesi = KurumsalRepository.KurumsalBilgiListele()
                .Select(kurumsal => new KurumsalDTO
                {
                    Id = kurumsal.Id,
                    Baslik = kurumsal.Baslik,
                    Detay = kurumsal.Detay,
                    Ozet = kurumsal.Ozet


                })
                .OrderBy(kurumsal => kurumsal.Id)
                .ToList();

            return kurumsalListesi;
        }
        public Tuple<bool, string> KurumsalEkle(KurumsalDTO kurumsal)
        {
            if (kurumsal == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yenikurumsal = new tabloKurumsal
            {
                Id = kurumsal.Id,
                Baslik = kurumsal.Baslik,
                Detay = kurumsal.Detay,
                Ozet = kurumsal.Ozet
            };

            try
            {
                KurumsalRepository.KurumsalBilgiEkle(yenikurumsal);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> KurumsalGuncelle(KurumsalDTO kurumsal)
        {
            if (kurumsal == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncellekurumsal = new tabloKurumsal
            {
                Id = kurumsal.Id,
                Baslik = kurumsal.Baslik,
                Detay = kurumsal.Detay,
                Ozet = kurumsal.Ozet
            };

            try
            {
                KurumsalRepository.KurumsalBilgiGuncelle(guncellekurumsal);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> KurumsalSil(int kurumsalId)
        {
            if (kurumsalId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var kurumsal = new tabloKurumsal { Id = kurumsalId };
                KurumsalRepository.KurumsalSil(kurumsal);
                return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        #endregion
    }
}
