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

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            var currentUsers = Entities.GetContext().User.ToList();
            ListUser.ItemsSource = currentUsers;
            CmbSorting.SelectedIndex = 0;
            CheckEmployees.IsChecked = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserText.Text = null;
            CheckEmployees.IsChecked = false;
            CmbSorting.SelectedIndex = 0;
        }

        private void UpdateUsers()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().User.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            currentUsers = currentUsers.Where(x => x.FIO.ToLower().Contains(UserText.Text.ToLower())).ToList();

            //обрабатываем фильтр по одной роли пользователей
            if (CheckEmployees.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Продавец")).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (CmbSorting.SelectedIndex == 0)
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.FIO).ToList();
            else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.FIO).ToList();

        }
    }
}
