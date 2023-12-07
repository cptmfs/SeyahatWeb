using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modules.SeyehatWeb.Repository
{
    public class KurumsalRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public KurumsalRepository()
        {
            if (_unitOfWork == null) return;
                //_unitOfWork = ContainerHelper.Container.Resolve<ISeyehatWebUnitOfWork>();
        }

        #endregion

        #region Methods

        public tabloKurumsal KurumsalBilgiGetir(int id)
        {
            return _unitOfWork.tabloKurumsal.GetById(id);
        }

        public IQueryable<tabloKurumsal> KurumsalBilgiListele()
        {
            return _unitOfWork.tabloKurumsal.GetAll()
                .OrderByDescending(x => x.Id);
        }



        public void KurumsalBilgiEkle(tabloKurumsal kurumsal)
        {
            _unitOfWork.tabloKurumsal.Insert(kurumsal);
            _unitOfWork.Save();
        }

        public void KurumsalBilgiGuncelle(tabloKurumsal kurumsal)
        {
            var guncelleKurumsal= _unitOfWork.tabloKurumsal.GetById(kurumsal.Id);

            if (guncelleKurumsal == null) return;

            guncelleKurumsal.Baslik = kurumsal.Baslik;
            guncelleKurumsal.Ozet= kurumsal.Ozet;
            guncelleKurumsal.Detay=kurumsal.Detay;


            guncelleKurumsal.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleKurumsal.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void KurumsalSil(tabloKurumsal kurumsal, bool fizikselSil = false)
        {
            var silenecekKurumsalKaydi = _unitOfWork.tabloKurumsal.GetById(kurumsal.Id);
            _unitOfWork.tabloKurumsal.Delete(silenecekKurumsalKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
