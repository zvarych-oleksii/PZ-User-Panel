using DTO_Core.Models;
using System.ComponentModel;

public class ProductDetailViewModel : INotifyPropertyChanged
{
    private Product product;

    public Product Product
    {
        get { return product; }
        set
        {
            product = value;
            OnPropertyChanged(nameof(Product));
        }
    }

    public ProductDetailViewModel(Product product)
    {
        this.product = product;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
