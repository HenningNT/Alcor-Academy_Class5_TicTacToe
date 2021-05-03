using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace src
{
    public class RomanNumeralsTPP
    {
        public string Convert(int input)
        {
            var arabicToRoman = new Dictionary<int, string>
            {
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"},
            };
            if (input >= 10)
            {
                var result = arabicToRoman[10];
                var reminder = input - 10;
                while (reminder >= 0)
                {
                    foreach (var arabic in arabicToRoman.Keys)
                    {
                        if (arabic <= reminder)
                        {
                            result += arabicToRoman[arabic];
                        }
                    }
                    
                }

                return result;
            }

            if (input == 9)
            {
                return arabicToRoman[9] + string.Concat(Enumerable.Repeat(arabicToRoman[1], input - 9));
            }

            if (input >= 5)
            {
                return arabicToRoman[5] + string.Concat(Enumerable.Repeat(arabicToRoman[1], input - 5));
            }

            if (input == 4)
            {
                return arabicToRoman[4] + string.Concat(Enumerable.Repeat(arabicToRoman[1], input - 4));
            }

            if (input >= 1)
            {
                return arabicToRoman[1] + string.Concat(Enumerable.Repeat(arabicToRoman[1], input - 1));
            }


            return "";
        }
    }
}