using DTO_Core.Models;

namespace BusinessLogic.IBL
{
    public interface IProductBL
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        List<Product> GetProducts();
        Product GetProduct(int productId);

    }
}
