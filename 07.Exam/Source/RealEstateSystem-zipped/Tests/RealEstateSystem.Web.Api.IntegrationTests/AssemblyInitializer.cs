namespace RealEstateSystem.Web.Api.IntegrationTests
{
    using Common.Constants;
    using Infrastructure.IdentityProviders.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AssemblyInitializer
    {
        public static IIdentityProvider IdentityProvider { get; private set; }

        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebTransferModels);
        }
    }
}
