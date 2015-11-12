using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurStore.DAL;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using OurStore.BLL;
using OurStore.Model;

namespace OurStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            OurStore.BLL.SampleDataBLL.Initialize();
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(new System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //System.Data.Entity.Database.SetInitializer(new OurStore.BLL.SampleData());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
