using DTO_Core.Models;

namespace BusinessLogic.IBL
{
    public interface ICartBL
    {
        void AddCart(Cart cart);
        void DeleteCart(int cartId);
        void UpdateCart(Cart cart);
        List<Cart> GetAllCarts();
    }
}
