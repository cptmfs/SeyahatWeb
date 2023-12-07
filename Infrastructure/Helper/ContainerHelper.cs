using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unity;

namespace Infrastructure.Helper
{
    public class ContainerHelper
    {
        public static IUnityContainer Container
        {
            get { return HttpContext.Current.Application["Container"] as IUnityContainer; }
            set { HttpContext.Current.Application["Container"] = value; }
        }
    }
}
