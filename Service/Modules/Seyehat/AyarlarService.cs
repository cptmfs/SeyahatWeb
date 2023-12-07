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
    public class AyarlarService
    {
        #region Repository

        private AyarlarRepository _ayarlarRepository;

        protected AyarlarRepository AyarlarRepository
        {
            get { return _ayarlarRepository ?? (_ayarlarRepository = new AyarlarRepository()); }
        }

       

        #endregion

        #region Methods

        public AyarlarDTO AyarGetir(int ayarId)
        {
            if (ayarId <= 0) return null;

            var ayar = AyarlarRepository.AyarBilgiGetir(ayarId);

            return ayar == null ? null : new AyarlarDTO
            {
                Id = ayar.Id,
                Adres = ayar.Adres,
                Facebook = ayar.Facebook,
                Logo = ayar.Logo,
                Mail = ayar.Mail,
                SiteOzet = ayar.SiteOzet,
                Telefon = ayar.Telefon,
                Youtube = ayar.Youtube
            };
        
        }

        public List<AyarlarDTO> AyarListele()
        {
            var ayarListesi = AyarlarRepository.AyarBilgiListele()
                .Select(ayar => new AyarlarDTO
                {
                    Id = ayar.Id,
                    Adres = ayar.Adres,
                    Facebook = ayar.Facebook,
                    Logo = ayar.Logo,
                    Mail = ayar.Mail,
                    SiteOzet = ayar.SiteOzet,
                    Telefon = ayar.Telefon,
                    Youtube = ayar.Youtube


                })
                .OrderBy(ayar => ayar.Id)
                .ToList();

            return ayarListesi;
        }

        public IQueryable<AyarlarDTO> AyarFiltrele(string siteOzet)
        {
            var ayarList = AyarlarRepository.AyarFiltreleBySiteOzet();
           

            if (!ayarList.Any()) return null;

            return ayarList.OrderBy(x => x.SiteOzet==siteOzet)
                           .Select(ayar => new AyarlarDTO
                           {
                               Id = ayar.Id,
                               Adres = ayar.Adres,
                               Facebook = ayar.Facebook,
                               Logo = ayar.Logo,
                               Mail = ayar.Mail,
                               SiteOzet = ayar.SiteOzet,
                               Telefon = ayar.Telefon,
                               Youtube = ayar.Youtube
                           });
        }

        public Tuple<bool, string> AyarEkle(AyarlarDTO ayar)
        {
            if (ayar == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniAyar = new tblAyarlar
            {
                Id = ayar.Id,
                Adres = ayar.Adres,
                Facebook = ayar.Facebook,
                Logo = ayar.Logo,
                Mail = ayar.Mail,
                SiteOzet = ayar.SiteOzet,
                Telefon = ayar.Telefon,
                Youtube = ayar.Youtube
            };

            try
            {
                AyarlarRepository.AyarBilgiEkle(yeniAyar);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> AyarGuncelle(AyarlarDTO ayar)
        {
            if (ayar == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleAyar = new tblAyarlar
            {
                Id = ayar.Id,
                Adres = ayar.Adres,
                Facebook = ayar.Facebook,
                Logo = ayar.Logo,
                Mail = ayar.Mail,
                SiteOzet = ayar.SiteOzet,
                Telefon = ayar.Telefon,
                Youtube = ayar.Youtube
            };

            try
            {
                AyarlarRepository.AyarBilgiGuncelle(guncelleAyar);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> AyarSil(int ayarId)
        {
            if (ayarId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var ayar = new tblAyarlar { Id = ayarId };
                AyarlarRepository.AyarSil(ayar);
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
