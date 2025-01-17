using MicroservicesApp.Services.AuthAPI.Models;

namespace MicroservicesApp.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
