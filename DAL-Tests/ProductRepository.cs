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
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;
        private StoreDBContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new StoreDBContext(options);
            _productRepository = new ProductRepository(_dbContext);
        }

        [TestMethod]
        public void AddProduct()
        {
            var product = new Product
            {
                ProductId = 1,
                CategoryId = 2,
                ProductName = "TestProduct1",
                ProductDescription = "TestDescription1",
                Price = 122,
            };
            _productRepository.AddProduct(product);
            var addedProduct = _dbContext.Product.FirstOrDefault(p => p.ProductId == product.ProductId);
            Assert.IsNotNull(addedProduct);
        }

        [TestMethod]
        public void RemoveProduct()
        {
            var product = new Product
            {
                ProductId = 2,
                CategoryId = 3,
                ProductName = "TestProduct2",
                ProductDescription = "TestPDescription2",
                Price = 222,
            };
            _productRepository.AddProduct(product);
            _productRepository.DeleteProduct(1);
            var nullProduct = _productRepository.GetProductById(1);
            Assert.IsNull(nullProduct);

        }

        [TestMethod]
        public void GetAllProducts_Should_Return_All_Products()
        { 
            var product3 = new Product
            {
                ProductId = 3,
                CategoryId = 1,
                ProductName = "TestProduct3",
                ProductDescription = "TestDescription3",
                Price = 333,
            };

            _productRepository.AddProduct(product3);

            List<Product> products = _productRepository.GetAllProducts();

            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count);
        }

        [TestMethod]
        public void GetProductById_Should_Return_This_Product()
        {
            var expectedProduct = new Product
            {
                ProductId = 4,
                CategoryId = 4,
                ProductName = "TestProduct4",
                ProductDescription = "TestDescription4",
                Price = 444,
            };

            _productRepository.AddProduct(expectedProduct);

          
            var retrievedProduct = _productRepository.GetProductById(4);

          
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(expectedProduct.ProductId, retrievedProduct.ProductId);
            Assert.AreEqual(expectedProduct.ProductName, retrievedProduct.ProductName);
       }

        [TestMethod]
        public void UpdateProduct_Should_Update_Product()
        {
           
            var originalProduct = new Product
            {
                ProductId = 5,
                CategoryId = 1,
                ProductName = "TestProduct5",
                ProductDescription = "TestDescription5",
                Price = 5,
            };


            _productRepository.AddProduct(originalProduct);

            var updatedProduct = new Product
            {
                ProductId = 5,
                CategoryId = 2, 
                ProductName = "UpdatedProduct",
                ProductDescription = "UpdatedDescription",
                Price = 222, 
            };

            
            _productRepository.UpdateProduct(updatedProduct);

            var retrievedProduct = _productRepository.GetProductById(5);

            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(updatedProduct.CategoryId, retrievedProduct.CategoryId);
            Assert.AreEqual(updatedProduct.ProductDescription, retrievedProduct.ProductDescription);
            Assert.AreEqual(updatedProduct.Price, retrievedProduct.Price);
        }

        [TestMethod]
        public void GetProductByName_Should_Return_This_Product()
        {
            var product = new Product
            {
                ProductId = 6,
                CategoryId = 2,
                ProductName = "TestProduct6",
                ProductDescription = "TestDescription6",
                Price = 666,
            };
            _productRepository.AddProduct(product);
            Product getted_product = _productRepository.GetProductByName("TestProduct6");
            Assert.IsNotNull(getted_product);
            Assert.AreEqual(product.ProductName, getted_product.ProductName);
        }

        [TestMethod]
        public void GetProductByCategory_Should_Return_All_List()
        {
            var product = new Product
            {
                ProductId = 7,
                CategoryId = 7,
                ProductName = "TestProduct7",
                ProductDescription = "TestDescription7",
                Price = 777,
            };
            _productRepository.AddProduct(product);
            var product2 = new Product
            {
                ProductId = 8,
                CategoryId = 7,
                ProductName = "TestProduct8",
                ProductDescription = "TestDescription8",
                Price = 888,
            };
            _productRepository.AddProduct(product2);
            List<Product> products = _productRepository.GetProductsByCategory(7);
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _dbContext = null;
            _productRepository = null;
        }
    }

}