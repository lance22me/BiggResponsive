using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Repository;
using BiggResponsive.Service;

using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;
using Ninject.Extensions.Logging.Log4net;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BiggResponsive.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BiggResponsive.App_Start.NinjectWebCommon), "Stop")]

namespace BiggResponsive.App_Start
{
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
            log4net.Config.XmlConfigurator.Configure();
            var settings = new NinjectSettings { LoadExtensions = false };
            var kernel = new StandardKernel(settings, new INinjectModule[] { new Log4NetModule() });

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                // ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(kernel)); <-- used that until WebApi entered the solution\

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel); // webApi controller
                System.Web.Mvc.DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel)); // mvc controller

                return kernel;
            }
            catch(Exception ex)
            {
                var foo = ex.Message;
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
            // Services ------------------

            kernel.Bind<IContactService>()
                .To<ContactService>()
                .InTransientScope();

            kernel.Bind<IMemberService>()
                .To<MemberService>()
                .InTransientScope();

            kernel.Bind<ICardService>()
                .To<CardService>()
                .InTransientScope();

            kernel.Bind<IGroupService>()
                .To<GroupService>()
                .InTransientScope();

            kernel.Bind<IProductService>()
                .To<ProductService>()
                .InTransientScope();

            // Repositories --------------

            kernel.Bind<IContactRepository>()
                .To<ContactRepository>()
                .InTransientScope();

            kernel.Bind<IMemberRepository>()
                .To<MemberRepository>()
                .InTransientScope();

            kernel.Bind<ICardRepository>()
                .To<CardRepository>()
                .InTransientScope();

            kernel.Bind<IProductRepository>()
                .To<ProductRepository>()
                .InTransientScope();
        }
    }
}
