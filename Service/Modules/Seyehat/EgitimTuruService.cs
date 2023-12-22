using DTO.Modules.Seyehat;
using Entity.Seyehat;
using Repository.Modules.Seyehat;
using Repository.Modules.Seyehat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class EgitimTuruService
    {
        #region Repository

        private EgitimTuruRepository _EgitimTuruRepository;
        protected EgitimTuruRepository EgitimTuruRepository
        {
            get
            {
                return _EgitimTuruRepository ?? (_EgitimTuruRepository = new EgitimTuruRepository());
            }
        }

        #endregion

        #region Methods

        public EgitimTuruDTO EgitimTuruGetir(int EgitimTuruId)
        {
            if (EgitimTuruId <= 0) return null;

            var EgitimTuru = EgitimTuruRepository.EgitimTuruGetir(EgitimTuruId);

            if (EgitimTuru == null) return null;

            return new EgitimTuruDTO
            {
                Id = EgitimTuru.Id,
                Tanim = EgitimTuru.Tanim
            };
        }

        public IQueryable<EgitimTuruDTO> EgitimTuruListele()
        {
            return EgitimTuruRepository.VeriKaynaklariniListele()
                .Select(EgitimTuru => new EgitimTuruDTO
                {
                    Id = EgitimTuru.Id,
                    Tanim = EgitimTuru.Tanim
                });
        }
        public List<EgitimTuruDTO> VeriKaynaklariniList()
        {
            return EgitimTuruRepository.VeriKaynaklariniListele()
                .Select(EgitimTuru => new EgitimTuruDTO
                {
                    Id = EgitimTuru.Id,
                    Tanim = EgitimTuru.Tanim
                }).ToList();
        }
        public Tuple<bool, string> EgitimTuruEkle(EgitimTuruDTO EgitimTuru)
        {
            if (EgitimTuru == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimTuru = new EgitimTuru
            {
                Tanim = EgitimTuru.Tanim,
            };
            try
            {
                EgitimTuruRepository.EgitimTuruEkle(yeniEgitimTuru);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimTuruGuncelle(EgitimTuruDTO EgitimTuru)
        {
            if (EgitimTuru == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleEgitimTuru = new EgitimTuru
            {
                Id = EgitimTuru.Id,
                Tanim = EgitimTuru.Tanim
            };

            try
            {
                EgitimTuruRepository.EgitimTuruGuncelle(guncelleEgitimTuru);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimTuruSil(int EgitimTuruId)
        {
            if (EgitimTuruId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var EgitimTuru = new EgitimTuru { Id = EgitimTuruId };
                EgitimTuruRepository.EgitimTuruSil(EgitimTuru);
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
