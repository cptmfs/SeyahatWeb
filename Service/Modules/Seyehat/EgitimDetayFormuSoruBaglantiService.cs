using System;
using Repository.Modules.Seyehat.Repository;
using DTO.Modules.Seyehat;
using Entity.Seyehat;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modules.Seyehat;

namespace Service.Modules.Seyehat
{
    public class EgitimDetayFormuSoruBaglantiService
    {
        #region Repository

        private EgitimDetayFormuSoruBaglantiRepository _olayBilgiFormuSoruRepository;

        protected EgitimDetayFormuSoruBaglantiRepository EgitimDetayFormuSoruBaglantiRepository
        {
            get { return _olayBilgiFormuSoruRepository ?? (_olayBilgiFormuSoruRepository = new EgitimDetayFormuSoruBaglantiRepository()); }
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruBaglantiDTO EgitimDetayFormuSoruBaglantiGetir(int EgitimDetayFormuSoruBaglantiId)
        {
            if (EgitimDetayFormuSoruBaglantiId <= 0) return null;

            var EgitimDetayFormuSoruBaglanti = EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiGetir(EgitimDetayFormuSoruBaglantiId);

            return EgitimDetayFormuSoruBaglanti == null
                ? null
                : new EgitimDetayFormuSoruBaglantiDTO
                {
                    Id = EgitimDetayFormuSoruBaglanti.Id,
                    Tur = EgitimDetayFormuSoruBaglanti.Tur,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruBaglanti.EDFSoruId,
                    Aktif = EgitimDetayFormuSoruBaglanti.Aktif

                };
        }

        public List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListele()
        {
            var EgitimDetayFormuSoruBaglantiListesi = EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiListele()
                .Select(EgitimDetayFormuSoruBaglanti => new EgitimDetayFormuSoruBaglantiDTO
                {
                    Id = EgitimDetayFormuSoruBaglanti.Id,
                    Tur = EgitimDetayFormuSoruBaglanti.Tur,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruBaglanti.EDFSoruId,
                    Aktif = EgitimDetayFormuSoruBaglanti.Aktif

                })
                .ToList();

            return EgitimDetayFormuSoruBaglantiListesi;
        }
        public List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListele(int id)
        {
            var EgitimDetayFormuSoruBaglantiListesi = EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiListele(id)
                .Select(EgitimDetayFormuSoruBaglanti => new EgitimDetayFormuSoruBaglantiDTO
                {
                    Id = EgitimDetayFormuSoruBaglanti.Id,
                    Tur = EgitimDetayFormuSoruBaglanti.Tur,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruBaglanti.EDFSoruId,
                    Aktif = EgitimDetayFormuSoruBaglanti.Aktif

                })
                .ToList();

            return EgitimDetayFormuSoruBaglantiListesi;
        }
        public List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListeleByTur(int tur, bool aktif)
        {
            var EgitimDetayFormuSoruBaglantiListesi = EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiListeleByTur(tur, aktif)
                .Select(EgitimDetayFormuSoruBaglanti => new EgitimDetayFormuSoruBaglantiDTO
                {
                    Id = EgitimDetayFormuSoruBaglanti.Id,
                    Tur = EgitimDetayFormuSoruBaglanti.Tur,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruBaglanti.EDFSoruId,
                    Aktif = EgitimDetayFormuSoruBaglanti.Aktif

                })
                .ToList();

            return EgitimDetayFormuSoruBaglantiListesi;
        }
        public List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListeleByTur(int tur)
        {
            var EgitimDetayFormuSoruBaglantiListesi = EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiListeleByTur(tur)
                .Select(EgitimDetayFormuSoruBaglanti => new EgitimDetayFormuSoruBaglantiDTO
                {
                    Id = EgitimDetayFormuSoruBaglanti.Id,
                    Tur = EgitimDetayFormuSoruBaglanti.Tur,
                    EgitimDetayFormuSoruId = EgitimDetayFormuSoruBaglanti.EDFSoruId,
                    Aktif = EgitimDetayFormuSoruBaglanti.Aktif

                })
                .ToList();

            return EgitimDetayFormuSoruBaglantiListesi;
        }
        public Tuple<bool, string> EgitimDetayFormuSoruBaglantiEkle(EgitimDetayFormuSoruBaglantiDTO EgitimDetayFormuSoruBaglanti)
        {
            if (EgitimDetayFormuSoruBaglanti == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuSoruBaglanti = new EgitimDetayFormuSoruBaglanti
            {

                Tur = EgitimDetayFormuSoruBaglanti.Tur,
                EDFSoruId = EgitimDetayFormuSoruBaglanti.EgitimDetayFormuSoruId,
                Aktif = EgitimDetayFormuSoruBaglanti.Aktif

            };

            try
            {
                EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiEkle(yeniEgitimDetayFormuSoruBaglanti);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaglantiGuncelle(EgitimDetayFormuSoruBaglantiDTO EgitimDetayFormuSoruBaglanti)
        {
            if (EgitimDetayFormuSoruBaglanti == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleEgitimDetayFormuSoruBaglanti = new EgitimDetayFormuSoruBaglanti
            {
                Id = EgitimDetayFormuSoruBaglanti.Id,
                Tur = EgitimDetayFormuSoruBaglanti.Tur,
                EDFSoruId = EgitimDetayFormuSoruBaglanti.EgitimDetayFormuSoruId,
                Aktif = EgitimDetayFormuSoruBaglanti.Aktif
            };

            try
            {
                EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiGuncelle(guncelleEgitimDetayFormuSoruBaglanti);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuSoruBaglantiSil(int EgitimDetayFormuSoruBaglantiId)
        {
            if (EgitimDetayFormuSoruBaglantiId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var EgitimDetayFormuSoruBaglanti = new EgitimDetayFormuSoruBaglanti { Id = EgitimDetayFormuSoruBaglantiId };
                EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiSil(EgitimDetayFormuSoruBaglanti);
                return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }


        public void SorulariGonder(List<int> secilenKonular, int turId)
        {
            if (secilenKonular == null || turId <= 0)
                return;

            var kayitliOlanKonular = EgitimDetayFormuSoruBaglantiListeleByTur(turId).Any() ? EgitimDetayFormuSoruBaglantiListeleByTur(turId).ToList() : null;
            var silinecekKonular = new List<EgitimDetayFormuSoruBaglantiDTO>();

            //Secilen konularda olan bir kayıt daha önceden kayıtlıysa tekrar kayıt atmamak için..
            //foreach (var egitimKonulariId in secilenKonular)
            //{

            //    var kontrolId = EgitimTuruKonuRepository.EgitimTuruKonuKontrol(turId, egitimKonulariId);

            //    if (kontrolId == 0)
            //    {
            //        var yeniSoruBaglanti = new EgitimTuruKonu
            //        {

            //            EgitimKonulariId = egitimKonulariId,
            //            IsGuvenligiEgitimTuruId = turId

            //        };
            //        EgitimTuruKonuRepository.EgitimTuruKonuEkle(yeniSoruBaglanti);
            //    }

            //}

            if (kayitliOlanKonular != null)
            {
                foreach (var item in kayitliOlanKonular)
                {
                    var konu = secilenKonular.Where(k => k == item.EgitimDetayFormuSoruId);

                    // iki listede varsa yeniden eklememek için eklenecek listesinden kaldır
                    if (konu.Any())
                    {
                        secilenKonular.Remove(konu.FirstOrDefault());
                        if (item.Aktif == false)
                        {
                            var sorubaglanti = new EgitimDetayFormuSoruBaglanti { Id = item.Id, Aktif = true };
                            EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiGuncelle(sorubaglanti);
                        }

                    }

                    else
                    {
                        silinecekKonular.Add(item);
                    }

                }

            }

            // eklenecek listesinde yoksa varolan kaydı sil
            if (silinecekKonular.Count() > 0)
                KonularTopluSil(silinecekKonular);

            // secilenKonular listesinde kayıt kalmışsa yeni kayıt oluştur
            if (secilenKonular.Count() > 0)
                KonularTopluEkleAuto(secilenKonular, turId);



        }

        public void KonularTopluSil(List<EgitimDetayFormuSoruBaglantiDTO> silinecekKonular)
        {
            foreach (var item in silinecekKonular)
            {
                var sorubaglanti = new EgitimDetayFormuSoruBaglanti { Id = item.Id, Aktif = false };
                EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiGuncelle(sorubaglanti);
            }
        }

        public void KonularTopluEkleAuto(List<int> secilenKonular, int secilenTur)
        {
            if (secilenKonular.Count() == 0)
                return;

            foreach (var item in secilenKonular)
            {
                var yeniSoruBaglanti = new EgitimDetayFormuSoruBaglanti
                {

                    EDFSoruId = item,
                    Tur = secilenTur,
                    Aktif = true

                };

                EgitimDetayFormuSoruBaglantiRepository.EgitimDetayFormuSoruBaglantiEkle(yeniSoruBaglanti);
            }
        }
        #endregion
    }
}
