[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoDDD.MVC.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc;
    using ProjatoDDD.Domain.Interfaces;
    using ProjatoDDD.Domain.Interfaces.Services;
    using ProjetoDDD.Application.Interface;
    using global::AutoMapper;
    using Hangfire;

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
                //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                //kernel.Bind<IEntityCache>().ToMethod(context => EntityCache.Instance).InSingletonScope();
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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(IAppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<IClienteAppService>();
            kernel.Bind<IProdutoAppService>().To<IProdutoAppService>();

                
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(IServiceBase<>));
            kernel.Bind<IClienteService>().To<IClienteService>();
            kernel.Bind<IProdutoService>().To<IProdutoService>();


            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(IRepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<IClienteRepository>();
            kernel.Bind<IProdutoRepository>().To<IProdutoRepository>();


            //AutoMapper
            var mappingConfigs = AutoMapper.AutoMapperConfig.RegisterMappings();
            kernel.Bind<MapperConfiguration>().ToConstant(mappingConfigs).InSingletonScope();
            kernel.Bind<IMapper>().ToConstructor(ctx => new Mapper(mappingConfigs)).InSingletonScope();

        }        
    }
}
