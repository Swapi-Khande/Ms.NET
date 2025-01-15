using AutoMapper;
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
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _res = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _res.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
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
                _res.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i => i.CouponCode.ToLower() == code.ToLower());
                _res.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto cDto) 
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(cDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _res.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto cDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(cDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _res.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(i => i.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
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
