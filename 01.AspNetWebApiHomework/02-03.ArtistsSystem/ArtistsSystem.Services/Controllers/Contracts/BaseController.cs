namespace ArtistsSystem.Services.Controllers.Contracts
{
    using System.Web.Http;

    using Data;
    using Data.Data;
    using Data.Data.Contracts;

    public class BaseController: ApiController
    {
        protected readonly IArtistsSystemData data;

        public BaseController()
        {
            this.data = new ArtistsSystemData(new ArtistsSystemDbContext());
        }
    }
}