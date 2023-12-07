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
    public class BlogRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public BlogRepository()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();

            }
        }

        #endregion

        #region Methods

        public tblBlog BlogBilgiGetir(int id)
        {
            return _unitOfWork.tblBlog.GetById(id);
        }

        public IQueryable<tblBlog> BlogBilgiListele()
        {
            return _unitOfWork.tblBlog.GetAll()
                .OrderByDescending(x => x.Id);
        }

        public IQueryable<tblBlog> BlogFiltreleByBaslik()
        {
            return _unitOfWork.tblBlog.GetAll()
               .OrderByDescending(x => x.Baslik);
        }

        public void BlogBilgiEkle(tblBlog blog)
        {
            _unitOfWork.tblBlog.Insert(blog);
            _unitOfWork.Save();
        }

        public void BlogBilgiGuncelle(tblBlog blog)
        {
            var guncelleBlog = _unitOfWork.tblBlog.GetById(blog.Id);

            if (guncelleBlog == null) return;

            guncelleBlog.Baslik = blog.Baslik;
            guncelleBlog.Ozet = blog.Ozet;
            guncelleBlog.KategoriId = blog.KategoriId;
            guncelleBlog.Resim = blog.Resim;
            guncelleBlog.Detay = blog.Detay;
            guncelleBlog.Tarih = blog.Tarih;

            guncelleBlog.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleBlog.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void BlogSil(tblBlog blog, bool fizikselSil = false)
        {
            var silinecekBlogKaydi = _unitOfWork.tblBlog.GetById(blog.Id);
            _unitOfWork.tblBlog.Delete(silinecekBlogKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
