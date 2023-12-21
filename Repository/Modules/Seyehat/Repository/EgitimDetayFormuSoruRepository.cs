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
    public class EgitimDetayFormuSoruRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuSoruRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuSoru EgitimDetayFormuSoruGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoru.GetById(id);
        }

        public IQueryable<EgitimDetayFormuSoru> EgitimDetayFormuSoruListele()
        {
            return _unitOfWork.EgitimDetayFormuSoru.GetAll()
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoru> EgitimDetayFormuSoruListele(int id)
        {
            return _unitOfWork.EgitimDetayFormuSoru.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.Id == id)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public IQueryable<EgitimDetayFormuSoru> EgitimDetayFormuDrpOlanSoruListele()
        {
            //cevap türü dropdown olan soruları listeler.
            return _unitOfWork.EgitimDetayFormuSoru.GetAll().Where(olayBilgiFormuSoru => olayBilgiFormuSoru.CevapTuru == 3)
                .OrderBy(olayBilgiFormuSoru => olayBilgiFormuSoru.Sira);
        }
        public void EgitimDetayFormuSoruEkle(EgitimDetayFormuSoru olayBilgiFormuSoru)
        {
            _unitOfWork.EgitimDetayFormuSoru.Insert(olayBilgiFormuSoru);
            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruGuncelle(EgitimDetayFormuSoru olayBilgiFormuSoru)
        {
            var guncelleEgitimDetayFormuSoru = _unitOfWork.EgitimDetayFormuSoru.GetById(olayBilgiFormuSoru.Id);

            if (guncelleEgitimDetayFormuSoru == null) return;

            guncelleEgitimDetayFormuSoru.Tanim = olayBilgiFormuSoru.Tanim;
            guncelleEgitimDetayFormuSoru.EgitimDetayFormuSoruBaslikId = olayBilgiFormuSoru.EgitimDetayFormuSoruBaslikId;
            guncelleEgitimDetayFormuSoru.CevapTuru = olayBilgiFormuSoru.CevapTuru;
            guncelleEgitimDetayFormuSoru.Sira = olayBilgiFormuSoru.Sira;
            guncelleEgitimDetayFormuSoru.TxtSatirSayisi = olayBilgiFormuSoru.TxtSatirSayisi;

            guncelleEgitimDetayFormuSoru.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormuSoru.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuSoruSil(EgitimDetayFormuSoru olayBilgiFormuSoru, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuSoru = _unitOfWork.EgitimDetayFormuSoru.GetById(olayBilgiFormuSoru.Id);
            _unitOfWork.EgitimDetayFormuSoru.Delete(kayitliEgitimDetayFormuSoru, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
