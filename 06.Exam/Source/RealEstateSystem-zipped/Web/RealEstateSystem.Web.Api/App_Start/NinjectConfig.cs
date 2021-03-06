﻿namespace RealEstateSystem.Web.Api
{
    using System;
    using System.Web;

    using Common.Constants;
    using Data;
    using Data.Repositories;
    using Infrastructure.IdentityProviders;
    using Infrastructure.IdentityProviders.Contracts;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public class NinjectConfig
    {
        private static Action<IKernel> dependenciesRegistration = kernel =>
        {
            kernel
                .Bind<IRealEstateSystemDbContext>()
                .To<RealEstateSystemDbContext>();
            kernel
                .Bind(typeof(IRepository<>))
                .To(typeof(GenericRepository<>));
            kernel
                .Bind<IIdentityProvider>()
                .To<AspNetIdentityProvider>();
        };

        public static Action<IKernel> DependenciesRegistration
        {
            get { return dependenciesRegistration; }
            set { dependenciesRegistration = value; }
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>()
                    .ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>()
                    .To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            DependenciesRegistration(kernel);

            kernel.Bind(b => b
                .From(Assemblies.WebServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}