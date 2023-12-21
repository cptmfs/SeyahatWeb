using DTO.Modules.Seyehat;
using Entity.Seyehat;
using Repository.Modules.Seyehat.Repository;
using Service.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class EgitimDetayFormuGuncellemeService
    {
        #region Repository

        private EgitimDetayFormuGuncellemeRepository _olayBilgiFormuGuncellemeRepository;

        protected EgitimDetayFormuGuncellemeRepository EgitimDetayFormuGuncellemeRepository
        {
            get { return _olayBilgiFormuGuncellemeRepository ?? (_olayBilgiFormuGuncellemeRepository = new EgitimDetayFormuGuncellemeRepository()); }
        }

        #endregion
        #region Service

        private KullaniciService _kullaniciService;

        protected KullaniciService KullaniciService
        {
            get { return _kullaniciService ?? (_kullaniciService = new KullaniciService()); }
        }

        #endregion


        #region Methods

        public EgitimDetayFormuGuncellemeDTO EgitimDetayFormuGuncellemeGetir(int olayBilgiFormuGuncellemeId)
        {

            if (olayBilgiFormuGuncellemeId <= 0) return null;
            var olayBilgiFormuGuncelleme = EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeGetir(olayBilgiFormuGuncellemeId);

            return olayBilgiFormuGuncelleme == null
                ? null
                : new EgitimDetayFormuGuncellemeDTO
                {
                    Id = olayBilgiFormuGuncelleme.Id,
                    EgitimDetayFormuId = olayBilgiFormuGuncelleme.EgitimDetayFormuId,
                    Aciklama = olayBilgiFormuGuncelleme.Aciklama

                };
        }


        public List<EgitimDetayFormuGuncellemeDTO> EgitimDetayFormuGuncellemeListele()
        {
            var olayBilgiFormuGuncellemeListesi = EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeListele()
                .Select(olayBilgiFormuGuncelleme => new EgitimDetayFormuGuncellemeDTO
                {
                    Id = olayBilgiFormuGuncelleme.Id,
                    EgitimDetayFormuId = olayBilgiFormuGuncelleme.EgitimDetayFormuId,
                    Aciklama = olayBilgiFormuGuncelleme.Aciklama,
                    OlusturulmaTarihi = olayBilgiFormuGuncelleme.OlusturulmaTarihi.Value

                })
                .OrderBy(olayBilgiFormuGuncelleme => olayBilgiFormuGuncelleme.Id)
                .ToList();

            return olayBilgiFormuGuncellemeListesi;
        }

        public List<EgitimDetayFormuGuncellemeDTO> EgitimDetayFormuGuncellemeListeleByForm(int formId)
        {
            var olayBilgiFormuGuncellemeListesi = EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeListeleByForm(formId)
                .Select(olayBilgiFormuGuncelleme => new EgitimDetayFormuGuncellemeDTO
                {
                    Id = olayBilgiFormuGuncelleme.Id,
                    EgitimDetayFormuId = olayBilgiFormuGuncelleme.EgitimDetayFormuId,
                    Aciklama = olayBilgiFormuGuncelleme.Aciklama,
                    OlusturulmaTarihi = olayBilgiFormuGuncelleme.OlusturulmaTarihi.Value,
                    OlusturanKullanici = olayBilgiFormuGuncelleme.OlusturanKullanici

                })
                .OrderBy(olayBilgiFormuGuncelleme => olayBilgiFormuGuncelleme.Id)
                .ToList();
            var kullaniciListe = KullaniciService.KullaniciListele();
            foreach (var item in olayBilgiFormuGuncellemeListesi)
            {
                item.OlusturanKullaniciTanim = item.OlusturanKullanici.HasValue ? kullaniciListe.Where(i => i.Id == item.OlusturanKullanici).FirstOrDefault().Name : "";
            }
            return olayBilgiFormuGuncellemeListesi;
        }

        public Tuple<bool, string> EgitimDetayFormuGuncellemeEkle(EgitimDetayFormuGuncellemeDTO olayBilgiFormuGuncelleme)
        {
            if (olayBilgiFormuGuncelleme == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuGuncelleme = new EgitimDetayFormuGuncelleme
            {
                EgitimDetayFormuId = olayBilgiFormuGuncelleme.EgitimDetayFormuId,
                Aciklama = olayBilgiFormuGuncelleme.Aciklama
            };

            try
            {
                EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeEkle(yeniEgitimDetayFormuGuncelleme);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuGuncellemeGuncelle(EgitimDetayFormuGuncellemeDTO olayBilgiFormuGuncelleme)
        {
            if (olayBilgiFormuGuncelleme == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormuGuncelleme = new EgitimDetayFormuGuncelleme
            {
                Id = olayBilgiFormuGuncelleme.Id,
                Aciklama = olayBilgiFormuGuncelleme.Aciklama
            };

            try
            {
                EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeGuncelleme(yeniEgitimDetayFormuGuncelleme);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuGuncellemeSil(int olayBilgiFormuGuncellemeId)
        {
            if (olayBilgiFormuGuncellemeId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var olayBilgiFormuGuncelleme = new EgitimDetayFormuGuncelleme { Id = olayBilgiFormuGuncellemeId };
                EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeSil(olayBilgiFormuGuncelleme);
                return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> EgitimDetayFormuGuncellemeTopluSil(List<EgitimDetayFormuGuncellemeDTO> olayBilgiFormuGuncellemeListesi)
        {
            if (olayBilgiFormuGuncellemeListesi.Count() == 0)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            foreach (var item in olayBilgiFormuGuncellemeListesi)
            {
                var olayBilgiFormuGuncelleme = new EgitimDetayFormuGuncelleme { Id = item.Id };
                EgitimDetayFormuGuncellemeRepository.EgitimDetayFormuGuncellemeSil(olayBilgiFormuGuncelleme);
            }

            return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");

        }
        #endregion
    }
}
