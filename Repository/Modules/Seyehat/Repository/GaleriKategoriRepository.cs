using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modules.Seyehat.Repository
{
    public class GaleriKategoriRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public GaleriKategoriRepository()
        {
            if (_unitOfWork == null) return;
            //_unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblGaleriKategori GaleriKategoriBilgiGetir(int id)
        {
            return _unitOfWork.tblGaleriKategori.GetById(id);
        }

        public IQueryable<tblGaleriKategori> GaleriKategoriBilgiListele()
        {
            return _unitOfWork.tblGaleriKategori.GetAll()
                .OrderByDescending(x => x.Id);
        }



        public void GaleriKategoriBilgiEkle(tblGaleriKategori galeriKategori)
        {
            _unitOfWork.tblGaleriKategori.Insert(galeriKategori);
            _unitOfWork.Save();
        }

        public void GaleriKategoriBilgiGuncelle(tblGaleriKategori galeriKategori)
        {
            var guncelleGaleriKategori = _unitOfWork.tblGaleriKategori.GetById(galeriKategori.Id);

            if (guncelleGaleriKategori == null) return;

            guncelleGaleriKategori.Adi = galeriKategori.Adi;          

            guncelleGaleriKategori.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleGaleriKategori.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void GaleriKategoriSil(tblGaleriKategori galeriKategori, bool fizikselSil = false)
        {
            var silinecekGaleriKaydi = _unitOfWork.tblGaleriKategori.GetById(galeriKategori.Id);
            _unitOfWork.tblGaleriKategori.Delete(silinecekGaleriKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
