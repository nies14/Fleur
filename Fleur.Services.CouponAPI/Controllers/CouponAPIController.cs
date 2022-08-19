using Fleur.Services.CouponAPI.Models.Dto;
using Fleur.Services.CouponAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Fleur.Services.CouponAPI.Controllers
{

    [ApiController]
    [Route("api/coupon")]
    public class CouponAPIController : Controller
    {
        protected ResponseDto _response;
        private ICouponRepository _couponRepository;

        public CouponAPIController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
