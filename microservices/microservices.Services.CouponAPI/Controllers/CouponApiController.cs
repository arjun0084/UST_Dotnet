using AutoMapper;
using microservices.Services.CouponAPI.Data;
using microservices.Services.CouponAPI.Models;
using microservices.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservices.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public CouponApiController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _response.Result =_mapper.Map<IEnumerable<CouponDto>>(objlist);
            }
            catch (Exception ex)
            {
                _response.Issuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<ResponseDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Issuccess=false;
                _response.Message = ex.Message;
            }
            return _response;

        }

    }
}
