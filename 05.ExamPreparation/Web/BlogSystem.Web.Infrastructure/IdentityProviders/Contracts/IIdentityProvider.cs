namespace BlogSystem.Web.Infrastructure.IdentityProviders.Contracts
{
    using System.Security.Principal;

    public interface IIdentityProvider
    {
        IIdentity GetIdentity();
    }
}
