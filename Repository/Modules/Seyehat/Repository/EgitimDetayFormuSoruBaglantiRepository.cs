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
    public class EgitimDetayFormuSoruBaglantiRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuSoruBaglantiRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruBaglanti EgitimDetayFormuSoruBaglantiGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaglanti.GetById(id);
        }

        public IQueryable<EgitimDetayFormuSoruBaglanti> EgitimDetayFormuSoruBaglantiListele()
        {
            return _unitOfWork.EgitimDetayFormuSoruBaglanti.GetAll()
                .OrderByDescending(olayBilgiFormuSoru => olayBilgiFormuSoru.Id);
        }
        public IQueryable<EgitimDetayFormuSoruBaglanti> EgitimDetayFormuSoruBaglantiListele(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaglanti.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Id == id)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Id);
        }
        public IQueryable<EgitimDetayFormuSoruBaglanti> EgitimDetayFormuSoruBaglantiListeleByTur(int tur, bool aktif)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaglanti.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Tur == tur && olayBilgiFormuSoru.Aktif == aktif)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslik.Sira).ThenBy(olayBilgiFormuSoru => olayBilgiFormuSoru.EgitimDetayFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoruBaglanti> EgitimDetayFormuSoruBaglantiListeleByTur(int tur)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaglanti.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Tur == tur)
                 .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.EgitimDetayFormuSoru.EgitimDetayFormuSoruBaslik.Sira).ThenBy(olayBilgiFormuSoru => olayBilgiFormuSoru.EgitimDetayFormuSoru.Sira);
        }
        public void EgitimDetayFormuSoruBaglantiEkle(EgitimDetayFormuSoruBaglanti olayBilgiFormuSoru)
        {
            _unitOfWork.EgitimDetayFormuSoruBaglanti.Insert(olayBilgiFormuSoru);
            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruBaglantiGuncelle(EgitimDetayFormuSoruBaglanti olayBilgiFormuSoru)
        {
            var guncelleEgitimDetayFormuSoruBaglanti = _unitOfWork.EgitimDetayFormuSoruBaglanti.GetById(olayBilgiFormuSoru.Id);

            if (guncelleEgitimDetayFormuSoruBaglanti == null) return;


            guncelleEgitimDetayFormuSoruBaglanti.Aktif = olayBilgiFormuSoru.Aktif;

            guncelleEgitimDetayFormuSoruBaglanti.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormuSoruBaglanti.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruBaglantiSil(EgitimDetayFormuSoruBaglanti olayBilgiFormuSoru, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuSoruBaglanti = _unitOfWork.EgitimDetayFormuSoruBaglanti.GetById(olayBilgiFormuSoru.Id);
            _unitOfWork.EgitimDetayFormuSoruBaglanti.Delete(kayitliEgitimDetayFormuSoruBaglanti, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
