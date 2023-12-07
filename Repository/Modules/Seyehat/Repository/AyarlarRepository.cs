using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modules.SeyehatWeb.Repository
{
    public class AyarlarRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public AyarlarRepository()
        {
            if (_unitOfWork == null) return;
            //_unitOfWork = ContainerHelper.Container.Resolve<ISeyehatWebUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblAyarlar AyarBilgiGetir(int id)
        {
            return _unitOfWork.tblAyarlar.GetById(id);
        }

        public IQueryable<tblAyarlar> AyarBilgiListele()
        {
            return _unitOfWork.tblAyarlar.GetAll()
                .OrderByDescending(x => x.Id);
        }

        public IQueryable<tblAyarlar> AyarFiltreleBySiteOzet()
        {
            return _unitOfWork.tblAyarlar.GetAll()
               .OrderByDescending(x => x.SiteOzet);
        }

        public void AyarBilgiEkle(tblAyarlar ayar)
        {
            _unitOfWork.tblAyarlar.Insert(ayar);
            _unitOfWork.Save();
        }

        public void AyarBilgiGuncelle(tblAyarlar ayar)
        {
            var guncelleAyar = _unitOfWork.tblAyarlar.GetById(ayar.Id);

            if (guncelleAyar == null) return;

            guncelleAyar.Mail = ayar.Mail;
            guncelleAyar.Telefon = ayar.Telefon;
            guncelleAyar.Adres = ayar.Adres;
            guncelleAyar.Youtube = ayar.Youtube;
            guncelleAyar.Instagram = ayar.Instagram;
            guncelleAyar.Facebook = ayar.Facebook;
            guncelleAyar.Logo = ayar.Logo;
            guncelleAyar.SiteOzet = ayar.SiteOzet;


            guncelleAyar.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleAyar.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void AyarSil(tblAyarlar ayar, bool fizikselSil = false)
        {
            var silinecekAyarKaydi = _unitOfWork.tblAyarlar.GetById(ayar.Id);
            _unitOfWork.tblAyarlar.Delete(silinecekAyarKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
