using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuSoruBaslikView
    {
        #region Guncelleme
        Int32 SecilenEgitimDetayFormuSoruBaslikId { get; }
        String Tanim { get; }
        Int32? Sira { get; }
        #endregion
        
        #region Listeleme
        List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListesi {  set; }

        #endregion
    }
}
