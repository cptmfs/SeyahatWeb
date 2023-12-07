using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IGaleriView
    {
        #region Arama

        String GaleriAra { get; }


        #endregion

        #region Guncelleme

        Int32 SecilenGaleriId { get; }

        String Baslik { get; }

        int? KategoriId { get; }
        String Resim { get; }



        #endregion

        #region Listeleme

        List<GaleriDTO> GaleriListe { set; }


        #endregion
    }
}
