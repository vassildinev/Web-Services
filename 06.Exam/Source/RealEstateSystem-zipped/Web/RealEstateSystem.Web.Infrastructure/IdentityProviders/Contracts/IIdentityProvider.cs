namespace RealEstateSystem.Web.Infrastructure.IdentityProviders.Contracts
{
    using System.Security.Principal;

    public interface IIdentityProvider
    {
        IIdentity GetIdentity();
    }
}
