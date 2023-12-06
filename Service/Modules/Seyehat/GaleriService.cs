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
    public class GaleriService
    {
        #region Repository

        private GaleriRepository _galeriRepository;

        protected GaleriRepository GaleriRepository
        {
            get { return _galeriRepository ?? (_galeriRepository = new GaleriRepository()); }
        }



        #endregion

        #region Methods

        public GaleriDTO GaleriGetir(int galeriId)
        {
            if (galeriId <= 0) return null;

            var galeri = GaleriRepository.GaleriBilgiGetir(galeriId);

            return galeri == null ? null : new GaleriDTO
            {
                Id = galeri.Id,
                Baslik = galeri.Baslik,
                KategoriId = galeri.KategoriId,
                KategoriAciklama = galeri.tblGaleriKategori.Adi,
                Resim = galeri.Resim

            };

        }

        public List<GaleriDTO> GaleriListele()
        {
            var galeriListesi = GaleriRepository.GaleriBilgiListele()
                .Select(galeri => new GaleriDTO
                {
                    Id = galeri.Id,
                    Baslik = galeri.Baslik,
                    KategoriId = galeri.KategoriId,
                    KategoriAciklama = galeri.tblGaleriKategori.Adi,
                    Resim = galeri.Resim


                })
                .OrderBy(galeri => galeri.Id)
                .ToList();

            return galeriListesi;
        }
        // Aktif Ekle
        public IQueryable<GaleriDTO> GaleriFiltrele(string baslik)
        {
            var galeriList = GaleriRepository.GaleriFiltreleByBaslik();


            if (!galeriList.Any()) return null;

            return galeriList.OrderBy(x => x.Baslik==baslik)
                           .Select(galeri => new GaleriDTO
                           {
                               Id = galeri.Id,
                               Baslik = galeri.Baslik,
                               KategoriId = galeri.KategoriId,
                               KategoriAciklama = galeri.tblGaleriKategori.Adi,
                               Resim = galeri.Resim
                           });
        }

        public Tuple<bool, string> GaleriEkle(GaleriDTO galeri)
        {
            if (galeri == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniGaleri = new tblGaleri
            {
                Id = galeri.Id,
                Baslik = galeri.Baslik,
                KategoriId = galeri.KategoriId,
                Resim = galeri.Resim
            };

            try
            {
                GaleriRepository.GaleriBilgiEkle(yeniGaleri);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> GaleriGuncelle(GaleriDTO galeri)
        {
            if (galeri == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleGaleri = new tblGaleri
            {
                Id = galeri.Id,
                Baslik = galeri.Baslik,
                KategoriId = galeri.KategoriId,
                Resim = galeri.Resim
            };

            try
            {
                GaleriRepository.GaleriBilgiGuncelle(guncelleGaleri);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> GaleriSil(int galeriId)
        {
            if (galeriId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var galeri = new tblGaleri { Id = galeriId };
                GaleriRepository.GaleriSil(galeri);
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
