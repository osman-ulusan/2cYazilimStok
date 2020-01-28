using DAL.Migrations;
using Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Context2c : IdentityDbContext
    {
        public Context2c() : base("DefCon")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context2c, Configuration>("DefCon"));
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Trademark> Trademarks { get; set; }
    }
}
