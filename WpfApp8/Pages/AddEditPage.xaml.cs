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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Products _products = new Products();
        public AddEditPage(Products SelectedProduct)
        {
            InitializeComponent();
            if (SelectedProduct != null)
                _products = SelectedProduct;
            DataContext = _products;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_products.Product_name))
                errors.AppendLine("Введите название продукта!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_products.Date_of_receipt)))
                errors.AppendLine("Введите дату!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_products.Unit_price)))
                errors.AppendLine("Введите цену!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_products.Supply_id)))
                errors.AppendLine("Введите ID");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                Convert.ToDateTime(_products.Date_of_receipt);
                if (_products.Product_id == 0)
                Entities.GetContext().Products.Add(_products);
                try
                {
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
    }
}
