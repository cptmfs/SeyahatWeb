using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Repository.Modules.Seyehat.Repository
{
    public class EgitimTuruRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimTuruRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimTuru EgitimTuruGetir(int id)
        {
            return _unitOfWork.EgitimTuru.GetById(id);
        }

        public IQueryable<EgitimTuru> VeriKaynaklariniListele()
        {
            return _unitOfWork.EgitimTuru.GetAll();
        }


        public void EgitimTuruEkle(EgitimTuru EgitimTuru)
        {
            _unitOfWork.EgitimTuru.Insert(EgitimTuru);
            _unitOfWork.Save();
        }

        public void EgitimTuruGuncelle(EgitimTuru EgitimTuru)
        {
            var guncelleEgitimTuru = _unitOfWork.EgitimTuru.GetById(EgitimTuru.Id);

            if (guncelleEgitimTuru == null) return;

            guncelleEgitimTuru.Tanim = EgitimTuru.Tanim;

            guncelleEgitimTuru.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimTuru.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimTuruSil(EgitimTuru EgitimTuru, bool fizikselSil = false)
        {
            var kayitliEgitimTuru = _unitOfWork.EgitimTuru.GetById(EgitimTuru.Id);
            _unitOfWork.EgitimTuru.Delete(kayitliEgitimTuru, fizikselSil);
            _unitOfWork.Save();
        }
        #endregion
    }
}
