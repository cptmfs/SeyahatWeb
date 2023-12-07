using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IGaleriKategoriView
    {
        #region Guncelleme

        Int32 SecilenGaleriKategoriId { get; }

        String Adi { get; }



        #endregion

        #region Listeleme

        List<GaleriKategoriDTO> GaleriKategoriListe { set; }


        #endregion
    }
}
