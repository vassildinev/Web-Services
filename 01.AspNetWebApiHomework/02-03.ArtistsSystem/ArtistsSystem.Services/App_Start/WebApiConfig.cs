namespace ArtistsSystem.Services
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        
            /// Api Routes:
            /// 
            /// CREATE -> api/{controller}/
            /// READ -> api/{controller}/
            /// UPDATE -> api/{controller}/{id}/
            /// DELETE -> api/{controller}/{id}/
        }
    }
}
