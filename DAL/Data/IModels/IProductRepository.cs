using DTO_Core.Models;

namespace DAL.Data.IModels
{
    public interface IProductRepository
    {
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
        Product GetProductByName(string name);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        List<Product> SearchProduct(string name);
    }
}
