using NUnit.Framework;
using src;

namespace test
{
    public class UnitTests1
    {
        private FizzBuzzer _fizzer;
        // Return "Fizz" for multiples of 3
        // Return "Buzz" for multiples of 5
        // Return "FizzBuzz" for multiples of 3 and 5
        // Return string value otherwise.
        
        // input 0 to 100

        [SetUp]
        public void Setup()
        {
            _fizzer = new FizzBuzzer();
        }
        
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void ComputeNumberReturnsStringNumber(int value, string expected)
        {
            string result = _fizzer.Compute(value);

            Assert.AreEqual(expected, result);
        }
        
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        public void ComputeMultipleOfThreeReturnsFizz(int value, string expected)
        {
            string result = _fizzer.Compute(value);

            Assert.AreEqual(expected, result);
        }
        
        [TestCase(5, "Buzz")]
        public void ComputeMultipleOfFiveReturnsBuzz(int value, string expected)
        {
            string result = _fizzer.Compute(value);

            Assert.AreEqual(expected, result);
        }
        
        [TestCase(15, "FizzBuzz")]
        [TestCase(90, "FizzBuzz")]
        public void ComputeMultipleOfFiveAndThreeReturnsFizzBuzz(int value, string expected)
        {
            string result = _fizzer.Compute(value);

            Assert.AreEqual(expected, result);
        }
    }
}