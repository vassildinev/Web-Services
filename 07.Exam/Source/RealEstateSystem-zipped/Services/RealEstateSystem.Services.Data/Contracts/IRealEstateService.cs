namespace RealEstateSystem.Services.Data.Contracts
{
    using System.Linq;

    using RealEstateSystem.Data.Models;

    public interface IRealEstateService
    {
        IQueryable<RealEstate> GetById(int id);

        IQueryable<RealEstate> GetSpecific(int page, int take);

        IQueryable<RealEstate> All();

        void Add(RealEstate entry);
    }
}
