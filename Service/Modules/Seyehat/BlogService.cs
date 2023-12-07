using DTO.Modules.SeyehatWeb;
using Entity.Seyehat;
using Repository.Modules.SeyehatWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.SeyehatWeb
{
    public class BlogService
    {
        #region Repository

        private BlogRepository _blogRepository;

        protected BlogRepository BlogRepository
        {
            get { return _blogRepository ?? (_blogRepository = new BlogRepository()); }
        }



        #endregion

        #region Methods

        public BlogDTO BlogGetir(int blogId)
        {
            if (blogId <= 0) return null;

            var blog = BlogRepository.BlogBilgiGetir(blogId);

            return blog == null ? null : new BlogDTO
            {
                Id = blog.Id,
                Baslik=blog.Baslik,
                Ozet=blog.Ozet,
                KategoriId=blog.KategoriId,
                KategoriAciklama= blog.tblBlogKategori.Ad,
                Resim= blog.Resim,
                Detay= blog.Detay,
                Tarih = blog.Tarih
               
            };

        }

        public List<BlogDTO> BlogListele()
        {
            var blogListesi = BlogRepository.BlogBilgiListele()
                .Select(blog => new BlogDTO
                {
                    Id = blog.Id,
                    Baslik = blog.Baslik,
                    Ozet = blog.Ozet,
                    KategoriId = blog.KategoriId,
                    KategoriAciklama = blog.tblBlogKategori.Ad,
                    Resim = blog.Resim,
                    Detay = blog.Detay,
                    Tarih = blog.Tarih


                })
                .OrderBy(blog => blog.Id)
                .ToList();

            return blogListesi;
        }
        // Aktif Ekle
        public IQueryable<BlogDTO> BlogFiltrele(string baslik)
        {
            var blogList = BlogRepository.BlogFiltreleByBaslik();


            if (!blogList.Any()) return null;

            return blogList.OrderBy(x => x.Baslik== baslik)
                           .Select(blog => new BlogDTO
                           {
                               Id = blog.Id,
                               Baslik = blog.Baslik,
                               Ozet = blog.Ozet,
                               KategoriId = blog.KategoriId,
                               KategoriAciklama = blog.tblBlogKategori.Ad,
                               Resim = blog.Resim,
                               Detay = blog.Detay,
                               Tarih = blog.Tarih
                           });
        }

        public Tuple<bool, string> BlogEkle(BlogDTO blog)
        {
            if (blog == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniBlog = new tblBlog
            {
                Id = blog.Id,
                Baslik = blog.Baslik,
                Ozet = blog.Ozet,
                KategoriId = blog.KategoriId,
                Resim = blog.Resim,
                Detay = blog.Detay,
                Tarih = blog.Tarih
            };

            try
            {
                BlogRepository.BlogBilgiEkle(yeniBlog);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> BlogGuncelle(BlogDTO blog)
        {
            if (blog == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleBlog = new tblBlog
            {
                Id = blog.Id,
                Baslik = blog.Baslik,
                Ozet = blog.Ozet,
                KategoriId = blog.KategoriId,
                Resim = blog.Resim,
                Detay = blog.Detay,
                Tarih = blog.Tarih
            };

            try
            {
                BlogRepository.BlogBilgiGuncelle(guncelleBlog);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> BlogSil(int blogId)
        {
            if (blogId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var blog = new tblBlog { Id = blogId };
                BlogRepository.BlogSil(blog);
                return new Tuple<bool, string>(true, "Silme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Silme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        #endregion
    }
}
