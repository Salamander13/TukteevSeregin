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
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {
        private Orders _orders = new Orders();
        public AddEditOrderPage(Orders SelectedOrders)
        {
            InitializeComponent();
            if (SelectedOrders != null)
                _orders = SelectedOrders;
            DataContext = _orders;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Customer_id)))
                errors.AppendLine("Введите ID покупателя!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Product_id)))
                errors.AppendLine("Введите ID товара!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Employee_id)))
                errors.AppendLine("Введите ID продавца!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Product_quntity)))
                errors.AppendLine("Введите количество товара!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Discount)))
                errors.AppendLine("Введите скидку!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_orders.Order_price)))
                errors.AppendLine("Введите цену заказа!");
            if (string.IsNullOrWhiteSpace(_orders.Delivery_addres))
                errors.AppendLine("Введите Адрес доставки!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_orders.Order_id == 0)
                    Entities.GetContext().Orders.Add(_orders);
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
