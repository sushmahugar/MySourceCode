using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            string number = Console.ReadLine();
            int ContNum;
            bool IsNum = int.TryParse(number,out ContNum);
            if (IsNum)
            {                
                string Converteddata = Numbertowords.ConvertAmount(ContNum);
                Console.WriteLine("Converted Data : {0}", Converteddata);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please enter correct number");
                Console.ReadLine();
            } 
        }
    }

    public class Numbertowords
    {
        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static string ConvertAmount(int Number)
        {
            string words = null;
            words = convert(Number);
            return words;
       }

        public static string convert(Int64 number)
        {
            if (number < 20)
            {
                return units[number];
            }
            if (number < 100)
            {
                return tens[number / 10] + ((number % 10 > 0) ? " " + convert(number % 10) : " ");
            }
            if (number < 1000)
            {
                return units[number / 100] + " Hunderd" + ((number % 100 > 0) ? " " + convert(number % 100) : " ");
            }
            if (number < 100000)
            {
                return convert(number / 1000) + " Thousand" + ((number % 1000 > 0) ? " " + convert(number % 1000) : " ");
            }

            return convert(number / 100000) + " Lakh" + ((number % 100000 > 0) ? " " + convert(number % 100000) : " ");
        }
    }
}
