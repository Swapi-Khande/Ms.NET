using MicroservicesApp.Web.Models;
using MicroservicesApp.Web.Service.IService;
using MicroservicesApp.Web.Utility;

namespace MicroservicesApp.Web.Service
{
    public class CouponService: ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.POST,
                Data = couponDto,
                Url = SConstants.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.DELETE,
                Url = SConstants.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.PUT,
                Data = couponDto,
                Url = SConstants.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
