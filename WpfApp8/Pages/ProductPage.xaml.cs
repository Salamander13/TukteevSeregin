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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            DataGridProduct.ItemsSource = Entities.GetContext().Products.ToList();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.AddEditPage(null));
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pages.AddEditPage((sender as Button).DataContext as Products));
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            var ProdeuctForRemoving = DataGridProduct.SelectedItems.Cast<Products>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ProdeuctForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Products.RemoveRange(ProdeuctForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridProduct.ItemsSource = Entities.GetContext().Products.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            {
                if (Visibility == Visibility.Visible)
                {
                    Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                    DataGridProduct.ItemsSource = Entities.GetContext().Products.ToList();
                }
            }

        }
    }
}
