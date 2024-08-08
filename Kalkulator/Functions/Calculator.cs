using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Functions
{
    static class Calculator
    {
        static string result;           //przechowuje wynik wyświetlany na kalkulatorze
        public static string Result 
        {
            get { return result; }
            private set
            {
                result = value;
            }
        }
        public static bool dotHasBeenChoosen {  get; set; }     //przechowuje czy przecinek został wybrany

        static Calculator()     //przypisuje poczatkowe wartości po uruchomieniu programu
        {
            Result = default(string);
            dotHasBeenChoosen = false;
        }

        static public void variableReader<T>(T singleSign)      //wpisuje pojedynczy znak do result
        {
            Result += singleSign;

            if (Result[0] == '0' && !dotHasBeenChoosen)
                Result = default(string);
        }
        public static void addDot()     //dodaje kropkę
        {
            if (!dotHasBeenChoosen)
            {
                dotHasBeenChoosen = true;
                if (Result==default)
                    variableReader('0');
                variableReader('.');
            }
        }
        public static void Clear()      //resetuje kalkulator
        {
            Result = default(string);
            dotHasBeenChoosen=false;
        }
        public static void Backspace()      //usuwa ostani znak
        {
            if(Result != default)  //sprawdzenie czy Result nie jest równe 0
            {
                if (Result[Result.Length - 1] == '.')   //sprawdzenie czy usuwanym znakiem nie jest kropka
                    dotHasBeenChoosen = false;
                Result = Result.Remove(Result.Length - 1);  //usunięcie ostatniego znaku
                if (Result.Length == 0)     //jeżeli usunięty znak był pierwszym znakiem cyfry to przypisze domyślną wartość do Result
                    Result = default(string);
            }
        }
    }
}
