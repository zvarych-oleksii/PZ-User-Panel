using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZ_User_Panel_console.Data.Models;
using PZ_User_Panel_console.Context;
using System.Collections.Generic;
using System.Linq;
using PZ_User_Panel_console.Context;

namespace PZ_DAL_Tests
{

    [TestClass]
    public class CartRepositoryTesting
    {
        private CartRepository _cartRepository;
        private StoreDBContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new StoreDBContext(options);
            _cartRepository = new CartRepository(_dbContext);
        }

        [TestMethod]
        public void AddCart_Should_Insert_Correct_Cart()
        {
            Cart cart = new Cart
            {
                CartId = 1,
                ProductId = 1,
                Quantity = 2,
                UserId = 1,
            };
            _cartRepository.AddCart(cart);
            var cart_to_check = _dbContext.Cart.FirstOrDefault();
            Assert.IsNotNull(cart_to_check);
            Assert.AreEqual(cart_to_check.CartId , cart.CartId);
        }

        [TestMethod]
        public void GetCartById_Should_Return_Correct()
        {
            var cart_to_check = _cartRepository.GetCartById(1);
            Assert.IsNotNull(cart_to_check);
            Assert.AreEqual(cart_to_check.CartId, 1);
        }

        [TestMethod]
        public void GetAllCarts_Should_Be_Correct()
        {
            Cart cart = new Cart
            {
                CartId = 2,
                ProductId = 2,
                Quantity = 2,
                UserId = 1,
            };
            Cart cart1 = new Cart
            {
                CartId = 3,
                ProductId = 1,
                Quantity = 4,
                UserId = 2,
            };
            _cartRepository.AddCart(cart);
            _cartRepository.AddCart(cart1);
            var carts = _cartRepository.GetAllCarts();
            Assert.IsNotNull(carts);
            Assert.AreEqual(3, carts.Count);
        }

        [TestMethod]
        public void UpdateCart_Should_Correctly_Update()
        {
            Cart cart = new Cart
            {
                CartId = 2,
                ProductId = 2,
                Quantity = 5,
                UserId = 1,
            };
            _cartRepository.UpdateCart(cart);
            var cart_to_check = _cartRepository.GetCartById(cart.CartId);
            Assert.IsNotNull(cart_to_check);
            Assert.AreEqual(cart_to_check.Quantity, 5);
        }

        [TestMethod]
        public void DeleteCart_Should_Correctly_Delete()
        {
            _cartRepository.DeleteCart(3);
            var cart = _cartRepository.GetCartById(3);
            Assert.IsNull(cart);
        }

        [TestMethod]
        public void GetLastCart_Should_Get_Correct()
        {
            Cart cart = new Cart
            {
                CartId = 4,
                ProductId = 2,
                Quantity = 5,
                UserId = 1,
            };
            _cartRepository.AddCart(cart);
            var cart_to_check = _cartRepository.GetLastCart();
            Assert.IsNotNull(cart_to_check);
            Assert.AreEqual(cart.CartId, cart_to_check);
        }

        [TestMethod]
        public void GetUserCarts_Should_Correctly()
        {
            var carts = _cartRepository.GetUserCarts(1);
            Assert.IsNotNull(carts);
            Assert.AreEqual(3, carts.Count);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext = null;
            _cartRepository = null;
        }
    }
}
