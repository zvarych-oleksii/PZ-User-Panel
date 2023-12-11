using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BusinessLogic.IBL;
using DTO_Core.Models;
using WPF.Windows;

namespace WPF.ViewModels
{
    public class ProductListViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }



        private IProductBL productBL;
        private ObservableCollection<Product> products;
        public ICommand NavigateToUserDetailCommand { get; }



        public ObservableCollection<Product> ProductList
        { get { return products; } 
            set { products = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        public ProductListViewModel(IProductBL productBL)
        {
            this.productBL = productBL;
            Update();
        }



        public void Update()
        {
            var products = productBL.GetProducts();
            ProductList = new ObservableCollection<Product>(products);
        }
       
    }
}
