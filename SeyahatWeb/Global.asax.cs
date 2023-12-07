using System;

using System.Web;

using Unity.Injection;
using Unity;
using Repository.Modules.Seyehat.UnitOfWork;
using Entity.Seyehat;
using Infrastructure.Helper;

namespace SeyehatWeb
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            CreateUnityContainer();

            // Code that runs on application startup
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
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