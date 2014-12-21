[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VM.DataAccessLayer.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VM.DataAccessLayer.App_Start.NinjectWebCommon), "Stop")]

namespace VM.DataAccessLayer.App_Start {
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using VM.DataAccessLayer.ViewModels;
    using VM.DataAccessLayer.ViewModels.Temporary;
    using VM.DataAccessLayer.Common;
    using VM.DataAccessLayer.ViewModels.Accounts.Registration;
    using VM.DataAccessLayer.ViewModels.Management.WorkAgreements;

    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(NinjectWebCommon.CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop() {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                NinjectWebCommon.RegisterServices(kernel);
                return kernel;
            }
            catch {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {
            kernel.Bind<IAppDatabaseContext>().To<AppDatabaseContext>();
            kernel.Bind<ITemporaryService>().To<TemporaryService>();
            kernel.Bind<IWorkAgreementService>().To<WorkAgreementService>();
        }
    }
}
