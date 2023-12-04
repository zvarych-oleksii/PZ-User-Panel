using Avalonia.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Unity.Resolution;
using Unity;
using WPF.ViewModels;
using DTO_Core.Models;
using System.Windows.Media;

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
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var dataGrid = FindParent<DataGrid>(button);
                if (dataGrid != null)
                {
                    var selectedProduct = dataGrid.SelectedItem as Product;

                    // Now 'selectedProduct' holds the object in the selected row.

                    if (selectedProduct != null)
                    {
                        // Do something with the selected product (e.g., open a detail view)
                        var detailViewModel = new ProductDetailViewModel(selectedProduct);
                        var productDetailsWindow = new ProductDetail(detailViewModel);
                        productDetailsWindow.ShowDialog();
                    }
                }
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            //var button = sender as Button;
            //if (button != null)
            //{
            //    var dataGrid = FindParent<DataGrid>(button);
            //    if (dataGrid != null)
            //    {
            //        var selectedProduct = dataGrid.SelectedItem as YourProductClass;

            //        // Now 'selectedProduct' holds the object in the selected row.

            //        if (selectedProduct != null)
            //        {
            //            // Do something with the selected product (e.g., add to cart)
            //            // Add your logic for buying the product here
            //        }
            //    }
            //}
        }

        // Helper method to find the parent of a specific type in the visual tree
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            while (true)
            {
                // Get parent item
                DependencyObject parentObject = VisualTreeHelper.GetParent(child);

                // We've reached the end of the tree
                if (parentObject == null) return null;

                // Check if the parent matches the type we're looking for
                if (parentObject is T parent)
                    return parent;

                child = parentObject;
            }
        }

    }
}
