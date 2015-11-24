using BlogSystem.Web.Api;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace BlogSystem.Web.Api
{
    using System.Web.Http;

    using Common.Constants;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebTransferModels);
            //AutoMapper.Mapper.AssertConfigurationIsValid();

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
