using System;
using System.Web;
using Ninject;
using Ninject.Web.Common;
using SQLite.BLL.Interfaces;
using SQLite.BLL.Services;
using SQLite.DAL.Database;
using SQLite.DAL.Interfaces;

namespace SQLite.WEB
{
    public static class NinjectWebCommon
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // SQLite.Data
            kernel.Bind<IUnitOfWork>().To<SQLiteUnitOfWork>().InRequestScope();
            kernel.Bind<IDbFactory>().To<SQLiteDbFactory>().InRequestScope();

            // SQLite.BLL
            kernel.Bind<IPersonService>().To<PersonService>();
        }
    }
}