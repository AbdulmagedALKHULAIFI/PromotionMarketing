using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PromotionMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //if (!context.Products.Any())
                //{
                //    context.Products.AddRange(new Product()
                //    {
                //        Name = "Kinder bueno",
                //        Brand = "Frerero",
                //        Price = 3,
                //    },
                //    new Product()
                //    {
                //        Name = "Kit kat",
                //        Brand = "Kit kat",
                //        Price = 2
                //    },
                //    new Product()
                //    {
                //        Name = "Bounty",
                //        Brand = "Bounty",
                //        Price = 2
                //    });
                //}

                //if (!context.Ops.Any())
                //{
                //    context.Ops.AddRange(new Op()
                //    {
                //        Enseigne = "Auchan",
                //        StartDateOperation = new DateTime(2021, 12, 01),
                //        EndDateOperation = new DateTime(2021, 12, 25)
                //    },
                //    new Op()
                //    {
                //        Enseigne = "Carrefour",
                //        StartDateOperation = new DateTime(2021, 12, 01),
                //        EndDateOperation = new DateTime(2021, 12, 10)
                //    });
                //}
                context.SaveChanges();
            }
        }
    }
}
