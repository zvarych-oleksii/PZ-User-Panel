using BusinessLogic.IBL;
using DTO_Core.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Commands;
using WPF.Utilities;

namespace WPF.ViewModels
{
    public class ProductBuyViewModel : INotifyPropertyChanged
    {
        private Product _product;
        private ICartBL cartBL;
        private int _quantity;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand SubmitCommand { get; }

        public ProductBuyViewModel(Product product, ICartBL cartBL)
        {
            _product = product;
            this.cartBL = cartBL;
            SubmitCommand = new SubmitCommand(this);
        }

        public void Submit()
        {
            Cart cart = new Cart
            {
                ProductId = Product.ProductId,
                UserId = UserContext.UserId,
                Quantity = Quantity,
            };
            cartBL.AddCart(cart);

            // Add your logic here for handling the submit action
            // You can access the entered quantity using Quantity
            // and other details using Product properties.
            // Your business logic goes here.
        }
        public Action Submited { get; set; }
        public bool IsValid
        {
            get
            {
                return cartBL.CheckQuantity(_product, Quantity);
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
