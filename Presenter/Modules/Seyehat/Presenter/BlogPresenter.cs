using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Service.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Presenter
{
    public class BlogPresenter
    {
        #region Constructor & View

        protected IBlogView View { get; private set; }

        public BlogPresenter(IBlogView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private BlogService _bloglarService;

        protected BlogService BlogService
        {
            get { return _bloglarService ?? (_bloglarService = new BlogService()); }
        }


        #endregion

        #region Methods

        public void BlogiListele()
        {
            View.BlogListe = BlogService.BlogListele();
        }



        public void AramaSonuclariniListele(string siteOzet)
        {
            var blogListe = BlogService.BlogFiltrele(siteOzet);


            View.BlogListe = blogListe.ToList();
        }

        public Tuple<bool, string> BlogEkle()
        {
            var blog = new BlogDTO
            {
                Baslik=View.Baslik,
                Detay=View.Detay,
                Ozet=View.Ozet,
                Resim = View.Resim,
                Tarih = View.Tarih,
                KategoriId = View.KategoriId,
                

            };
            return BlogService.BlogEkle(blog);
        }

        public Tuple<bool, string> BlogGuncelle()
        {
            var blog = new BlogDTO
            {
                Id = View.SecilenBlogId,
                Baslik = View.Baslik,
                Detay = View.Detay,
                Ozet = View.Ozet,
                Resim = View.Resim,
                Tarih = View.Tarih,
                KategoriId = View.KategoriId,


            };
            return BlogService.BlogGuncelle(blog);
        }

        public Tuple<bool, string> BlogKayitSil()
        {
            return BlogService.BlogSil(View.SecilenBlogId);
        }

        // AJAX işlemleri için
        public BlogDTO BlogGetir(int id)
        {
            var blog = BlogService.BlogGetir(id);
            return blog;
        }

        #endregion
    }
}
