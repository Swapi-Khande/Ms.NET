using AutoMapper;
using MicroservicesApp.Services.ProductAPI.Data;
using MicroservicesApp.Services.ProductAPI.Models;
using MicroservicesApp.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesApp.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _res;
        private IMapper _mapper;

        public ProductAPIController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Product> objList = _db.Products.ToList();
                _res.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
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
                Product obj = _db.Products.First(i=>i.ProductId==id);
                _res.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }


        [HttpPost]
        public ResponseDto Post([FromBody] ProductDto cDto) 
        {
            try
            {
                Product obj = _mapper.Map<Product>(cDto);
                _db.Products.Add(obj);
                _db.SaveChanges();
                _res.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] ProductDto cDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(cDto);
                _db.Products.Update(obj);
                _db.SaveChanges();
                _res.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _res.IsSuccess = false;
                _res.Message = ex.Message;
            }
            return _res;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(i => i.ProductId == id);
                _db.Products.Remove(obj);
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
