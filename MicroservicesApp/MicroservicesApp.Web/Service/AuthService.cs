using MicroservicesApp.Web.Models;
using MicroservicesApp.Web.Service.IService;
using MicroservicesApp.Web.Utility;

namespace MicroservicesApp.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.POST,
                Data = registrationRequestDto,
                Url = SConstants.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.POST,
                Data = loginRequestDto,
                Url = SConstants.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.POST,
                Data = registrationRequestDto,
                Url = SConstants.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
