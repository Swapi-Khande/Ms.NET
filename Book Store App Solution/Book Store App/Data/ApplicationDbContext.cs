using Book_Store_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Spiritual", DisplayOrder = 1},
                new Category { Id=2, Name="SciFi", DisplayOrder = 2},
                new Category { Id=3, Name="History", DisplayOrder = 3}
            );
        }
    }
}
