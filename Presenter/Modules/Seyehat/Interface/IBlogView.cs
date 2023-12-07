using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IBlogView
    {
        #region Arama

        String BlogAra { get; }


        #endregion

        #region Guncelleme

        Int32 SecilenBlogId { get; }

        String Baslik { get; }

        String Ozet { get; }

        int? KategoriId{ get; }
        String Resim { get; }
        String Detay { get; }
        DateTime? Tarih { get; }

        BlogKategoriDTO BlogKategori { get; set; }

        #endregion

        #region Listeleme

        List<BlogDTO> BlogListe { set; }
        List<BlogKategoriDTO> KategoriListesi { set; }


        #endregion
    }
}
