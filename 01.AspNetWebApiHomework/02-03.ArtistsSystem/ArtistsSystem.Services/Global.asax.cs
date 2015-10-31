namespace ArtistsSystem.Services
{
    using System.Net.Http.Formatting;
    using System.Web;
    using System.Web.Http;

    using Newtonsoft.Json;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
