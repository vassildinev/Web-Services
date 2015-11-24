namespace RealEstateSystem.Web.Wcf.Configurations
{
    using Common.Constants;
    using Data;
    using Data.Repositories;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            this.Kernel
                .Bind(typeof(IRealEstateSystemDbContext))
                .To(typeof(RealEstateSystemDbContext));

            this.Kernel
                .Bind(typeof(IRepository<>))
                .To(typeof(GenericRepository<>));

            this.Kernel
                .Bind(b => b
                .From(Assemblies.WebServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}