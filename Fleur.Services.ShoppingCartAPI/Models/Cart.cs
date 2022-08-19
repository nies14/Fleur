namespace Fleur.Services.ShoppingCartAPI.Models
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }

        // if multiple products added it will hold the reference of all of them
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
