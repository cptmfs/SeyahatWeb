using DTO.Modules.Seyehat;
using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuView
    {
        #region Guncelleme
        Int32 SecilenEgitimDetayFormuId { get; }
        Int32 SecilenEgitimDetayFormuGuncellemeId { get; }
        String Aciklama { get; }

        Int32 MerkezArama { get; }
     
        String LblMerkez { set; }
        Int32 Tur { get; }
        #endregion

        #region Listeleme
        List<EgitimDetayFormuDTO> EgitimDetayFormuListesi { set; }
        #endregion
    }
}
