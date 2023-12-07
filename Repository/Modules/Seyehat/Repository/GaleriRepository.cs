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
    public class GaleriRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public GaleriRepository()
        {
            if (_unitOfWork == null) return;
            //_unitOfWork = ContainerHelper.Container.Resolve<ISeyehatWebUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblGaleri GaleriBilgiGetir(int id)
        {
            return _unitOfWork.tblGaleri.GetById(id);
        }

        public IQueryable<tblGaleri> GaleriBilgiListele()
        {
            return _unitOfWork.tblGaleri.GetAll()
                .OrderByDescending(x => x.Id);
        }

        public IQueryable<tblGaleri> GaleriFiltreleByBaslik()
        {
            return _unitOfWork.tblGaleri.GetAll()
               .OrderByDescending(x => x.Baslik);
        }

        public void GaleriBilgiEkle(tblGaleri galeri)
        {
            _unitOfWork.tblGaleri.Insert(galeri);
            _unitOfWork.Save();
        }

        public void GaleriBilgiGuncelle(tblGaleri galeri)
        {
            var guncelleGaleri = _unitOfWork.tblGaleri.GetById(galeri.Id);

            if (guncelleGaleri == null) return;

            guncelleGaleri.Baslik = galeri.Baslik;
            guncelleGaleri.KategoriId = galeri.KategoriId;
            guncelleGaleri.Resim = galeri.Resim;

            guncelleGaleri.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleGaleri.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void GaleriSil(tblGaleri galeri, bool fizikselSil = false)
        {
            var silinecekGaleriKaydi = _unitOfWork.tblGaleri.GetById(galeri.Id);
            _unitOfWork.tblGaleri.Delete(silinecekGaleriKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
