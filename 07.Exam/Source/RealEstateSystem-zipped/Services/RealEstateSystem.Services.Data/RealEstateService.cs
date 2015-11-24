namespace RealEstateSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using RealEstateSystem.Data.Models;
    using RealEstateSystem.Data.Repositories;

    public class RealEstateService : IRealEstateService
    {
        private readonly IRepository<RealEstate> realEstates;

        public RealEstateService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public void Add(RealEstate entry)
        {
            this.realEstates.Add(entry);
            this.realEstates.SaveChanges();
        }

        public IQueryable<RealEstate> All()
        {
            return this.realEstates.All();
        }

        public IQueryable<RealEstate> GetById(int id)
        {
            var result = new List<RealEstate>();
            RealEstate entity = this.realEstates.GetById(id);
            result.Add(entity);

            return result.AsQueryable();
        }

        public IQueryable<RealEstate> GetSpecific(int skip = 0, int take = 10)
        {
            return this.realEstates
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip * take)
                .Take(take);
        }
    }
}
