using BLL.Identity;
using DAL.Context;
using Entity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _2cYazilimStok
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            using (Context2c ent = new Context2c())
            {
                var usermanager = IdentityTools.NewUserManager();
                ApplicationUser user = new ApplicationUser();

                if (user.UserName != "admin")
                {
                    user.UserName = "admin";
                    user.Email = "admin@gmail.com";
                    var result = usermanager.Create(user, "admin12345");
                }

                //ent.Database.CreateIfNotExists();

            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
