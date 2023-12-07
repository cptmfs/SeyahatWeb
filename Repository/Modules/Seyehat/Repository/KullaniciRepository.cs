using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Repository.Modules.SeyehatWeb.Repository
{
    public class KullaniciRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public KullaniciRepository()
        {
            if (_unitOfWork == null)
            _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblKullanici KullaniciBilgiGetir(int id)
        {
            return _unitOfWork.tblKullanici.GetById(id);
        }

        public IQueryable<tblKullanici> KullaniciBilgiListele()
        {
            return _unitOfWork.tblKullanici.GetAll()
                .OrderByDescending(x => x.Id);
        }
        public IQueryable<tblKullanici> KullaniciFiltreleByUserName()
        {
            return _unitOfWork.tblKullanici.GetAll()
               .OrderByDescending(x => x.UserName);
        }


        public void KullaniciBilgiEkle(tblKullanici kullanici)
        {
            _unitOfWork.tblKullanici.Insert(kullanici);
            _unitOfWork.Save();
        }

        public void KullaniciBilgiGuncelle(tblKullanici kullanici)
        {
            var guncelleKullanici = _unitOfWork.tblKullanici.GetById(kullanici.Id);

            if (guncelleKullanici == null) return;

            guncelleKullanici.UserName = kullanici.UserName;
            guncelleKullanici.Password= kullanici.Password;
            guncelleKullanici.Name = kullanici.Name;
            guncelleKullanici.Surname = kullanici.Surname;
            guncelleKullanici.EMail = kullanici.EMail;
            


            guncelleKullanici.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleKullanici.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void KullaniciSil(tblKullanici kullanici, bool fizikselSil = false)
        {
            var silinecekKullaniciKaydi = _unitOfWork.tblKullanici.GetById(kullanici.Id);
            _unitOfWork.tblKullanici.Delete(silinecekKullaniciKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
