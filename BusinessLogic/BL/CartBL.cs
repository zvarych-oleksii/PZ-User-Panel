using BusinessLogic.IBL;
using DAL.Data.IModels;
using DAL.Data.Models;
using DTO_Core.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.BL
{
    public class CartBL : ICartBL
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartBL(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

      
        public void AddCart(Cart cart)
        {
            int quantityToBuy = cart.Quantity;
            var produtId = cart.ProductId;
            Product product = _productRepository.GetProductById(produtId);
            int productQuantity = product.Quantity;
            product.Quantity = productQuantity - quantityToBuy;
            _productRepository.UpdateProduct(product);
            _cartRepository.AddCart(cart);
        }

        public void DeleteCart(int cartId)
        {
            _cartRepository.DeleteCart(cartId);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }

        public List<Cart> GetAllCarts()
        {
            return _cartRepository.GetAllCarts();
        }

        public bool CheckQuantity(Product product, int quantity)
        {
            if (quantity > 0 && quantity <= product.Quantity )
            {
                return true;
            }
            return false;
        }
    }
}
