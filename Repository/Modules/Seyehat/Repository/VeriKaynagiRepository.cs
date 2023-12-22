using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Repository.Modules.Seyehat
{
    public class VeriKaynagiRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public VeriKaynagiRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public VeriKaynagi VeriKaynagiGetir(int id)
        {
            return _unitOfWork.VeriKaynagi.GetById(id);
        }

        public IQueryable<VeriKaynagi> VeriKaynaklariniListele()
        {
            return _unitOfWork.VeriKaynagi.GetAll();
        }


        public void VeriKaynagiEkle(VeriKaynagi VeriKaynagi)
        {
            _unitOfWork.VeriKaynagi.Insert(VeriKaynagi);
            _unitOfWork.Save();
        }

        public void VeriKaynagiGuncelle(VeriKaynagi VeriKaynagi)
        {
            var guncelleVeriKaynagi = _unitOfWork.VeriKaynagi.GetById(VeriKaynagi.Id);

            if (guncelleVeriKaynagi == null) return;

            guncelleVeriKaynagi.Tanim = VeriKaynagi.Tanim;

            guncelleVeriKaynagi.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleVeriKaynagi.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void VeriKaynagiSil(VeriKaynagi VeriKaynagi, bool fizikselSil = false)
        {
            var kayitliVeriKaynagi = _unitOfWork.VeriKaynagi.GetById(VeriKaynagi.Id);
            _unitOfWork.VeriKaynagi.Delete(kayitliVeriKaynagi, fizikselSil);
            _unitOfWork.Save();
        }
        #endregion
    }
}
