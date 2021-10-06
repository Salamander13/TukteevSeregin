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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(password.Password) || string.IsNullOrEmpty(ConfirmPassword.Password) || string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                MessageBox.Show("Один или несколько элементов пустые");

            }
            else {
                if (password.Password.Length >= 6)
                {
                    bool en = true; // английская раскладка
                    bool symbol = false; // символ
                    bool number = false; // цифра

                    for (int i = 0; i < password.Password.Length; i++) // перебираем символы
                    {
                        if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false; // если русская раскладка
                        if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true; // если цифры
                        if (password.Password[i] == '_' || password.Password[i] == '-' || password.Password[i] == '!') symbol = true; // если символ
                    }

                    if (!en)
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    else if (!symbol)
                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение

                }
                else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                if (password.Password == ConfirmPassword.Password) // проверка на совпадение паролей
                {
                    MessageBox.Show("Пользователь зарегистрирован");

                    Entities db = new Entities();
                    User userObject = new User
                    {
                        FIO = TextBoxFIO.Text,
                        Login = TextBoxLogin.Text,
                        Password = password.Password,
                        Role = ComboBoxRole.Text
                    };
                    db.User.Add(userObject);
                    db.SaveChanges();
                } else 
                   MessageBox.Show("Пароли не совподают");
            }
            
          
        }
    }
}
