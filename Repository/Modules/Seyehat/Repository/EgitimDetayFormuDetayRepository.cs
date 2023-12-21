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
    public class EgitimDetayFormuDetayRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuDetayRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuDetay EgitimDetayFormuDetayGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetById(id);
        }

        public IQueryable<EgitimDetayFormuDetay> EgitimDetayFormuDetayListele()
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetAll()
                .OrderBy(olayBilgiFormuDetay => olayBilgiFormuDetay.Id);
        }

        public IQueryable<EgitimDetayFormuDetay> EgitimDetayFormuDetayListeleByForm(int formId)
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetAll().Where(b => b.EgitimDetayFormuId == formId)
                .OrderBy(olayBilgiFormuDetay => olayBilgiFormuDetay.Id);
        }
        public EgitimDetayFormuDetay EgitimDetayFormuDetayGetirForVeriKaynagi(int formId)
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetAll().Any(b => b.EgitimDetayFormuId == formId && b.EgitimDetayFormuSoruBaglanti.EDFSoruId == 2) ?
                _unitOfWork.EgitimDetayFormuDetay.GetAll().Where(b => b.EgitimDetayFormuId == formId && b.EgitimDetayFormuSoruBaglanti.EDFSoruId == 2).FirstOrDefault() :
                null;
        }
        public EgitimDetayFormuDetay EgitimDetayFormuDetayGetirForSiniflanmisOlay(int formId)
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetAll().Any(b => b.EgitimDetayFormuId == formId && b.EgitimDetayFormuSoruBaglanti.EDFSoruId == 1) ?
                _unitOfWork.EgitimDetayFormuDetay.GetAll().Where(b => b.EgitimDetayFormuId == formId && b.EgitimDetayFormuSoruBaglanti.EDFSoruId == 1).FirstOrDefault() :
                null;
        }
        public bool KayitVarMi(int formId, int soruId)
        {
            return _unitOfWork.EgitimDetayFormuDetay.GetAll().Where(b => b.EgitimDetayFormuId == formId && b.EgitimDetayFormuSoruBaglantiId == soruId).Any();

        }
        public void EgitimDetayFormuDetayEkle(EgitimDetayFormuDetay olayBilgiFormuDetay)
        {
            _unitOfWork.EgitimDetayFormuDetay.Insert(olayBilgiFormuDetay);
            _unitOfWork.Save();
        }
        public void EgitimDetayFormuDetayGuncelle(EgitimDetayFormuDetay olayBilgiFormuDetay)
        {
            var guncelleEgitimDetayFormuDetay = _unitOfWork.EgitimDetayFormuDetay.GetById(olayBilgiFormuDetay.Id);

            if (guncelleEgitimDetayFormuDetay == null) return;

            guncelleEgitimDetayFormuDetay.Cevap = olayBilgiFormuDetay.Cevap;

            guncelleEgitimDetayFormuDetay.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormuDetay.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuDetaySil(EgitimDetayFormuDetay olayBilgiFormuDetay, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuDetay = _unitOfWork.EgitimDetayFormuDetay.GetById(olayBilgiFormuDetay.Id);
            _unitOfWork.EgitimDetayFormuDetay.Delete(kayitliEgitimDetayFormuDetay, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
