using Fleur.Services.CouponAPI.Models.Dto;

namespace Fleur.Services.CouponAPI.Repository.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
