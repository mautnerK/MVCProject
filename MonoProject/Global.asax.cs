using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MonoProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Ninject.Modules.NinjectModule registrations = new App_Start.NinjectRegistrations();
            var kernel = new Ninject.StandardKernel(registrations);
            DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(kernel));
        }
    }
}
