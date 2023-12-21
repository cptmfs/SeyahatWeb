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
    public class EgitimDetayFormuSoruSecenekleriRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuSoruSecenekleriRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruSecenekleri EgitimDetayFormuSoruSecenekleriGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetById(id);
        }

        public IQueryable<EgitimDetayFormuSoruSecenekleri> EgitimDetayFormuSoruSecenekleriListele()
        {
            return _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetAll()
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoruSecenekleri> EgitimDetayFormuSoruSecenekleriListele(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Id == id)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoruSecenekleri> EgitimDetayFormuSoruSecenekleriListeleBySoru(int soruId)
        {
            return _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.EgitimDetayFormuSoruId == soruId)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public void EgitimDetayFormuSoruSecenekleriEkle(EgitimDetayFormuSoruSecenekleri olayBilgiFormuSoru)
        {
            _unitOfWork.EgitimDetayFormuSoruSecenekleri.Insert(olayBilgiFormuSoru);
            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruSecenekleriGuncelle(EgitimDetayFormuSoruSecenekleri olayBilgiFormuSoru)
        {
            var guncelleEgitimDetayFormuSoruSecenekleri = _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetById(olayBilgiFormuSoru.Id);

            if (guncelleEgitimDetayFormuSoruSecenekleri == null) return;

            guncelleEgitimDetayFormuSoruSecenekleri.Tanim = olayBilgiFormuSoru.Tanim;
            guncelleEgitimDetayFormuSoruSecenekleri.Sira = olayBilgiFormuSoru.Sira;
            guncelleEgitimDetayFormuSoruSecenekleri.EgitimDetayFormuSoruId = olayBilgiFormuSoru.EgitimDetayFormuSoruId;

            guncelleEgitimDetayFormuSoruSecenekleri.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormuSoruSecenekleri.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruSecenekleriSil(EgitimDetayFormuSoruSecenekleri olayBilgiFormuSoru, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuSoruSecenekleri = _unitOfWork.EgitimDetayFormuSoruSecenekleri.GetById(olayBilgiFormuSoru.Id);
            _unitOfWork.EgitimDetayFormuSoruSecenekleri.Delete(kayitliEgitimDetayFormuSoruSecenekleri, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
