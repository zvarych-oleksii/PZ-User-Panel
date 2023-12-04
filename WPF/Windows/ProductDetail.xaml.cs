using System.Windows;
using WPF.ViewModels;

namespace WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        public ProductDetail(ProductDetailViewModel productDetailViewModel)
        {
            DataContext = productDetailViewModel;
            InitializeComponent();
        }
    }
}
