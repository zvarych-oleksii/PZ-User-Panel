using DTO_Core.Models;
using System;
using System.Windows.Input;

namespace BusinessLogic
{
    public class ProductAddToCartViewModel : ViewModelBase
    {
        private Product _selectedProduct;
        private int _quantity;

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand AddToCartCommand { get; set; }

        public ProductAddToCartViewModel()
        {
        }

        private void AddToCart()
        {
            // Add logic to add product to cart
        }
    }
}
