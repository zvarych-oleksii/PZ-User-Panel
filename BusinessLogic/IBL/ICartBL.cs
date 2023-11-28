using DTO_Core.Models;

namespace BusinessLogic.IBL
{
    public interface ICartBL
    {
        void AddCart();
        void DeleteCart();
        void UpdateCart();
        List<Cart> GetAllCarts();
    }
}
