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

    }
}
