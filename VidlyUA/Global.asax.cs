using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VidlyUA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //
            // The following line added because of this failing messaage when trying to run ToList() on my Enums
            //  The model backing the 'ApplicationDbContext' context has changed since the database was created
            //  !!! WATCH FOR DOWN STREAM PROBLEMS. NOT SURE WHAT IS GETTING FIXED BY ADDING THE CODE !!!//
            //
            Database.SetInitializer<Models.ApplicationDbContext>(null);
        }
    }
}
