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
using WpfApp8.Pages;
using System.IO; 
using System.Diagnostics;
using Microsoft.Win32;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";
            
            if (page is AuthPage)
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible;
            }

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Calc());
            var uri = new Uri("DictionaryCalc.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        void Export() 
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file (*.txt)|*.txt";
            if (sfd.ShowDialog() == true)
            {
                
                using (var db = new Entities())
                {
                    var user = db.User.AsNoTracking().ToList();
                    string IDline = String.Join(":", db.User.Select(x => x.ID));
                    File.WriteAllText(sfd.FileName, IDline);


                }
                Process.Start("notepad.exe", sfd.FileName);
            }
            else MessageBox.Show("Файл для экспорта не создан!");
        }

        void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "") 
            {
                StreamReader sr = new StreamReader(ofd.FileName); 
                while (!sr.EndOfStream) 
                {
                    string[] lines = new string[5];
                    for (int i = 0; i < 5; i++) 
                    {
                        string line = sr.ReadLine();  
                        string[] data = line.Split(':');
                        line = "";   
                        if (data.Length >= 2) 
                        {
                            for (int j = 1; j < data.Length; j++)      
                            {
                                line += data[j]; 
                            }
                        }
                        lines[i] = line;
                    }
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] + "\nФИО: " + lines[1] + "\nЛогин: " + lines[2] + "\nПароль: " + lines[3] + "\nРоль: " + lines[4]);
                }
            }
            else MessageBox.Show("Файл для импорта не выбран!");
            

        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void Import1_Click(object sender, RoutedEventArgs e)
        {
            Import();
        }
    }
}
