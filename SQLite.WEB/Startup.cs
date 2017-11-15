using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLite.WEB.Startup))]
namespace SQLite.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = NinjectWebCommon.CreateKernel();
            app.UseNinjectMiddleware(() => kernel);
        }
    }
}
