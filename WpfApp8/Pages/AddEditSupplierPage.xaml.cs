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
    /// Логика взаимодействия для AddEditSupplierPage.xaml
    /// </summary>
    public partial class AddEditSupplierPage : Page
    {
        private Supplier _supplier = new Supplier();
        public AddEditSupplierPage(Supplier SelectedSupplier)
        {
            InitializeComponent();
            if (SelectedSupplier != null)
                _supplier = SelectedSupplier;
            DataContext = _supplier;
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_supplier.Name))
                errors.AppendLine("Введите название компании!");
            if (string.IsNullOrWhiteSpace(_supplier.Adress))
                errors.AppendLine("Введите адрес!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_supplier.Phone_number)))
                errors.AppendLine("Введите номер телефона!");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_supplier.Supplier_id == 0)
                    Entities.GetContext().Supplier.Add(_supplier);
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
