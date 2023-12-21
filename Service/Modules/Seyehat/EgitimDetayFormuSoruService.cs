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
    public class EgitimDetayFormuSoruService
    {
        #region Repository

        private EgitimDetayFormuSoruRepository _olayBilgiFormuSoruRepository;

        protected EgitimDetayFormuSoruRepository EgitimDetayFormuSoruRepository
        {
            get { return _olayBilgiFormuSoruRepository ?? (_olayBilgiFormuSoruRepository = new EgitimDetayFormuSoruRepository()); }
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruDTO EgitimDetayFormuSoruGetir(int EgitimDetayFormuSoruId)
        {
            if (EgitimDetayFormuSoruId <= 0) return null;

            var EgitimDetayFormuSoru = EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruGetir(EgitimDetayFormuSoruId);

            return EgitimDetayFormuSoru == null
                ? null
                : new EgitimDetayFormuSoruDTO
                {
                    Id = EgitimDetayFormuSoru.Id,
                    Tanim = EgitimDetayFormuSoru.Tanim,
                    Sira = EgitimDetayFormuSoru.Sira,
                    EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                    CevapTuru = EgitimDetayFormuSoru.CevapTuru.Value,
                    TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi

                };
        }

        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListele()
        {
            var EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruListele()
                .Select(EgitimDetayFormuSoru => new EgitimDetayFormuSoruDTO
                {
                    Id = EgitimDetayFormuSoru.Id,
                    Tanim = EgitimDetayFormuSoru.Tanim,
                    Sira = EgitimDetayFormuSoru.Sira,
                    EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                    EgitimDetayFormuSoruBaslikTanim = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId.HasValue ? EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslik.Tanim : "",
                    CevapTuru = EgitimDetayFormuSoru.CevapTuru.Value,
                    TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi,
                    CevapTuruAciklama = EgitimDetayFormuSoru.CevapTuru.HasValue ? EgitimDetayFormuSoru.CevapTuru == 1 ? "Uzun Metin" : EgitimDetayFormuSoru.CevapTuru == 2 ? "Evet/Hayır/Bilinmiyor" :
                    EgitimDetayFormuSoru.CevapTuru == 3 ? "Çoktan Seçmeli" : EgitimDetayFormuSoru.CevapTuru == 4 ? "Kısa Metin" : EgitimDetayFormuSoru.CevapTuru == 5 ? "Tarih" : EgitimDetayFormuSoru.CevapTuru == 6 ? "Tarih & Saat" : EgitimDetayFormuSoru.CevapTuru == 7 ? "Rakam" : "" : ""
                })
                .ToList();

            return EgitimDetayFormuSoruListesi;
        }
        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListele(int id)
        {
            var EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruListele(id)
                .Select(EgitimDetayFormuSoru => new EgitimDetayFormuSoruDTO
                {
                    Id = EgitimDetayFormuSoru.Id,
                    Tanim = EgitimDetayFormuSoru.Tanim,
                    Sira = EgitimDetayFormuSoru.Sira,
                    EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                    CevapTuru = EgitimDetayFormuSoru.CevapTuru.Value,
                    TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi,
                    CevapTuruAciklama = EgitimDetayFormuSoru.CevapTuru.HasValue ? EgitimDetayFormuSoru.CevapTuru == 1 ? "Uzun Metin" : EgitimDetayFormuSoru.CevapTuru == 2 ? "Evet/Hayır/Bilinmiyor" :
                    EgitimDetayFormuSoru.CevapTuru == 3 ? "Çoktan Seçmeli" : EgitimDetayFormuSoru.CevapTuru == 4 ? "Kısa Metin" : EgitimDetayFormuSoru.CevapTuru == 5 ? "Tarih" : EgitimDetayFormuSoru.CevapTuru == 6 ? "Tarih & Saat" : EgitimDetayFormuSoru.CevapTuru == 7 ? "Rakam" : "" : ""
                })
                .ToList();

            return EgitimDetayFormuSoruListesi;
        }
        public List<EgitimDetayFormuSoruDTO> EgitimDetayFormuDrpOlanSoruListele()
        {
            var EgitimDetayFormuSoruListesi = EgitimDetayFormuSoruRepository.EgitimDetayFormuDrpOlanSoruListele()
                .Select(EgitimDetayFormuSoru => new EgitimDetayFormuSoruDTO
                {
                    Id = EgitimDetayFormuSoru.Id,
                    Tanim = EgitimDetayFormuSoru.Tanim,
                    Sira = EgitimDetayFormuSoru.Sira,
                    EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                    CevapTuru = EgitimDetayFormuSoru.CevapTuru.Value,
                    TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi,
                    CevapTuruAciklama = EgitimDetayFormuSoru.CevapTuru.HasValue ? EgitimDetayFormuSoru.CevapTuru == 1 ? "Uzun Metin" : EgitimDetayFormuSoru.CevapTuru == 2 ? "Evet/Hayır/Bilinmiyor" :
                    EgitimDetayFormuSoru.CevapTuru == 3 ? "Çoktan Seçmeli" : EgitimDetayFormuSoru.CevapTuru == 4 ? "Kısa Metin" : EgitimDetayFormuSoru.CevapTuru == 5 ? "Tarih" : EgitimDetayFormuSoru.CevapTuru == 6 ? "Tarih & Saat" : EgitimDetayFormuSoru.CevapTuru == 7 ? "Rakam" : "" : ""
                })
                .ToList();

            return EgitimDetayFormuSoruListesi;
        }
        public Tuple<bool, string> EgitimDetayFormuSoruEkle(EgitimDetayFormuSoruDTO EgitimDetayFormuSoru)
        {
            if (EgitimDetayFormuSoru == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuSoru = new EgitimDetayFormuSoru
            {

                Tanim = EgitimDetayFormuSoru.Tanim,
                Sira = EgitimDetayFormuSoru.Sira,
                EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                CevapTuru = EgitimDetayFormuSoru.CevapTuru.Value,
                TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi
            };

            try
            {
                EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruEkle(yeniEgitimDetayFormuSoru);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruGuncelle(EgitimDetayFormuSoruDTO EgitimDetayFormuSoru)
        {
            if (EgitimDetayFormuSoru == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleEgitimDetayFormuSoru = new EgitimDetayFormuSoru
            {
                Id = EgitimDetayFormuSoru.Id,
                Tanim = EgitimDetayFormuSoru.Tanim,
                Sira = EgitimDetayFormuSoru.Sira,
                EgitimDetayFormuSoruBaslikId = EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId,
                CevapTuru = EgitimDetayFormuSoru.CevapTuru,
                TxtSatirSayisi = EgitimDetayFormuSoru.TxtSatirSayisi
            };

            try
            {
                EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruGuncelle(guncelleEgitimDetayFormuSoru);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruSil(int EgitimDetayFormuSoruId)
        {
            if (EgitimDetayFormuSoruId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var EgitimDetayFormuSoru = new EgitimDetayFormuSoru { Id = EgitimDetayFormuSoruId };
                EgitimDetayFormuSoruRepository.EgitimDetayFormuSoruSil(EgitimDetayFormuSoru);
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
