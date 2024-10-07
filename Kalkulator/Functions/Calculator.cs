using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Functions
{
    static class Calculator
    {
        static string result;          //przechowuje wynik wyświetlany na kalkulatorze
        public static string Result 
        {
            get { return result; }
            private set
            {
                result = value;
            }
        }
        static long tmpVariableLong { get; set; }   //przechowuje pierwszą zmienną typu long przed dokonaniem operacji
        static double tmpVariableDouble { get; set; }   //przechowuje pierwszą zmienną typu double przed dokonaniem operacji
        static char choosenOperation {  get; set; }     //przechowuje wybraną operację
        static bool dotHasBeenChoosen {  get; set; }     //przechowuje czy przecinek został wybrany

        static Calculator()     //przypisuje poczatkowe wartości po uruchomieniu programu
        {
            Result = default(string);
            dotHasBeenChoosen = false;
            tmpVariableLong = default;
            tmpVariableDouble = default;
            choosenOperation = default;
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
            tmpVariableLong = default;
            tmpVariableDouble = default;
            choosenOperation = default;
        }
        public static void Backspace()      //usuwa ostani znak
        {
            if(Result != default)  //sprawdzenie czy Result nie jest równe 0
            {
                if (Result[Result.Length - 1] == '.')   //sprawdzenie czy usuwanym znakiem nie jest kropka
                    dotHasBeenChoosen = false;
                Result = Result.Remove(Result.Length - 1);  //usunięcie ostatniego znaku
                if (Result.Length == 0 || (Result.Length == 1 && Result[0] == '0'))     //jeżeli usunięty znak był pierwszym znakiem cyfry lub po usunięciu zostanie 0 jako pierwsze to przypisze domyślną wartość do Result
                    Result = default(string);
            }
        }
        public static void ChooseOperation(char operation)  //wybór operacji
        {
            if(Result != default)   //zabezpiecznie, aby była wybrana pierwsza zmienna
            {
                if (choosenOperation == default)   //zabezpieczenie podczas zmiany operacji (żeby nie była przypisywana zmienna drugi raz)
                    if (dotHasBeenChoosen)
                    {
                        tmpVariableDouble = convertToDouble(Result);
                        Result = default;
                        dotHasBeenChoosen = default;
                    }
                    else if (!dotHasBeenChoosen)
                    {
                        tmpVariableLong = long.Parse(Result);
                        Result = default;
                    }
                switch (operation)      //wybór operacji
                {
                    case '+':
                        choosenOperation = '+';
                        break;
                    case '-':
                        choosenOperation = '-';
                        break;
                    case '*':
                        choosenOperation = '*';
                        break;
                    case '/':
                        choosenOperation = '/';
                        break;
                }
            }
        }
        public static void ExecuteOperation()
        {
            /*
             * metoda wybieracjąca odpowiednie zmienne do wykonania działania
             */
            if (dotHasBeenChoosen)
            {
                if (tmpVariableDouble != default)
                {
                    //sytuacja gdy pierwsza i druga zmienna jest double
                    Result = (string)execute(tmpVariableDouble, convertToDouble(Result));
                }
                else
                {
                    //sytuacja gdy mamy tylko druga zmienna typu double
                    Result = (string)execute((double)tmpVariableLong, convertToDouble(Result));
                }
            }
            else
            {
                if(tmpVariableDouble != default)
                {
                    //sytuacja gdy pierwsza zmienna jest typu double
                    Result = execute(tmpVariableDouble, convertToDouble(Result));
                }
                else
                {
                    //sytuacja gdy obie zmienne sa typu long
                    Result = execute(tmpVariableLong, long.Parse(Result));
                }
            }
            dotHasBeenChoosen = Result.Contains('.') || Result.Contains(',');
            tmpVariableLong = default;
            tmpVariableDouble = default;
            choosenOperation = default;
        }
        private static dynamic execute(dynamic variable1, dynamic variable2)
        {
            /*
             * metoda wykonująca działąnie
             */
            dynamic tmpResult;
            switch (choosenOperation)
            {
                case '+':
                    {
                        tmpResult = variable1 + variable2;
                        break;
                    }
                case '-':
                    {
                        tmpResult = variable1 - variable2;
                        break;
                    }
                case '*':
                    {
                        tmpResult = variable1 * variable2;
                        break;
                    }
                case '/':
                    {
                        tmpResult = variable1 / (double)variable2;
                        break;
                    }
                default:
                    {
                        tmpResult = default;
                        break;
                    }
            }
            object tmpResultOBJ = tmpResult;
            return tmpResultOBJ.ToString();
        }
        public static double convertToDouble (string result)
        {
            /*
             * metoda konwertująca string na double- Parsowanie nie zadziałało bo czasami nie wykrywało przecinka
             */
            string beforeDot, afterDot;
            string[] commaIndex;
            double tmpValueBeforeDot, tmpValueAfterDot;
            if (result.Contains('.'))
            {
                commaIndex = result.Split('.');
                beforeDot = commaIndex[0];
                afterDot = commaIndex[1];
            }
            else if (result.Contains(","))
            {
                commaIndex = result.Split(',');
                beforeDot = commaIndex[0];
                afterDot = commaIndex[1];
            }
            else
            {
                return double.Parse(result);
            }
            tmpValueBeforeDot = char.GetNumericValue(beforeDot[0]);
            tmpValueAfterDot = char.GetNumericValue(afterDot[0]) * 0.1;
            for (int i = 1; i < beforeDot.Length; i++) 
            { 
                tmpValueBeforeDot = (tmpValueBeforeDot * 10) + char.GetNumericValue(beforeDot[i]);
            }
            for (int i = 1; i < afterDot.Length; i++)
            {
                tmpValueAfterDot = tmpValueAfterDot + (char.GetNumericValue(afterDot[i]) * Math.Pow(0.1, i+1));
            }
            return tmpValueBeforeDot + tmpValueAfterDot;
        }
    }
}
