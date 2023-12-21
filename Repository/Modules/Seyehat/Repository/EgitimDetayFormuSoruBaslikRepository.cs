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
    public class EgitimDetayFormuSoruBaslikRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuSoruBaslikRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoruBaslik EgitimDetayFormuSoruBaslikGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaslik.GetById(id);
        }

        public IQueryable<EgitimDetayFormuSoruBaslik> EgitimDetayFormuSoruBaslikListele()
        {
            return _unitOfWork.EgitimDetayFormuSoruBaslik.GetAll()
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoruBaslik> EgitimDetayFormuSoruBaslikListele(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoruBaslik.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Id == id)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public void EgitimDetayFormuSoruBaslikEkle(EgitimDetayFormuSoruBaslik olayBilgiFormuSoru)
        {
            _unitOfWork.EgitimDetayFormuSoruBaslik.Insert(olayBilgiFormuSoru);
            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruBaslikGuncelle(EgitimDetayFormuSoruBaslik olayBilgiFormuSoru)
        {
            var guncelleEgitimDetayFormuSoruBaslik = _unitOfWork.EgitimDetayFormuSoruBaslik.GetById(olayBilgiFormuSoru.Id);

            if (guncelleEgitimDetayFormuSoruBaslik == null) return;

            guncelleEgitimDetayFormuSoruBaslik.Tanim = olayBilgiFormuSoru.Tanim;
            guncelleEgitimDetayFormuSoruBaslik.Sira = olayBilgiFormuSoru.Sira;

            guncelleEgitimDetayFormuSoruBaslik.GuncelleyenKullanici = SessionHelper.KullaniciId;
            
            guncelleEgitimDetayFormuSoruBaslik.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruBaslikSil(EgitimDetayFormuSoruBaslik olayBilgiFormuSoru, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuSoruBaslik = _unitOfWork.EgitimDetayFormuSoruBaslik.GetById(olayBilgiFormuSoru.Id);
            _unitOfWork.EgitimDetayFormuSoruBaslik.Delete(kayitliEgitimDetayFormuSoruBaslik, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
