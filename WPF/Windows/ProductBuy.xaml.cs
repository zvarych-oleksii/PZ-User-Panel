﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModels;

namespace WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProductBuy.xaml
    /// </summary>
    public partial class ProductBuy : Window
    {
        public ProductBuy(ProductBuyViewModel productBuyViewModel)
        {
            DataContext = productBuyViewModel;
            InitializeComponent();
            Loaded += ProductBuy_Loaded;
        }

        private void ProductBuy_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ProductBuyViewModel vm)
            {
                vm.Submited += () =>
                {
                    DialogResult = true;
                    this.Close();
                };
            }
        }
    }
}