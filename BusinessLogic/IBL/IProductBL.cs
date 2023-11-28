using DTO_Core.Models;

namespace BusinessLogic.IBL
{
    public interface IProductBL
    {
        void AddProduct();
        void UpdateProduct();
        void DeleteProduct();
        List<Product> GetProducts();
        Product GetProductById(int id);

    }
}
