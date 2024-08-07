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
                        wynik.Content = "0";
                        break;
                    }
                case "one":
                    {
                        wynik.Content = "1";
                        break;
                    }
                case "two":
                    {
                        wynik.Content = "2";
                        break;
                    }
                case "three":
                    {
                        wynik.Content = "3";
                        break;
                    }
                case "four":
                    {
                        wynik.Content = "4";
                        break;
                    }
                case "five":
                    {
                        wynik.Content = "5";
                        break;
                    }
                case "six":
                    {
                        wynik.Content = "6";
                        break;
                    }
                case "seven":
                    {
                        wynik.Content = "7";
                        break;
                    }
                case "eight":
                    {
                        wynik.Content = "8";
                        break;
                    }
                case "nine":
                    {
                        wynik.Content = "9";
                        break;
                    }
            }
        }
    }
}
