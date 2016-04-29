using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace FsGit
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 设置App_Data的共享目录
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(RegisterService().Build()));
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();
            var assemblys = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/bin/")).GetFiles("*.dll").Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            //var assemblys = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterControllers(assemblys);

            // 普通组件注入
            //var baseType = typeof(IDependency);
            // builder.RegisterAssemblyTypes(assemblys).Where(t => baseType.IsAssignableFrom(t) && t != baseType).AsImplementedInterfaces().InstancePerLifetimeScope();

            // 缓存组件注入
            // var baseCacheType = typeof(ICache);
            // builder.RegisterAssemblyTypes(assemblys).Where(t => !baseType.IsAssignableFrom(t) && baseCacheType.IsAssignableFrom(t) && t != baseCacheType).AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }
    }
    public sealed class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/Home/{1}/{0}.cshtml",
                "~/Views/Sys/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}