using System.ComponentModel.DataAnnotations;

namespace Fleur.Services.ShoppingCartAPI.Models
{
    // will conisit of a userid and a coupon code
    // if something is applied on that shopping cart
    // consider As Coupon table
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
