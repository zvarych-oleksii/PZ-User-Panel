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
        private readonly IUserRepository _userRepository;

        public CartBL(ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
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
            Cart cart = this.GetCartById(cartId);
            var quantity = cart.Quantity;
            Product product = _productRepository.GetProductById(cart.ProductId);
            var productQuantity = product.Quantity;
            product.Quantity = quantity + productQuantity;
            _cartRepository.DeleteCart(cartId);
        }

        public void UpdateCart(Cart cart)
        {
            Cart old_cart = this.GetCartById(cart.CartId);
            var diff = old_cart.Quantity - cart.Quantity;
            Product product = _productRepository.GetProductById(cart.ProductId);
            var productQuantity = product.Quantity;
            product.Quantity = diff + productQuantity;
            _productRepository.UpdateProduct(product);
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

        public decimal GetCartTotalSumByUserId(int userId)
        {
            var userCarts = _cartRepository.GetUserCarts(userId);
            decimal totalSum = 0;

            foreach (var cart in userCarts)
            {
                // Assuming Product has a Price property
                totalSum += cart.Quantity * cart.Product.Price;
            }

            return totalSum;
        }

        public List<Cart> GetUserCarts(int userId)
        {
            return _cartRepository.GetUserCarts(userId);
        }

        public Cart GetCartById(int cartId)
        {
            return _cartRepository.GetCartById(cartId);
        }

        public List<User> GetListOfUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<Product> GetListOfProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Cart ASPAddCart(Cart cart)
        {
            int quantityToBuy = cart.Quantity;
            var produtId = cart.ProductId;
            Product product = _productRepository.GetProductById(produtId);
            int productQuantity = product.Quantity;
            product.Quantity = productQuantity - quantityToBuy;
            _productRepository.UpdateProduct(product);
            _cartRepository.AddCart(cart);
            return cart;
        }
    }
}
