using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimTuruView
    {
        #region Arama

        String TanimAra { get; }

        #endregion

        #region Guncelleme

        Int32 SecilenEgitimTuruId { get; }

        String Tanim { get; }

        #endregion

        #region Listeleme

        List<EgitimTuruDTO> EgitimTuruListesi { set; }

        #endregion
    }
}
