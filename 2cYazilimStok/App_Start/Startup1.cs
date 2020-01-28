using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Entity.Entity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_2cYazilimStok.App_Start.Startup1))]

namespace _2cYazilimStok.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            createSeed();
        }
        private void createSeed()
        {
            Context2c context = new Context2c();

            if (!context.Trademarks.Any())
            {
                context.Trademarks.Add(new Trademark()
                {
                    Name = "Marka 1",
                    Description = "Marka Açıklaması"
                });
                context.Trademarks.Add(new Trademark()
                {
                    Name = "Marka 2",
                    Description = "Marka Açıklaması"
                });
                context.Trademarks.Add(new Trademark()
                {
                    Name = "Marka 3",
                    Description = "Marka Açıklaması"
                });
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.Add(new Product()
                {
                    Name = "Ürün Adı",
                    Description = "Ürün Açıklaması",
                    Amount = 1000,
                    CreateDate = DateTime.Now,
                    Trademark = 1,
                    ImagePath = "Images/no-image.png"
                });
                context.SaveChanges();
            }
        }
    }
}
