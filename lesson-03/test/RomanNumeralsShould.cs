using NUnit.Framework;
using src;

namespace test
{
    /*
     * Given a positive integer number write a function returning its Roman numeral representation as a String.
     *  	Thousands 	Hundreds 	Tens 	Units
        1 	M 	        C 	        X 	    I
        2 	MM 	        CC 	        XX 	    II
        3 	MMM 	    CCC 	    XXX 	III
        4 		        CD 	        XL 	    IV
        5 		        D 	        L 	    V
        6 		        DC 	        LX 	    VI
        7 		        DCC 	    LXX 	VII
        8 		        DCCC 	    LXXX 	VIII
        9 		        CM 	        XC 	    IX
        
        39 = XXX + IX = XXXIX.
        246 = CC + XL + VI = CCXLVI.
        789 = DCC + LXXX + IX = DCCLXXXIX.
        2,421 = MM + CD + XX + I = MMCDXXI.
     */
    [TestFixture]
    public class RomanNumeralsShould
    {
        [TestCase(0, "")]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        public void Return_Single_Roman_Numerable_when_given_Single_Digit(int input, string expected)
        {
            var romanNumerals = new RomanNumerals();
            
            var result = romanNumerals.Convert(input);
            
            Assert.AreEqual(expected, result);
        }        
        
        [TestCase(10, "X")]
        public void Return_Roman_Numerable_when_given_Two_Digits(int input, string expected)
        {
            var romanNumerals = new RomanNumerals();
            
            var result = romanNumerals.Convert(input);
            
            Assert.AreEqual(expected, result);
        }
    }
}