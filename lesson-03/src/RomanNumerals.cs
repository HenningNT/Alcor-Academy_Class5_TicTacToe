namespace src
{
    public class RomanNumerals
    {
        public string Convert(int input)
        {
            var map = new[]
            {
                "",
                "I",
                "II",
                "III",
                "IV",
                "V",
                "VI",
                "VII",
                "VIII",
                "IX",
            };
            if (input < 10)
            {
                return map[input];
            }

            return "X";
        }
    }
}