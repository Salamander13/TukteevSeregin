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
    /// Логика взаимодействия для CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : Page
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page1());
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }
        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Menu());
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Calc());
        }
    }
}
