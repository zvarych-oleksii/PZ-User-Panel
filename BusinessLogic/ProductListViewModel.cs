using System.Collections.ObjectModel;
using System.Windows.Input;
using DTO_Core.Models;
using PZ_User_Panel_console.Data.IModels;

namespace BusinessLogic
{
    public class ProductListViewModel : ViewModelBase
    {
        private readonly IProductRepository _productRepository;

        public ObservableCollection<Product> ProductList { get; set; }

        public ProductListViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Use _productRepository to get the product list and populate ProductList
        }

        // Add other logic as needed
    }
}
