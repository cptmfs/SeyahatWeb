using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Enum;
using Unity.Extension;
using System.Web.UI.WebControls;
using System.Web.UI;
using Infrastructure.Enum;
using Infrastructure.Extension;
namespace Infrastructure.Helper
{


    internal static class HtmlHelper
    {
        internal static string HtmlMesajOlustur(PopupMesajTipleri mesajTipi, string baslik, string mesaj, bool modulesFolder = false, bool requireRefresh = true, string redirectPath = "")
        {
            string iconPath = (modulesFolder) ? "../../" : String.Empty;

            switch (mesajTipi)
            {
                case PopupMesajTipleri.Bilgi:
                    iconPath += "thssbs_images/information/information.ico";
                    break;
                case PopupMesajTipleri.Basari:
                    iconPath += "thssbs_images/information/success.ico";
                    break;
                case PopupMesajTipleri.Uyari:
                    iconPath += "thssbs_images/information/warning.ico";
                    break;
                case PopupMesajTipleri.Hata:
                    iconPath += "thssbs_images/information/error.ico";
                    break;
                default:
                    iconPath += "thssbs_images/information/information.ico";
                    break;
            }

            var messageBuilder = new StringBuilder("<div id='messageModalDiv' class='modal fade'>");
            messageBuilder.Append("<div class='modal-dialog'>");
            messageBuilder.Append("<div class='modal-content'>");
            messageBuilder.Append("<div class='modal-header'>");
            messageBuilder.AppendFormat("<h3>{0}</h3>", baslik);
            messageBuilder.Append("</div>");
            messageBuilder.AppendFormat("<div class='modal-body'>{0}</div>", mesaj);
            messageBuilder.Append("<div class='modal-footer'>");
            messageBuilder.Append("<button class='btn btn-primary' data-bs-dismiss='modal'  ");

            if (requireRefresh)
                messageBuilder.Append(" onclick='location.href = location.href;'");
            else if (!String.IsNullOrWhiteSpace(redirectPath))
                messageBuilder.AppendFormat(" onclick=\"document.location.href='/{0}'; \"", redirectPath);

            messageBuilder.Append(">Kapat</button>");
            messageBuilder.Append("</div>");
            messageBuilder.Append("</div>");
            messageBuilder.Append("</div>");
            messageBuilder.Append("</div>");

            return messageBuilder.ToString();
        }

        internal static void HtmlEkle(Page page, string html)
        {
            PlaceHolder placeHolder = page.FindControlRecursive("popupMessagePlaceHolder") as PlaceHolder;

            if (placeHolder == null)
                throw new Exception("Sayfada 'popupMessagePlaceHolder' isimli bir PlaceHolder nesnesi bulunamadı.");

            LiteralControl literalControl = new LiteralControl(html);
            placeHolder.Controls.Add(literalControl);
        }

    }
}
