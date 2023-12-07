using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IKurumsalView
    {
        #region Arama

        String KurumsalAra { get; }


        #endregion

        #region Guncelleme

        Int32 SecilenKurumsalBilgiId { get; }

        String Baslik { get; }

        String Ozet { get; }

        String Detay{ get; }


        #endregion

        #region Listeleme

        List<KurumsalDTO> KurumsalListe { set; }


        #endregion
    }
}
