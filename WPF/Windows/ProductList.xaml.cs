using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.ViewModels;

namespace WPF.Windows
{
    public partial class ProductList : Window
    {
        ProductListViewModel productListViewModel;
        CollectionViewSource productCollection;
        public ProductList(ProductListViewModel vm)
        {
            productListViewModel = vm;
            DataContext = vm;
            InitializeComponent();

            productCollection = (CollectionViewSource)(Resources["ProductCollection"]);

            // Set the DataContext to the provided ProductListViewMode

            // Initialize UI elements or other setup logic here
        }
    }
}
