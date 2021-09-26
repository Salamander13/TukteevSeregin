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
    /// Логика взаимодействия для Calc.xaml
    /// </summary>
    public partial class Calc : Page
    {
        string leftop = ""; 
        string operation = "";
        string rightop = ""; 

        public Calc()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;
            bool result = false;
            int num;
            if (s == "ln")
                operation = "ln";
            else if (s == "10^")
                operation = "10^";
            else
                result = Int32.TryParse(s, out num);
            if (result == true)
            {
                if (operation == "" || operation == "ln" || operation == "10^") 
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    if (rightop == "")
                    {
                        Update_LeftOp();
                        textBlock.Text += rightop;
                        operation = "";
                    }
                    else
                    {

                        Update_RightOp();
                        textBlock.Text += rightop;
                        operation = "";
                        
                    }
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
       
            }
        }
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
        private void Update_LeftOp()
        {
            int num1 = Int32.Parse(leftop);
            switch (operation)
            {
                case "^2":
                    rightop = Convert.ToString(Math.Pow(num1, 2));
                    break;
                case "ln":
                    rightop = Convert.ToString(Math.Log(num1));
                    break;
                case "!":
                    rightop = Convert.ToString(Factorial(num1));
                    break;
                case "10^":
                    rightop = Convert.ToString(Math.Pow(10,num1));
                    break;
            }
        }
        static long Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
    }

}

