using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface ITurPaketView
    {
        #region Arama

        String TurPaketAra { get; }


        #endregion

        #region Guncelleme

        Int32 SecilenTurPaketId { get; }

        String Adi { get; }
        String Fiyat { get; }
        String Sure { get; }
        String Lokasyon { get; }
        String Resim { get; }
        String Detay { get; }



        #endregion

        #region Listeleme

        List<TurPaketDTO> TurPaketListe { set; }


        #endregion
    }
}
