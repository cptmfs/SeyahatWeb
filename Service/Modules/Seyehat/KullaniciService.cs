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
    public class KullaniciService
    {

        #region Repository

        private KullaniciRepository _kullaniciRepository;

        protected KullaniciRepository KullaniciRepository
        {
            get { return _kullaniciRepository ?? (_kullaniciRepository = new KullaniciRepository()); }
        }



        #endregion

        #region Methods

        public KullaniciDTO KullaniciGetir(int kullaniciId)
        {
            if (kullaniciId <= 0) return null;

            var kullanici = KullaniciRepository.KullaniciBilgiGetir(kullaniciId);

            return kullanici == null ? null : new KullaniciDTO
            {
                Id = kullanici.Id,
                UserName = kullanici.UserName,
                Password = kullanici.Password,
                Name = kullanici.Name,
                Surname = kullanici.Surname,
                EMail = kullanici.EMail
            };

        }

        public List<KullaniciDTO> KullaniciListele()
        {
            var kullaniciListesi = KullaniciRepository.KullaniciBilgiListele()
                .Select(kullanici => new KullaniciDTO
                {
                    Id = kullanici.Id,
                    UserName = kullanici.UserName,
                    Password = kullanici.Password,
                    Name = kullanici.Name,
                    Surname = kullanici.Surname,
                    EMail = kullanici.EMail


                })
                .OrderBy(kullanici => kullanici.Id)
                .ToList();

            return kullaniciListesi;
        }
        // Aktif Ekle
        public IQueryable<KullaniciDTO> KullaniciFiltrele(string userName)
        {
            var kullaniciList = KullaniciRepository.KullaniciFiltreleByUserName();


            if (!kullaniciList.Any()) return null;

            return kullaniciList.OrderBy(x => x.Id)
                           .Select(kullanici => new KullaniciDTO
                           {
                               Id = kullanici.Id,
                               UserName = kullanici.UserName,
                               Password = kullanici.Password,
                               Name = kullanici.Name,
                               Surname = kullanici.Surname,
                               EMail = kullanici.EMail
                           });
        }

        public Tuple<bool, string> KullaniciEkle(KullaniciDTO kullanici)
        {
            if (kullanici == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniKullanici = new tblKullanici
            {
                Id = kullanici.Id,
                UserName = kullanici.UserName,
                Password = kullanici.Password,
                Name = kullanici.Name,
                Surname = kullanici.Surname,
                EMail = kullanici.EMail
            };

            try
            {
                KullaniciRepository.KullaniciBilgiEkle(yeniKullanici);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> KullaniciGuncelle(KullaniciDTO kullanici)
        {
            if (kullanici == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleKullanici = new tblKullanici
            {
                Id = kullanici.Id,
                UserName = kullanici.UserName,
                Password = kullanici.Password,
                Name = kullanici.Name,
                Surname = kullanici.Surname,
                EMail = kullanici.EMail
            };

            try
            {
                KullaniciRepository.KullaniciBilgiGuncelle(guncelleKullanici);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> KullaniciSil(int kullaniciId)
        {
            if (kullaniciId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var kullanici = new tblKullanici { Id = kullaniciId };
                KullaniciRepository.KullaniciSil(kullanici);
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
