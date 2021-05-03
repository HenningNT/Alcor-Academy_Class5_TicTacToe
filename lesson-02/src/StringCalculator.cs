using System;
using System.Linq;

namespace src
{
    public class StringCalculator
    {
        public int Add(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return 0;
            }
            
            var separators = new []
            {
                ",",
                "\n"
            };
            
            var values = digits.Split(separators, StringSplitOptions.None);
            
            if (values.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException($"Consecutive separators are not allowed: {digits}");
            }
            
            var sum = values.Sum(int.Parse);
            
            return sum;
        }
    }
}