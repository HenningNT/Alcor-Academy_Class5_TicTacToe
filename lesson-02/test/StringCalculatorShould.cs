using System;
using NUnit.Framework;
using src;

namespace test
{
    // 1- Create a string calculator with a method  int Add(string numbers)
    //     The method can take 0, 1 or 2 numbers comma separated and will return their sum. 
    //     For an empty string it has to return 0. 
    //     For example “” will return 0,  “1” will return 1 and “1,2” will return 3.
    // 2- Allow the Add method to handle an undefined amount of numbers
    // 3- Allow the Add method to handle also new lines as separator. 
    //     For example “1\n2,3” will return 6, but “1,\n2” is not a valid input
    // 4- Support different delimiters. To setup the delimiter prefix the input with double forward slash 
    //     [“//”] followed by the delimiter and “\n”. Example: “//;\n1\n2;3” will return 6
    // 5- Throw “negatives not allowed” exception with the list of negative numbers found when input
    //     contains any negative number
    // 6- Ignore numbers bigger than 1000. For example “2,1002” will return 2.
    // 7- Support delimiters of any size. To setup the delimiter prefix the input with
    //     double forward slash followed by the delimiter wrapped in squared brackets and “\n”. 
    //     For example: “//[****]\n1\n2****3” will return 6.
    // 8- Allow multiple delimiters with this format:  
    //     “//[delim1][delim2]\n”. For example: “//[*][%]\n1*2%3” will return 6.
    // 9- Make sure the class supports multiple delimiters of any size, not just one character. 

    public class StringCalculatorShould
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void SetupTest()
        {
            _stringCalculator = new StringCalculator();
        }
        
        [Test]
        public void Return0WhenEmptyString()
        {
            int result = _stringCalculator.Add(string.Empty);
            
            Assert.AreEqual(0, result);
        }
        
        [TestCase("1", 1)]
        [TestCase("42", 42)]
        public void ReturnSameValueWhenOnlyOneDigit(string digit, int expectedValue)
        {
            int result = _stringCalculator.Add(digit);
            
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestCase("0,1", 1)]
        [TestCase("0,1,2", 3)]
        public void ReturnSumOfCommaSeparatedMultipleDigits(string digit, int expectedValue)
        {
            int result = _stringCalculator.Add(digit);
            
            Assert.AreEqual(expectedValue, result);
        }      
        
        [TestCase("0,1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void ReturnSumOfCommaAndNewlineSeparatedDigits(string digit, int expectedValue)
        {
            int result = _stringCalculator.Add(digit);
            
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestCase("1,\n2")]
        [TestCase("1\n,2")]
        public void ThrowExceptionOnInvalidInput(string digit)
        {
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add(digit));
        }
    }
}