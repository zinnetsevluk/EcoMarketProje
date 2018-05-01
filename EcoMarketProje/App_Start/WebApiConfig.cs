using System.Net.Http.Formatting;
using System.Web.Http;

namespace EcoMarketProje
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
