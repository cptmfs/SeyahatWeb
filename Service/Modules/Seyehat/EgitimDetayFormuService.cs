using DTO.Modules.Seyehat;
using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.Repository;
using Service.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class EgitimDetayFormuService
    {
        #region Repository

        private EgitimDetayFormuRepository _olayBilgiFormuRepository;

        protected EgitimDetayFormuRepository EgitimDetayFormuRepository
        {
            get { return _olayBilgiFormuRepository ?? (_olayBilgiFormuRepository = new EgitimDetayFormuRepository()); }
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

        public EgitimDetayFormuDTO EgitimDetayFormuGetir(int olayBilgiFormuId)
        {

            if (olayBilgiFormuId <= 0) return null;
            var olayBilgiFormu = EgitimDetayFormuRepository.EgitimDetayFormuGetir(olayBilgiFormuId);

            return olayBilgiFormu == null
                ? null
                : new EgitimDetayFormuDTO
                {
                    Id = olayBilgiFormu.Id,
                    OlusturulmaTarihi = olayBilgiFormu.OlusturulmaTarihi.Value,
                    Aktif = olayBilgiFormu.Aktif,
                    KapatanKullaniciId = olayBilgiFormu.KapatanKullaniciId,
                    KapatmaTarihi = olayBilgiFormu.KapatmaTarihi,
                    AcanKullaniciId = olayBilgiFormu.AcanKullaniciId,
                    AcmaTarihi = olayBilgiFormu.AcmaTarihi,
                    OlusturanKullanici = olayBilgiFormu.OlusturanKullanici,
                    Tur = olayBilgiFormu.Tur,
                    TurAciklama = olayBilgiFormu.Tur.HasValue ? olayBilgiFormu.Tur == 1 ? "Havalimanı OBF" : olayBilgiFormu.Tur == 2 ? "Deniz Limanı OBF" : olayBilgiFormu.Tur == 3 ? "Kara Hudut Kapıları OBF" : "-" : "-",
                    OlusturanKullaniciTanim = olayBilgiFormu.OlusturanKullanici.HasValue ? KullaniciService.KullaniciGetir(olayBilgiFormu.OlusturanKullanici.Value).Name : ""
                };
        }


        public List<EgitimDetayFormuDTO> EgitimDetayFormuListele()
        {
            var olayBilgiFormuListesi = EgitimDetayFormuRepository.EgitimDetayFormuListele()
                .Select(olayBilgiFormu => new EgitimDetayFormuDTO
                {
                    Id = olayBilgiFormu.Id,
                    OlusturulmaTarihi = olayBilgiFormu.OlusturulmaTarihi.Value,
                    Aktif = olayBilgiFormu.Aktif,
                    KapatanKullaniciId = olayBilgiFormu.KapatanKullaniciId,
                    KapatmaTarihi = olayBilgiFormu.KapatmaTarihi,
                    AcanKullaniciId = olayBilgiFormu.AcanKullaniciId,
                    AcmaTarihi = olayBilgiFormu.AcmaTarihi,
                    OlusturanKullanici = olayBilgiFormu.OlusturanKullanici,
                    Tur = olayBilgiFormu.Tur,

                    TurAciklama = olayBilgiFormu.Tur.HasValue ? olayBilgiFormu.Tur == 1 ? "Havalimanı OBF" : olayBilgiFormu.Tur == 2 ? "Deniz Limanı OBF" : olayBilgiFormu.Tur == 3 ? "Kara Hudut Kapıları OBF" : "-" : "-"
                    // AcmaTarihiAciklama = olayBilgiFormu.AcmaTarihi.HasValue ? olayBilgiFormu.AcmaTarihi.Value.ToShortDateString() : "",
                    // KapatmaTarihiAciklama = olayBilgiFormu.KapatmaTarihi.HasValue ? olayBilgiFormu.KapatmaTarihi.Value.ToShortDateString() : ""
                })

                .ToList();
            var kullaniciListe = KullaniciService.KullaniciListele();

            int counter = 1;
            foreach (var item in olayBilgiFormuListesi)
            {
              
                item.OlusturanKullaniciTanim = item.OlusturanKullanici.HasValue ? kullaniciListe.Where(i => i.Id == item.OlusturanKullanici).FirstOrDefault().Name : "";
                item.KapatanKullaniciAciklama = item.KapatanKullaniciId.HasValue ? kullaniciListe.Where(i => i.Id == item.KapatanKullaniciId).FirstOrDefault().Name : "";
                item.AcanKullaniciAciklama = item.AcanKullaniciId.HasValue ? kullaniciListe.Where(i => i.Id == item.AcanKullaniciId).FirstOrDefault().Name : "";
                item.AktifAciklama = item.Aktif.HasValue ? item.Aktif == true ? "Devam Ediyor" : "Sonlandırıldı" : "";
                item.SiraNo = counter;
                counter++;
            }
            return olayBilgiFormuListesi;
        }

       

        public Tuple<bool, string> EgitimDetayFormuEkle(EgitimDetayFormuDTO olayBilgiFormu)
        {
            if (olayBilgiFormu == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormu = new EgitimDetayFormu
            {
                Tur = olayBilgiFormu.Tur,
                Aktif = true
            };

            try
            {
                olayBilgiFormu.Id = EgitimDetayFormuRepository.EgitimDetayFormuEkle(yeniEgitimDetayFormu);
                var form = EgitimDetayFormuGetir(olayBilgiFormu.Id);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuAc(int id)
        {
            if (id == -1)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormu = new EgitimDetayFormu
            {
                Id = id,
                Aktif = true,
                AcmaTarihi = DateTime.Now,
                AcanKullaniciId = SessionHelper.KullaniciId
            };

            try
            {
                EgitimDetayFormuRepository.EgitimDetayFormuAc(yeniEgitimDetayFormu);
                return new Tuple<bool, string>(true, "Süreci yeniden başlatma işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Süreci yeniden başlatma işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuKapat(int id)
        {
            if (id == -1)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniEgitimDetayFormu = new EgitimDetayFormu
            {
                Id = id,
                Aktif = false,
                KapatmaTarihi = DateTime.Now,
                KapatanKullaniciId = SessionHelper.KullaniciId
            };

            try
            {
                EgitimDetayFormuRepository.EgitimDetayFormuKapat(yeniEgitimDetayFormu);
                return new Tuple<bool, string>(true, "Süreç başarıyla sonlandırılmıştır.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Süreç sonlandırma işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }
        public Tuple<bool, string> EgitimDetayFormuSil(int olayBilgiFormuId)
        {
            if (olayBilgiFormuId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var olayBilgiFormu = new EgitimDetayFormu { Id = olayBilgiFormuId };
                EgitimDetayFormuRepository.EgitimDetayFormuSil(olayBilgiFormu);
                return new Tuple<bool, string>(true, "Eğitim Detay Formu ve ilgili kayıtları silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }


        #endregion
    }
}
