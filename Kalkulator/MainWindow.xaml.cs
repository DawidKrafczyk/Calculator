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
using Kalkulator.Functions;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;        //rzutowanie klikniętego przycisku na przycisk
            switch (clickedButton.Name)                     //sprawdzenie, który przycisk został kliknięty
            {
                case "zero":
                    {
                        Calculator.variableReader(0);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "one":
                    {
                        Calculator.variableReader(1);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "two":
                    {
                        Calculator.variableReader(2);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "three":
                    {
                        Calculator.variableReader(3);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "four":
                    {
                        Calculator.variableReader(4);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "five":
                    {
                        Calculator.variableReader(5);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "six":
                    {
                        Calculator.variableReader(6);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "seven":
                    {
                        Calculator.variableReader(7);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "eight":
                    {
                        Calculator.variableReader(8);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "nine":
                    {
                        Calculator.variableReader(9);
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "dot":
                    {
                        Calculator.addDot();
                        wynik.Content = Calculator.Result;
                        break;
                    }
                case "clear":
                    {
                        Calculator.Clear();
                        wynik.Content = Calculator.Result;
                        break;
                    }
            }
        }
    }
}
