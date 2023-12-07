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
    public class GaleriKategoriService
    {
        #region Repository

        private GaleriKategoriRepository _galeriKategoriRepository;

        protected GaleriKategoriRepository GaleriKategoriRepository
        {
            get { return _galeriKategoriRepository ?? (_galeriKategoriRepository = new GaleriKategoriRepository()); }
        }



        #endregion

        #region Methods

        public GaleriKategoriDTO GaleriKategoriGetir(int galeriKategoriId)
        {
            if (galeriKategoriId <= 0) return null;

            var galeriKategori = GaleriKategoriRepository.GaleriKategoriBilgiGetir(galeriKategoriId);

            return galeriKategori == null ? null : new GaleriKategoriDTO
            {
                Id = galeriKategori.Id,
                Adi = galeriKategori.Adi

            };

        }

        public List<GaleriKategoriDTO> GaleriKategoriListele()
        {
            var galeriKategoriListesi = GaleriKategoriRepository.GaleriKategoriBilgiListele()
                .Select(galeriKategori => new GaleriKategoriDTO
                {
                    Id = galeriKategori.Id,
                    Adi=galeriKategori.Adi
                })
                .OrderBy(galeriKategori => galeriKategori.Id)
                .ToList();

            return galeriKategoriListesi;
        }


        public Tuple<bool, string> GaleriKategoriEkle(GaleriKategoriDTO galeriKategori)
        {
            if (galeriKategori == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniGaleriKategori = new tblGaleriKategori
            {
                Id = galeriKategori.Id,
                Adi = galeriKategori.Adi

            };

            try
            {
                GaleriKategoriRepository.GaleriKategoriBilgiEkle(yeniGaleriKategori);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> GaleriKategoriGuncelle(GaleriKategoriDTO galeriKategori)
        {
            if (galeriKategori == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleGaleri = new tblGaleriKategori
            {
                Id = galeriKategori.Id,
                Adi = galeriKategori.Adi

            };

            try
            {
                GaleriKategoriRepository.GaleriKategoriBilgiGuncelle(guncelleGaleri);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> GaleriSil(int galeriKategoriId)
        {
            if (galeriKategoriId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var galeriKategori = new tblGaleriKategori { Id = galeriKategoriId };
                GaleriKategoriRepository.GaleriKategoriSil(galeriKategori);
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
