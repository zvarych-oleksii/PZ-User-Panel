//using AutoMapper;
//using BusinessLogic.IBL;
//using DTO_Core.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using WEB_MVC.Controllers;
//using WEB_MVC.Models;
//using Xunit;

//namespace Controller_Tests
//{
//    public class CartControllerTests
//    {
//        [Fact]
//        public async Task Index_ReturnsViewResultWithListOfCarts()
//        {
//            // Arrange
//            var mockCartBL = new Mock<ICartBL>();
//            var mockMapper = new Mock<IMapper>();

//            var controller = new CartController(mockCartBL.Object, mockMapper.Object);

//            var carts = new List<Cart> { new Cart(), new Cart() }; // Add sample data as needed
//            var cartModels = carts.Select(c => new CartModel()); // Map to CartModel

//            mockCartBL.Setup(bl => bl.GetAllCarts()).Returns(carts);
//            mockMapper.Setup(m => m.Map<List<CartModel>>(It.IsAny<List<Cart>>())).Returns(cartModels);

//            // Act
//            var result = await controller.Index();

//            // Assert
//            var viewResult = Assert.IsType<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<List<CartModel>>(viewResult.ViewData.Model);
//            Assert.Equal(carts.Count, model.Count());
//        }

//        // Add more tests for other actions as needed
//    }
//}
