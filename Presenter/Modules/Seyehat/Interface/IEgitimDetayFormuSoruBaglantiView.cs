using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuSoruBaglantiView
    {
        #region Listeleme
        //List<EgitimDetayFormuSoruBaglantiDTO> EgitimDetayFormuSoruBaglantiListesi { set; }
        List<TanimDTO> TurListesi { set; }
        #endregion
    }
}
