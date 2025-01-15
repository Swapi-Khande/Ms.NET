using MicroservicesApp.Services.CouponAPI.Data;
using MicroservicesApp.Services.CouponAPI.Models;
using MicroservicesApp.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesApp.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _res;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _res = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _res.Result = objList;
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;

            }
            return _res;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i=>i.CouponId==id);
                _res.Result = obj;
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }
    }
}
