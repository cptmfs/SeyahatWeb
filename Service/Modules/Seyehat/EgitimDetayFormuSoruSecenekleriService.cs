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
    public class EgitimDetayFormuSoruSecenekleriService
    {
        #region Repository

        private EgitimDetayFormuSoruSecenekleriRepository _olayBilgiFormuSoruRepository;

        protected EgitimDetayFormuSoruSecenekleriRepository EgitimDetayFormuSoruSecenekleriRepository
        {
            get { return _olayBilgiFormuSoruRepository ?? (_olayBilgiFormuSoruRepository = new EgitimDetayFormuSoruSecenekleriRepository()); }
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruSecenekleriDTO EgitimDetayFormuSoruSecenekleriGetir(int EgitimDetayFormuSoruSecenekleriId)
        {
            if (EgitimDetayFormuSoruSecenekleriId <= 0) return null;

            var EgitimDetayFormuSoruSecenekleri = EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriGetir(EgitimDetayFormuSoruSecenekleriId);

            return EgitimDetayFormuSoruSecenekleri == null
                ? null
                : new EgitimDetayFormuSoruSecenekleriDTO
                {
                    Id = EgitimDetayFormuSoruSecenekleri.Id,
                    Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                    Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId

                };
        }

        public List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListele()
        {
            var EgitimDetayFormuSoruSecenekleriListesi = EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriListele()
                .Select(EgitimDetayFormuSoruSecenekleri => new EgitimDetayFormuSoruSecenekleriDTO
                {
                    Id = EgitimDetayFormuSoruSecenekleri.Id,
                    Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                    Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId,
                    EgitimDetayFormuSoruTanim = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId.HasValue ? EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoru.Tanim : ""

                })
                .ToList();

            return EgitimDetayFormuSoruSecenekleriListesi;
        }
        public List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListele(int id)
        {
            var EgitimDetayFormuSoruSecenekleriListesi = EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriListele(id)
                .Select(EgitimDetayFormuSoruSecenekleri => new EgitimDetayFormuSoruSecenekleriDTO
                {
                    Id = EgitimDetayFormuSoruSecenekleri.Id,
                    Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                    Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId,
                    EgitimDetayFormuSoruTanim = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId.HasValue ? EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoru.Tanim : ""

                })
                .ToList();

            return EgitimDetayFormuSoruSecenekleriListesi;
        }
        public List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListeleBySoru(int soruId)
        {
            var EgitimDetayFormuSoruSecenekleriListesi = EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriListeleBySoru(soruId)
                .Select(EgitimDetayFormuSoruSecenekleri => new EgitimDetayFormuSoruSecenekleriDTO
                {
                    Id = EgitimDetayFormuSoruSecenekleri.Id,
                    Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                    Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId
                })
                .ToList();

            return EgitimDetayFormuSoruSecenekleriListesi;
        }
        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriEkle(EgitimDetayFormuSoruSecenekleriDTO EgitimDetayFormuSoruSecenekleri)
        {
            if (EgitimDetayFormuSoruSecenekleri == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuSoruSecenekleri = new EgitimDetayFormuSoruSecenekleri
            {

                Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId

            };

            try
            {
                EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriEkle(yeniEgitimDetayFormuSoruSecenekleri);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriGuncelle(EgitimDetayFormuSoruSecenekleriDTO EgitimDetayFormuSoruSecenekleri)
        {
            if (EgitimDetayFormuSoruSecenekleri == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleEgitimDetayFormuSoruSecenekleri = new EgitimDetayFormuSoruSecenekleri
            {
                Id = EgitimDetayFormuSoruSecenekleri.Id,
                Tanim = EgitimDetayFormuSoruSecenekleri.Tanim,
                Sira = EgitimDetayFormuSoruSecenekleri.Sira,
                EgitimDetayFormuSoruId = EgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId
            };

            try
            {
                EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriGuncelle(guncelleEgitimDetayFormuSoruSecenekleri);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSecenekleriSil(int EgitimDetayFormuSoruSecenekleriId)
        {
            if (EgitimDetayFormuSoruSecenekleriId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var EgitimDetayFormuSoruSecenekleri = new EgitimDetayFormuSoruSecenekleri { Id = EgitimDetayFormuSoruSecenekleriId };
                EgitimDetayFormuSoruSecenekleriRepository.EgitimDetayFormuSoruSecenekleriSil(EgitimDetayFormuSoruSecenekleri);
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
