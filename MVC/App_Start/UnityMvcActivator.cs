using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using IFramework.Unity;
using IFramework.IoC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVC.App_Start.UnityMvcActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MVC.App_Start.UnityMvcActivator), "Shutdown")]

namespace MVC.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityMvcActivator
    {
        static IContainer _container;

        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            _container = IoCConfig.GetMvcConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(_container.GetUnityContainer()));

            DependencyResolver.SetResolver(new IFramework.Unity.Mvc.UnityDependencyResolver(_container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            _container?.Dispose();
        }
    }
}