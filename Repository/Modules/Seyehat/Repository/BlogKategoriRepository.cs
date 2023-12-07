using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Repository.Modules.SeyehatWeb.Repository
{
    public class BlogKategoriRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public BlogKategoriRepository()
        {
            if (_unitOfWork == null)
            _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblBlogKategori BlogKategoriBilgiGetir(int id)
        {
            return _unitOfWork.tblBlogKategori.GetById(id);
        }

        public IQueryable<tblBlogKategori> BlogKategoriBilgiListele()
        {
            return _unitOfWork.tblBlogKategori.GetAll()
                .OrderByDescending(x => x.Id);
        }

        public IQueryable<tblBlogKategori> BlogKategoriFiltreleByAd()
        {
            return _unitOfWork.tblBlogKategori.GetAll()
               .OrderByDescending(x => x.Ad);
        }

        public void BlogKategoriBilgiEkle(tblBlogKategori blogKategori)
        {
            _unitOfWork.tblBlogKategori.Insert(blogKategori);
            _unitOfWork.Save();
        }

        public void BlogKategoriBilgiGuncelle(tblBlogKategori blogKategori)
        {
            var guncelleBlogKategori = _unitOfWork.tblBlogKategori.GetById(blogKategori.Id);

            if (guncelleBlogKategori == null) return;

            guncelleBlogKategori.Ad = blogKategori.Ad;
         
            guncelleBlogKategori.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleBlogKategori.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void BlogKategoriSil(tblBlogKategori blogKategori, bool fizikselSil = false)
        {
            var silinecekBlogKategoriKaydi = _unitOfWork.tblBlogKategori.GetById(blogKategori.Id);
            _unitOfWork.tblBlogKategori.Delete(silinecekBlogKategoriKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
