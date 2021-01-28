using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCKutuphane
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /* GlobalFilters.Filters.Add(new AuthorizeAttribute()); *//*Bu kod otamatik Autrize ederi yani sadece*/
            // izin verilen sayfaya giriþ yapar
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
