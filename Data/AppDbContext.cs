using Microsoft.EntityFrameworkCore;
using PromotionMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Op>()
                .HasOne(p => p.Product)
                .WithMany(po => po.Product_Ops)
                .HasForeignKey(pi => pi.ProductId)
                /*.OnDelete(DeleteBehavior.SetNull)*/;

            modelBuilder.Entity<Product_Op>()
                .HasOne(o => o.Op)
                .WithMany(po => po.Product_Ops)
                .HasForeignKey(pi => pi.OpId)
                /*.OnDelete(DeleteBehavior.SetNull)*/;
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Op> Ops { get; set; }
        public DbSet<PromoOneForTwo> PromoOnesForTwos { get; set; }
        public DbSet<Product_Op> Products_Ops { get; set; }

    }
}
