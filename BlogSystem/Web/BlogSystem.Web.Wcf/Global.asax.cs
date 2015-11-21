namespace BlogSystem.Web.Wcf
{
    using Common.Constants;
    using Configurations;
    using Ninject;
    using Ninject.Web.Common;

    public class Global : NinjectHttpApplication
    {
        public override void Init()
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebTransferModels);
            base.Init();
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new NinjectDependencyResolver());
        }
    }
}