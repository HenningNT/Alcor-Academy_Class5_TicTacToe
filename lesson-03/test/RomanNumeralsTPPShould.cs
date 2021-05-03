using NUnit.Framework;
using src;

namespace test
{
    [TestFixture]
    public class RomanNumeralsTPPShould
    {
        
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        public void Return_Roman_Numerable_Given_Arabic(int input, string expected)
        {
            var romanNumerals = new RomanNumeralsTPP();
            
            var result = romanNumerals.Convert(input);
            
            Assert.AreEqual(expected, result);
        }        
        
    }
}