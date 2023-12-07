using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity.Injection;
using Unity;
using Repository.Modules.Seyehat.UnitOfWork;
using Entity.Seyehat;
using Infrastructure.Helper;

namespace SeyehatWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            CreateUnityContainer();

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_End(object sender, EventArgs e)
        {
            DisposeUnityContainer();
        }
        private static void CreateUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ISeyehatUnitOfWork, SeyehatUnitOfWork>()
                     .RegisterType<GoTripEntities>(new InjectionConstructor());

           
            ContainerHelper.Container = container;
        }

        private static void DisposeUnityContainer()
        {
            if (ContainerHelper.Container != null)
                ContainerHelper.Container.Dispose();
        }
    }
}