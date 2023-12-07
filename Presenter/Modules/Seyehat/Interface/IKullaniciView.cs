using DTO.Modules.SeyehatWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.SeyehatWeb.Interface
{
    public interface IKullaniciView
    {
        #region Arama

        String KullaniciAra { get; }


        #endregion

        #region Guncelleme

        Int32 SecilenKullaniciId { get; }

        String UserName { get; }

        String Password { get; }

        String Name { get; }
        String Surname { get; }
        String EMail { get; }


        #endregion

        #region Listeleme

        List<KullaniciDTO> KullaniciListe{ set; }


        #endregion
    }
}
