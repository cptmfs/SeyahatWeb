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
    public class TurPaketService
    {
        #region Repository

        private TurPaketRepository _turPaketRepository;

        protected TurPaketRepository TurPaketRepository
        {
            get { return _turPaketRepository ?? (_turPaketRepository = new TurPaketRepository()); }
        }



        #endregion

        #region Methods

        public TurPaketDTO TurPaketGetir(int turPaketId)
        {
            if (turPaketId <= 0) return null;

            var turPaket = TurPaketRepository.TurPaketBilgiGetir(turPaketId);

            return turPaket == null ? null : new TurPaketDTO
            {
                Id = turPaket.Id,
                Adi=turPaket.Adi,
                Detay=turPaket.Detay,
                Fiyat= turPaket.Fiyat,
                Lokasyon= turPaket.Lokasyon,
                Resim=turPaket.Resim,
                Sure = turPaket.Sure

            };

        }

        public List<TurPaketDTO> TurPaketListele()
        {
            var turPaketListesi = TurPaketRepository.TurPaketBilgiListele()
                .Select(turPaket => new TurPaketDTO
                {
                    Id = turPaket.Id,
                    Adi = turPaket.Adi,
                    Detay = turPaket.Detay,
                    Fiyat = turPaket.Fiyat,
                    Lokasyon = turPaket.Lokasyon,
                    Resim = turPaket.Resim,
                    Sure = turPaket.Sure


                })
                .OrderBy(turPaket => turPaket.Id)
                .ToList();

            return turPaketListesi;
        }
        // Aktif Ekle
        public IQueryable<TurPaketDTO> TurPaketFiltrele(string lokasyon)
        {
            var turPaketList = TurPaketRepository.TurPaketFiltreleByLokasyon();


            if (!turPaketList.Any()) return null;

            return turPaketList.OrderBy(x => x.Lokasyon== lokasyon)
                           .Select(turPaket => new TurPaketDTO
                           {
                               Id = turPaket.Id,
                               Adi = turPaket.Adi,
                               Detay = turPaket.Detay,
                               Fiyat = turPaket.Fiyat,
                               Lokasyon = turPaket.Lokasyon,
                               Resim = turPaket.Resim,
                               Sure = turPaket.Sure
                           });
        }

        public Tuple<bool, string> TurPaketEkle(TurPaketDTO turPaket)
        {
            if (turPaket == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniTurPaket = new tblTurPaket
            {
                Id = turPaket.Id,
                Adi = turPaket.Adi,
                Detay = turPaket.Detay,
                Fiyat = turPaket.Fiyat,
                Lokasyon = turPaket.Lokasyon,
                Resim = turPaket.Resim,
                Sure = turPaket.Sure
            };

            try
            {
                TurPaketRepository.TurPaketBilgiEkle(yeniTurPaket);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> TurPaketGuncelle(TurPaketDTO turPaket)
        {
            if (turPaket == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleTurPaket = new tblTurPaket
            {
                Id = turPaket.Id,
                Adi = turPaket.Adi,
                Detay = turPaket.Detay,
                Fiyat = turPaket.Fiyat,
                Lokasyon = turPaket.Lokasyon,
                Resim = turPaket.Resim,
                Sure = turPaket.Sure
            };

            try
            {
                TurPaketRepository.TurPaketBilgiGuncelle(guncelleTurPaket);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> TurPaketSil(int turPaketId)
        {
            if (turPaketId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var turPaket = new tblTurPaket { Id = turPaketId };
                TurPaketRepository.TurPaketSil(turPaket);
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
