using DTO.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuSoruSecenekleriView
    {
        #region Arama
        Int32? AramaSoruTanim { get; }
        #endregion

        #region Guncelleme
        Int32 SecilenEgitimDetayFormuSoruSecenekleriId { get; }
        String Tanim { get; }
        Int32? EgitimDetayFormuSoruId { get; }
        Int32? Sira { get; }
        #endregion

        #region Listeleme
        List<EgitimDetayFormuSoruSecenekleriDTO> EgitimDetayFormuSoruSecenekleriListesi { set; }
        List<EgitimDetayFormuSoruDTO> EgitimDetayFormuSoruListesi { set; }
        #endregion
    }
}
