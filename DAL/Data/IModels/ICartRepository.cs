using DTO_Core.Models;

namespace DAL.Data.IModels
{
    public interface ICartRepository
    {
        Cart GetCartById(int cartId);
        List<Cart> GetAllCarts();
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int cartId);
        int GetLastCart();
        public List<Cart> GetUserCarts(int userId);
    }
}
