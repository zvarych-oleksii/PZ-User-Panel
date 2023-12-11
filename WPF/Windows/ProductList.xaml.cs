using BusinessLogic.IBL;
using DTO_Core.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Unity;
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
                        ICartBL cartBLInstance = ((App)Application.Current).Container.Resolve<ICartBL>(); // You might need to adjust this based on how your ICartBL is registered in Unity
                        var buyViewModel = new ProductBuyViewModel(selectedProduct, cartBLInstance);
                        var productBuyWindow = new ProductBuy(buyViewModel);
                        productBuyWindow.ShowDialog();
                        productListViewModel.Update();
                    }

                }
            }
        }
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            IUserBL userBL = ((App)Application.Current).Container.Resolve<IUserBL>();
            ICartBL cartBL = ((App)Application.Current).Container.Resolve<ICartBL>();

            var userDetailViewModel = new UserDetailViewModel(cartBL, userBL);
            var userDetailWindow = new UserDetail(userDetailViewModel);
            userDetailWindow.Show();
            //var button = sender as Button;
            //UserDetail userDetailWindow = ((App)Application.Current).Container.Resolve<UserDetail>();
            //userDetailWindow.Show();
        }
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
