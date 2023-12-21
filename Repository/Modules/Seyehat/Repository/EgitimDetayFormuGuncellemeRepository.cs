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
    public class EgitimDetayFormuGuncellemeRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EgitimDetayFormuGuncellemeRepository()
        {
            if (_unitOfWork == null)
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public EgitimDetayFormuGuncelleme EgitimDetayFormuGuncellemeGetir(int id)
        {
            return _unitOfWork.EgitimDetayFormuGuncelleme.GetById(id);
        }

        public IQueryable<EgitimDetayFormuGuncelleme> EgitimDetayFormuGuncellemeListele()
        {
            return _unitOfWork.EgitimDetayFormuGuncelleme.GetAll()
                .OrderByDescending(olayBilgiFormuGuncelleme => olayBilgiFormuGuncelleme.Id);
        }

        public IQueryable<EgitimDetayFormuGuncelleme> EgitimDetayFormuGuncellemeListeleByForm(int formId)
        {
            return _unitOfWork.EgitimDetayFormuGuncelleme.GetAll().Where(b => b.EgitimDetayFormuId == formId)
                .OrderByDescending(olayBilgiFormuGuncelleme => olayBilgiFormuGuncelleme.Id);
        }


        public void EgitimDetayFormuGuncellemeEkle(EgitimDetayFormuGuncelleme olayBilgiFormuGuncelleme)
        {
            _unitOfWork.EgitimDetayFormuGuncelleme.Insert(olayBilgiFormuGuncelleme);
            _unitOfWork.Save();
        }
        public void EgitimDetayFormuGuncellemeGuncelleme(EgitimDetayFormuGuncelleme olayBilgiFormuGuncelleme)
        {
            var guncelleEgitimDetayFormuGuncelleme = _unitOfWork.EgitimDetayFormuGuncelleme.GetById(olayBilgiFormuGuncelleme.Id);

            if (guncelleEgitimDetayFormuGuncelleme == null) return;

            guncelleEgitimDetayFormuGuncelleme.Aciklama = olayBilgiFormuGuncelleme.Aciklama;

            guncelleEgitimDetayFormuGuncelleme.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleEgitimDetayFormuGuncelleme.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void EgitimDetayFormuGuncellemeSil(EgitimDetayFormuGuncelleme olayBilgiFormuGuncelleme, bool fizikselSil = false)
        {
            var kayitliEgitimDetayFormuGuncelleme = _unitOfWork.EgitimDetayFormuGuncelleme.GetById(olayBilgiFormuGuncelleme.Id);
            _unitOfWork.EgitimDetayFormuGuncelleme.Delete(kayitliEgitimDetayFormuGuncelleme, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
