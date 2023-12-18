using DTO_Core.Models;

namespace BusinessLogic.IBL
{
    public interface ICartBL
    {
        void AddCart(Cart cart);
        void DeleteCart(int cartId);
        void UpdateCart(Cart cart);
        List<Cart> GetAllCarts();
        bool CheckQuantity(Product product, int quantity);
        decimal GetCartTotalSumByUserId(int userId);
        List<Cart> GetUserCarts(int userId);
        Cart GetCartById(int cartId);
        List<User> GetListOfUsers();
        List<Product> GetListOfProducts();
        Cart ASPAddCart(Cart cart);
    }
}
