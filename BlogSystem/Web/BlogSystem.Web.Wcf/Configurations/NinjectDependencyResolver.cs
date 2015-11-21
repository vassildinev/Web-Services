namespace BlogSystem.Web.Wcf.Configurations
{
    using Common.Constants;
    using Data;
    using Data.Repositories;
    using Ninject.Modules;
    using Ninject.Extensions.Conventions;

    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            this.Kernel
                .Bind(typeof(IBlogSystemDbContext))
                .To(typeof(BlogSystemDbContext));

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