using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IAyarView
    {
        #region Arama

        String AyarAra { get; }

   
        #endregion

        #region Guncelleme

        Int32 SecilenAyarId { get; }

        String Mail { get; }

        String Telefon { get; }

        String Adres { get; }
        String Youtube { get; }
        String Facebook { get; }
        String Instagram { get; }
        String Logo { get; }
        String SiteOzet { get; }

       

        #endregion

        #region Listeleme

        List<AyarlarDTO> AyarListe { set; }


        #endregion
    }
}
