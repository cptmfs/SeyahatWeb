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
    public class EgitimDetayFormuRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormu EgitimDetayFormuGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormu.GetById(id);
        }

        public IQueryable<EgitimDetayFormu> EgitimDetayFormuListele()
        {
            return _unitOfWork.EgitimDetayFormu.GetAll()
                .OrderByDescending(olayBilgiFormu => olayBilgiFormu.Id);
        }
        public int EgitimDetayFormuEkle(EgitimDetayFormu olayBilgiFormu)
        {
            _unitOfWork.EgitimDetayFormu.Insert(olayBilgiFormu);
            _unitOfWork.Save();
            return olayBilgiFormu.Id;
        }

        public void EgitimDetayFormuSil(EgitimDetayFormu olayBilgiFormu, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormu = _unitOfWork.EgitimDetayFormu.GetById(olayBilgiFormu.Id);
            _unitOfWork.EgitimDetayFormu.Delete(kayitliEgitimDetayFormu, fizikselSil);
            _unitOfWork.Save();
        }
        public void EgitimDetayFormuAc(EgitimDetayFormu olayBilgiFormu)
        {
            var guncelleEgitimDetayFormu = _unitOfWork.EgitimDetayFormu.GetById(olayBilgiFormu.Id);

            if (guncelleEgitimDetayFormu == null) return;

            guncelleEgitimDetayFormu.Aktif = olayBilgiFormu.Aktif;
            guncelleEgitimDetayFormu.AcmaTarihi = olayBilgiFormu.AcmaTarihi;
            guncelleEgitimDetayFormu.AcanKullaniciId = olayBilgiFormu.AcanKullaniciId;

            guncelleEgitimDetayFormu.GuncelleyenKullanici = SessionHelper.KullaniciId;
            
            guncelleEgitimDetayFormu.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }
        public void EgitimDetayFormuKapat(EgitimDetayFormu olayBilgiFormu)
        {
            var guncelleEgitimDetayFormu = _unitOfWork.EgitimDetayFormu.GetById(olayBilgiFormu.Id);

            if (guncelleEgitimDetayFormu == null) return;

            guncelleEgitimDetayFormu.Aktif = olayBilgiFormu.Aktif;
            guncelleEgitimDetayFormu.KapatmaTarihi = olayBilgiFormu.KapatmaTarihi;
            guncelleEgitimDetayFormu.KapatanKullaniciId = olayBilgiFormu.KapatanKullaniciId;

            guncelleEgitimDetayFormu.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormu.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }
        #endregion
    }
}
