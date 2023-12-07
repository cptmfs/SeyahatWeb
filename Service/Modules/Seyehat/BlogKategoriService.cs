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
    public class BlogKategoriService
    {
        #region Repository

        private BlogKategoriRepository _blogKategoriRepository;

        protected BlogKategoriRepository BlogKategoriRepository
        {
            get { return _blogKategoriRepository ?? (_blogKategoriRepository = new BlogKategoriRepository()); }
        }



        #endregion

        #region Methods

        public BlogKategoriDTO BlogKategoriGetir(int blogKategoriId)
        {
            if (blogKategoriId <= 0) return null;

            var blogKategori = BlogKategoriRepository.BlogKategoriBilgiGetir(blogKategoriId);

            return blogKategori == null ? null : new BlogKategoriDTO
            {
                Id = blogKategori.Id,
                Ad = blogKategori.Ad

            };

        }

        public List<BlogKategoriDTO> BlogKategoriListele()
        {
            var blogKategoriListesi = BlogKategoriRepository.BlogKategoriBilgiListele()
                .Select(blogKategori => new BlogKategoriDTO
                {
                    Id = blogKategori.Id,
                    Ad = blogKategori.Ad



                })
                .OrderBy(blogKategori => blogKategori.Id)
                .ToList();

            return blogKategoriListesi;
        }
        // Aktif Ekle
        public IQueryable<BlogKategoriDTO> BlogKategoriFiltrele(string ad)
        {
            var blogKategoriList = BlogKategoriRepository.BlogKategoriFiltreleByAd();


            if (!blogKategoriList.Any()) return null;

            return blogKategoriList.OrderBy(x => x.Ad==ad)
                           .Select(blogKategori => new BlogKategoriDTO
                           {
                               Id = blogKategori.Id,
                               Ad = blogKategori.Ad

                           });
        }

        public Tuple<bool, string> BlogKategoriEkle(BlogKategoriDTO blogKategori)
        {
            if (blogKategori == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var yeniBlogKategori = new tblBlogKategori
            {
                Id = blogKategori.Id,
                Ad = blogKategori.Ad

            };

            try
            {
                BlogKategoriRepository.BlogKategoriBilgiEkle(yeniBlogKategori);
                return new Tuple<bool, string>(true, "Kayıt işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Kayıt işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> BlogKategoriGuncelle(BlogKategoriDTO blogKategori)
        {
            if (blogKategori == null)
                return new Tuple<bool, string>(false, "Parametre null değer içeriyor.");

            var guncelleBlog = new tblBlogKategori
            {
                Id = blogKategori.Id,
                Ad = blogKategori.Ad

            };

            try
            {
                BlogKategoriRepository.BlogKategoriBilgiGuncelle(guncelleBlog);
                return new Tuple<bool, string>(true, "Güncelleme işlemi başarıyla gerçekleştirilmiştir.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, String.Format("Güncelleme işlemi sırasında bir hata meydana geldi: ({0})", ex.Message));
            }
        }

        public Tuple<bool, string> BlogSil(int blogKategoriId)
        {
            if (blogKategoriId <= 0)
                return new Tuple<bool, string>(false, "Parametre geçersiz.");

            try
            {
                var blogKategori = new tblBlogKategori { Id = blogKategoriId };
                BlogKategoriRepository.BlogKategoriSil(blogKategori);
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
