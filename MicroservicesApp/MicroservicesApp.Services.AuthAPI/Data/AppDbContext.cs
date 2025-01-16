
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.AuthAPI.Data
{
    public class AppDbContext: IdentityDbContext<>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected void onModelCreating(ModelBuilder modelBuilder) 
        {
         
        }
    }
}
