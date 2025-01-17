using Microsoft.AspNetCore.Identity;

namespace MicroservicesApp.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
