using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Helper
{
    public class SessionHelper
    {
        public static int KullaniciId
        {
            get
            {
                if (HttpContext.Current.Session["KullaniciId"] == null)
                    HttpContext.Current.Session["KullaniciId"] = 0;
                return Convert.ToInt32(HttpContext.Current.Session["KullaniciId"]);
            }
            set
            {
                HttpContext.Current.Session["KullaniciId"] = value;
            }
        }

        public static string Isim
        {
            get
            {
                if (HttpContext.Current.Session["Isim"] == null)
                    HttpContext.Current.Session["Isim"] = String.Empty;

                return HttpContext.Current.Session["Isim"].ToString();
            }
            set
            {
                HttpContext.Current.Session["Isim"] = value;
            }
        }

        public static DateTime? SonGirisTarihi
        {
            get
            {
                if (HttpContext.Current.Session["SonGirisTarihi"] == null)
                    HttpContext.Current.Session["SonGirisTarihi"] = DateTime.Now;

                return (DateTime?)(HttpContext.Current.Session["SonGirisTarihi"]);
            }
            set
            {
                HttpContext.Current.Session["SonGirisTarihi"] = value;
            }
        }


        public static string KullaniciAdi
        {
            get
            {
                if (HttpContext.Current.Session["KullaniciAdi"] == null)
                    HttpContext.Current.Session["KullaniciAdi"] = String.Empty;

                return HttpContext.Current.Session["KullaniciAdi"].ToString();
            }
            set
            {
                HttpContext.Current.Session["KullaniciAdi"] = value;
            }
        }
    }
}
