using Fleur.Services.ShoppingCartAPI.Models.Dto;
using Fleur.Services.ShoppingCartAPI.Repository.IRepository;

namespace Fleur.Services.ShoppingCartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        public Task<CouponDto> GetCoupon(string couponName)
        {
            throw new NotImplementedException();
        }
    }
}
