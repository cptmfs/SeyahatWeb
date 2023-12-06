using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IBlogKategoriView
    {

        #region Guncelleme

        Int32 SecilenBlogKategoriId { get; }

        String Ad { get; }



        #endregion

        #region Listeleme

        List<BlogKategoriDTO> BlogKategoriListe { set; }


        #endregion
    }
}
