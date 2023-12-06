using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
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



        #endregion

        #region Listeleme

        List<BlogDTO> BlogListe { set; }


        #endregion
    }
}
