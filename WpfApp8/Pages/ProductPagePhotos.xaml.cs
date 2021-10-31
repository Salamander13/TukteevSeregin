using System;
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
            CmbSorting.SelectedIndex = 0;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserText.Text = null;
            CmbSorting.SelectedIndex = 0;
        }

        private void UpdateProducts()
        {
            var currentProducts = Entities.GetContext().Products.ToList();

            currentProducts = currentProducts.Where(x => x.Product_name.ToLower().Contains(UserText.Text.ToLower())).ToList();

            if (CmbSorting.SelectedIndex == 0)
                ListUser.ItemsSource = currentProducts.OrderBy(x => x.Product_name).ToList();
            else ListUser.ItemsSource = currentProducts.OrderByDescending(x => x.Product_name).ToList();

        }
    }
}
