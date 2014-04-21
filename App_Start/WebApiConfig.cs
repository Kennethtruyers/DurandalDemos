using System.Web.Http;
using Newtonsoft.Json;

namespace ProjectFinder
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "API Default",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		}
	}
}
