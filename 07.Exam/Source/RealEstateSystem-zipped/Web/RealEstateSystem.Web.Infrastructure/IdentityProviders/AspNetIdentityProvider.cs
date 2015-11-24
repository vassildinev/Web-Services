namespace RealEstateSystem.Web.Infrastructure.IdentityProviders
{
    using System.Security.Principal;
    using System.Threading;

    using Contracts;

    public class AspNetIdentityProvider : IIdentityProvider
    {
        public IIdentity GetIdentity()
        {
            return Thread.CurrentPrincipal.Identity;
        }
    }
}
