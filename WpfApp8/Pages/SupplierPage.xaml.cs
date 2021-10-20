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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
            DataGridSupplier.ItemsSource = Entities.GetContext().Supplier.ToList();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.AddEditSupplierPage(null));
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.AddEditSupplierPage((sender as Button).DataContext as Supplier));
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            var SupplierForRemoving = DataGridSupplier.SelectedItems.Cast<Supplier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {SupplierForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Supplier.RemoveRange(SupplierForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridSupplier.ItemsSource = Entities.GetContext().Supplier.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
                if (Visibility == Visibility.Visible)
                {
                    Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                    DataGridSupplier.ItemsSource = Entities.GetContext().Supplier.ToList();
                }
            

        }
    }
}
