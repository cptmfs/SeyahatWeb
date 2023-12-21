using DTO.Modules.Seyehat;
using Repository.Modules.Seyehat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class EgitimDetayFormuSoruBaslikService
    {
        #region Repository

        private EgitimDetayFormuSoruBaslikRepository _olayBilgiFormuSoruRepository;

        protected EgitimDetayFormuSoruBaslikRepository EgitimDetayFormuSoruBaslikRepository
        {
            get { return _olayBilgiFormuSoruRepository ?? (_olayBilgiFormuSoruRepository = new EgitimDetayFormuSoruBaslikRepository()); }
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruBaslikDTO EgitimDetayFormuSoruBaslikGetir(int EgitimDetayFormuSoruBaslikId)
        {
            if (EgitimDetayFormuSoruBaslikId <= 0) return null;

            var EgitimDetayFormuSoruBaslik = EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikGetir(EgitimDetayFormuSoruBaslikId);

            return EgitimDetayFormuSoruBaslik == null
                ? null
                : new EgitimDetayFormuSoruBaslikDTO
                {
                    Id = EgitimDetayFormuSoruBaslik.Id,
                    Tanim = EgitimDetayFormuSoruBaslik.Tanim,
                    Sira = EgitimDetayFormuSoruBaslik.Sira

                };
        }

        public List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListele()
        {
            var EgitimDetayFormuSoruBaslikListesi = EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikListele()
                .Select(EgitimDetayFormuSoruBaslik => new EgitimDetayFormuSoruBaslikDTO
                {
                    Id = EgitimDetayFormuSoruBaslik.Id,
                    Tanim = EgitimDetayFormuSoruBaslik.Tanim,
                    Sira = EgitimDetayFormuSoruBaslik.Sira

                })
                .ToList();

            return EgitimDetayFormuSoruBaslikListesi;
        }
        public List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListele(int id)
        {
            var EgitimDetayFormuSoruBaslikListesi = EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikListele(id)
                .Select(EgitimDetayFormuSoruBaslik => new EgitimDetayFormuSoruBaslikDTO
                {
                    Id = EgitimDetayFormuSoruBaslik.Id,
                    Tanim = EgitimDetayFormuSoruBaslik.Tanim,
                    Sira = EgitimDetayFormuSoruBaslik.Sira

                })
                .ToList();

            return EgitimDetayFormuSoruBaslikListesi;
        }
        public Tuple<bool, string> EgitimDetayFormuSoruBaslikEkle(EgitimDetayFormuSoruBaslikDTO EgitimDetayFormuSoruBaslik)
        {
            if (EgitimDetayFormuSoruBaslik == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuSoruBaslik = new Entity.Seyehat.EgitimDetayFormuSoruBaslik
            {

                Tanim = EgitimDetayFormuSoruBaslik.Tanim,
                Sira = EgitimDetayFormuSoruBaslik.Sira

            };

            try
            {
                EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikEkle(yeniEgitimDetayFormuSoruBaslik);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaslikGuncelle(EgitimDetayFormuSoruBaslikDTO EgitimDetayFormuSoruBaslik)
        {
            if (EgitimDetayFormuSoruBaslik == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleEgitimDetayFormuSoruBaslik = new Entity.Seyehat.EgitimDetayFormuSoruBaslik
            {
                Id = EgitimDetayFormuSoruBaslik.Id,
                Tanim = EgitimDetayFormuSoruBaslik.Tanim,
                Sira = EgitimDetayFormuSoruBaslik.Sira
            };

            try
            {
                EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikGuncelle(guncelleEgitimDetayFormuSoruBaslik);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaslikSil(int EgitimDetayFormuSoruBaslikId)
        {
            if (EgitimDetayFormuSoruBaslikId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var EgitimDetayFormuSoruBaslik = new Entity.Seyehat.EgitimDetayFormuSoruBaslik { Id = EgitimDetayFormuSoruBaslikId };
                EgitimDetayFormuSoruBaslikRepository.EgitimDetayFormuSoruBaslikSil(EgitimDetayFormuSoruBaslik);
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
