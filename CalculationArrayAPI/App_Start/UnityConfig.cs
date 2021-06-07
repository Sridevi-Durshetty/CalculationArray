using CalculationArrayAPI.Models;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CalculationArrayAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProductService, ProductService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}