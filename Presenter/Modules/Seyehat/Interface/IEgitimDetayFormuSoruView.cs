using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuSoruView
    {
        #region Arama
        Int32? AramaSoruTuru { get; }
        #endregion

        #region Guncelleme
        Int32 SecilenEgitimDetayFormuSoruId { get; }
        String Tanim { get; }
        Int32? EgitimDetayFormuSoruBaslikId { get; }
        Int32? CevapTuru { get; }
        Int32? TxtSatirSayisi { get; }
        Int32? Sira { get; }
        #endregion

        #region Listeleme
        List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListesi { set; }
        List<EgitimDetayFormuSoruBaslikDTO> EgitimDetayFormuSoruBaslikListesi { set; }
        #endregion
    }
}
