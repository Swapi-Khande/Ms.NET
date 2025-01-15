using MicroservicesApp.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.CouponAPI.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected void onModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20
            });


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40
            });
        }
    }
}
