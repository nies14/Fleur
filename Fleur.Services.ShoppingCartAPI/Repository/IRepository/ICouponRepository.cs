using Fleur.Services.ShoppingCartAPI.Models.Dto;

namespace Fleur.Services.ShoppingCartAPI.Repository.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
