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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8.Pages
{
    /// <summary>
    /// Interaction logic for ProductPagePhotos.xaml
    /// </summary>
    public partial class ProductPagePhotos : Page
    {
        public ProductPagePhotos()
        {
            InitializeComponent();
            var currentProduct = Entities.GetContext().Products.ToList();
            ListUser.ItemsSource = currentProduct;
        }
    }
}
