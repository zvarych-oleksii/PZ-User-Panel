using DAL.Context;
using DAL.Data.IModels;
using DTO_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Models
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreDBContext _dbContext;

        public CartRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCart(Cart cart)
        {
            _dbContext.Cart.Add(cart);
            _dbContext.SaveChanges();
        }

        public Cart GetCartById(int cartId)
        {
            return _dbContext.Cart
    .Include(c => c.User)
    .Include(c => c.Product)
    .FirstOrDefault(c => c.CartId == cartId);
        }

        public List<Cart> GetAllCarts()
        {
            return _dbContext.Cart
     .Include(c => c.User)
     .Include(c => c.Product)
     .ToList();
        }

        public void UpdateCart(Cart cart)
        {
            var existingCart = _dbContext.Cart.Find(cart.CartId);

            if ( existingCart != null)
            {
                existingCart.ProductId = cart.ProductId;
                existingCart.Quantity = cart.Quantity;
                existingCart.UserId = cart.UserId;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCart(int cartId)
        {
            var cartToDelete = _dbContext.Cart.Find(cartId);

            if (cartToDelete != null)
            {
                _dbContext.Cart.Remove(cartToDelete);
                _dbContext.SaveChanges();
            }
        }
        public int GetLastCart()
        {
            int lastCartId = _dbContext.Cart
                .OrderByDescending(c => c.CartId)
                .Select(c => c.CartId)
                .FirstOrDefault();

            return lastCartId;
        }
        public List<Cart> GetUserCarts(int userId)
        {
            return _dbContext.Cart.Where(cart => cart.UserId == userId).ToList();
        }
    }
}
