namespace src
{
    public class FizzBuzzer
    {
        public string Compute(int value)
        {
            if (value.IsDivisibleBy(3) && 
                value.IsDivisibleBy(5))
            {
                return "FizzBuzz";
            }

            if (value.IsDivisibleBy(3))
            {
                return "Fizz";
            }
            
            if (value.IsDivisibleBy(5))
            {
                return "Buzz";
            }
            
            return value.ToString();
        }
    }

    internal static class IntExtensions
    {
        internal static bool IsDivisibleBy(this int dividend, int divisor)
        {
            return dividend % divisor == 0;
        }
    }
}