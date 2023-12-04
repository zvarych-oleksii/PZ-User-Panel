using DTO_Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_APP.ViewModels
{
    class ProductListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _productList;

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        // Constructor for design-time support
        public ProductListViewModel()
        {
            // Initialize with design-time data
            if (IsInDesignMode())
            {
                ProductList = GetDesignTimeProducts();
            }
            else
            {
                // Load runtime data or perform other initialization
                // For example: ProductList = LoadProductsFromDatabase();
            }
        }

        private ObservableCollection<Product> GetDesignTimeProducts()
        {
            // Create and return a collection of sample data for design-time
            return new ObservableCollection<Product>
            {
                new Product { ProductId = 1, ProductName = "Sample Product 1" },
                new Product { ProductId = 2, ProductName = "Sample Product 2" },
                new Product { ProductId = 3, ProductName = "Sample Product 3" },
            };
        }

        // Check if in design mode
        private static bool IsInDesignMode()
        {
            return (bool)System.ComponentModel.DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(System.Windows.DependencyObject)).DefaultValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
