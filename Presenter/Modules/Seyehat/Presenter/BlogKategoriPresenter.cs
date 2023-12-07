using DTO.Modules.SeyehatWeb;
using Presenter.Modules.SeyehatWeb.Interface;
using Service.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Presenter
{
    public class BlogKategoriPresenter
    {
        #region Constructor & View

        protected IBlogKategoriView View { get; private set; }

        public BlogKategoriPresenter(IBlogKategoriView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private BlogKategoriService _blogKategori;

        protected BlogKategoriService BlogKategoriService
        {
            get { return _blogKategori ?? (_blogKategori = new BlogKategoriService()); }
        }


        #endregion

        #region Methods

        public void BlogKategoriiListele()
        {
            View.BlogKategoriListe = BlogKategoriService.BlogKategoriListele();
        }



        public void AramaSonuclariniListele(string ad)
        {
            var blogKategoriListe = BlogKategoriService.BlogKategoriFiltrele(ad);


            View.BlogKategoriListe = blogKategoriListe.ToList();
        }

        public Tuple<bool, string> BlogKategoriEkle()
        {
            var blogKategori = new BlogKategoriDTO
            {
               Ad=View.Ad,

            };
            return BlogKategoriService.BlogKategoriEkle(blogKategori);
        }

        public Tuple<bool, string> BlogKategoriGuncelle()
        {
            var blogKategori = new BlogKategoriDTO
            {
                Id = View.SecilenBlogKategoriId,
                Ad = View.Ad
            };
            return BlogKategoriService.BlogKategoriGuncelle(blogKategori);
        }

        public Tuple<bool, string> BlogKategoriKayitSil()
        {
            return BlogKategoriService.BlogSil(View.SecilenBlogKategoriId);
        }

        // AJAX işlemleri için
        public BlogKategoriDTO BlogKategoriGetir(int id)
        {
            var blogKategori = BlogKategoriService.BlogKategoriGetir(id);
            return blogKategori;
        }

        #endregion
    }
}
