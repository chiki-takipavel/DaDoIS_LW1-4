using Services.Client;
using Microsoft.Practices.Unity;
using AppContext = ORMLibrary.AppContext;

namespace WebApplication.DIContainer
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IUnityContainer kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IUnityContainer kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IUnityContainer kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.RegisterType<AppContext, AppContext>(new PerThreadLifetimeManager());
            }
            else
            {
                kernel.RegisterType<AppContext, AppContext>();
            }

            #region Services

            kernel.RegisterType<IClientService, ClientService>();

            #endregion

            #region Repositories 

            #endregion


        }
    }
}
