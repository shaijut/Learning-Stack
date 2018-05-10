[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProtoType.Demo.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProtoType.Demo.UI.App_Start.NinjectWebCommon), "Stop")]

namespace ProtoType.Demo.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Abstract;
    using Application.Services;
    using Domain.Abstract.Repository.People;
    using DataAccess.SQLServer.Repository.People;
    using Domain.Abstract.Repository.MongoDB;
    using DataAccess.MongoDB.Repository.People;
    using Domain.Abstract.Repository.ElasticSearch;
    using DataAccess.ElasticSearch.Repository;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPeopleService>().To<PeopleService>();
            kernel.Bind<Domain.Abstract.Entity.People.IPeople>().To<Domain.Entity.People.People>();
            kernel.Bind<IPeopleRepository>().To<PeopleRepository>();
            kernel.Bind<IPeopleMongoRepository>().To<PeopleMongoRepository>();
            kernel.Bind<IPeopleElasticRepository>().To<PeopleElasticRepository>();

        }        
    }
}
