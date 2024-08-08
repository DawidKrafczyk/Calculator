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
                Result = Result.TrimStart('0');
        }
        public static void addDot()     //dodaje kropkę
        {
            if (!dotHasBeenChoosen)
            {
                dotHasBeenChoosen = true;
                if (Result==null)
                    variableReader('0');
                variableReader('.');
            }
        }
        public static void Clear()      //resetuje kalkulator
        {
            Result = default(string);
            dotHasBeenChoosen=false;
        }
    }
}
