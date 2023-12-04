using DAL.Context;
using DAL.Data.IModels;
using DTO_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _dbContext;

        public ProductRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _dbContext.Product.Find(productId);

            if (productToDelete != null)
            {
                _dbContext.Product.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            // Example of eager loading
            Console.WriteLine(_dbContext.Product.ToList());
            return _dbContext.Product.Include(p => p.Category).ToList();

        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Product.Find(productId);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _dbContext.Product.Find(product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.Price = product.Price;

                _dbContext.SaveChanges();
            }
        }
        public Product GetProductByName(string name)
        {
            return _dbContext.Product.Where(p => p.ProductName.Contains(name)).FirstOrDefault();
        }
        public List<Product> SearchProduct(string Productname)
        {
            var matchingProducts = _dbContext.Product
                .Where(product => product.ProductName.Contains(Productname)).ToList();

            return matchingProducts;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var matchingProducts = _dbContext.Product
                .Where(product => product.CategoryId == categoryId).ToList();
            return matchingProducts;
        }
    }
}

