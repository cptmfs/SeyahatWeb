using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using static System.Enum;
namespace Infrastructure.Helper
{


    public static class MesajHelper
    {
        public static void PopupMesajGoster(Page page, PopupMesajTipleri mesajTipi, string baslik, string mesaj, bool modulesFolder = true, bool requireRefresh = true, string redirectPath = "")
        {
            string html = HtmlHelper.HtmlMesajOlustur(mesajTipi, baslik, mesaj, modulesFolder, requireRefresh, redirectPath);
            HtmlHelper.HtmlEkle(page, html);

            // #messageModalAnchor isimli elementin sayfaya eklenmesi için yukarıdaki kodların çalıştırılması gerekiyor.

            page.ClientScript.RegisterStartupScript(page.GetType(), "PopupMessage", @"
        function OpenMessage() {
            var myModal = new bootstrap.Modal(document.getElementById('messageModalDiv'), {});

            myModal.show();
        }

        OpenMessage();", true);
        }


    }
}
