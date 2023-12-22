using DTO.Modules.Seyehat;
using Entity.Seyehat;
using Repository.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.Seyehat
{
    public class VeriKaynagiService
    {
        #region Repository

        private VeriKaynagiRepository _VeriKaynagiRepository;
        protected VeriKaynagiRepository VeriKaynagiRepository
        {
            get
            {
                return _VeriKaynagiRepository ?? (_VeriKaynagiRepository = new VeriKaynagiRepository());
            }
        }

        #endregion

        #region Methods

        public VeriKaynagiDTO VeriKaynagiGetir(int VeriKaynagiId)
        {
            if (VeriKaynagiId <= 0) return null;

            var VeriKaynagi = VeriKaynagiRepository.VeriKaynagiGetir(VeriKaynagiId);

            if (VeriKaynagi == null) return null;

            return new VeriKaynagiDTO
            {
                Id = VeriKaynagi.Id,
                Tanim = VeriKaynagi.Tanim
            };
        }

        public IQueryable<VeriKaynagiDTO> VeriKaynaklariniListele()
        {
            return VeriKaynagiRepository.VeriKaynaklariniListele()
                .Select(VeriKaynagi => new VeriKaynagiDTO
                {
                    Id = VeriKaynagi.Id,
                    Tanim = VeriKaynagi.Tanim
                });
        }
        public List<VeriKaynagiDTO> VeriKaynaklariniList()
        {
            return VeriKaynagiRepository.VeriKaynaklariniListele()
                .Select(VeriKaynagi => new VeriKaynagiDTO
                {
                    Id = VeriKaynagi.Id,
                    Tanim = VeriKaynagi.Tanim
                }).ToList();
        }
        public Tuple<bool, string> VeriKaynagiEkle(VeriKaynagiDTO VeriKaynagi)
        {
            if (VeriKaynagi == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniVeriKaynagi = new VeriKaynagi
            {
                Tanim = VeriKaynagi.Tanim,
            };
            try
            {
                VeriKaynagiRepository.VeriKaynagiEkle(yeniVeriKaynagi);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> VeriKaynagiGuncelle(VeriKaynagiDTO VeriKaynagi)
        {
            if (VeriKaynagi == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleVeriKaynagi = new VeriKaynagi
            {
                Id = VeriKaynagi.Id,
                Tanim = VeriKaynagi.Tanim
            };

            try
            {
                VeriKaynagiRepository.VeriKaynagiGuncelle(guncelleVeriKaynagi);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> VeriKaynagiSil(int VeriKaynagiId)
        {
            if (VeriKaynagiId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var VeriKaynagi = new VeriKaynagi { Id = VeriKaynagiId };
                VeriKaynagiRepository.VeriKaynagiSil(VeriKaynagi);
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
