using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Interface
{
    public interface IEgitimDetayFormuDetayView
    {
        #region Guncelleme
        Int32 SecilenEgitimDetayFormuId { get; }
        String LblMerkez { set; }
        String LblOlusturulmaTarihi { set; }
        String LblOlusturanKullanici { set; }

        #endregion
    }
}
