using Microsoft.Owin;
[assembly: OwinStartup(typeof(ArtistsSystem.Services.ArtistsSystemStartup))]

namespace ArtistsSystem.Services
{
    using System.Web.Http;

    using Owin;

    public class ArtistsSystemStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            /// Api Routes:
            /// 
            /// CREATE -> api/{controller}/
            /// READ -> api/{controller}/
            /// UPDATE -> api/{controller}/{id}/
            /// DELETE -> api/{controller}/{id}/
        }
    }
}
