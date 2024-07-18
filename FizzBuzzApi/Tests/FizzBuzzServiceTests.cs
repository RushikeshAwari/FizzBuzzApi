using NUnit.Framework;
using Moq;
using FizzBuzzApi.Services;
using FizzBuzzApi.Model;

namespace FizzBuzzApi.Tests
{
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _service;

        [SetUp]
        public void Setup()
        {
            _service = new FizzBuzzService();
        }

        [Test]
        public void ProcessValues_MultipleOfThree_ReturnsFizz()
        {
            var request = new FizzBuzzValues { Values = new[] { 3, 6, 9 } };
            var result = _service.ProcessValues(request.Values);

            Assert.Equals("Fizz", result.Results[0]);
            Assert.Equals("Fizz", result.Results[1]);
            Assert.Equals("Fizz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfFive_ReturnsBuzz()
        {
            var request = new FizzBuzzValues { Values = new[] { 5, 10, 20 } };
            var result = _service.ProcessValues(request.Values);

            Assert.Equals("Buzz", result.Results[0]);
            Assert.Equals("Buzz", result.Results[1]);
            Assert.Equals("Buzz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfThreeAndFive_ReturnsFizzBuzz()
        {
            var request = new FizzBuzzValues { Values = new[] { 15, 30, 45 } };
            var result = _service.ProcessValues(request.Values);

            Assert.Equals("FizzBuzz", result.Results[0]);
            Assert.Equals("FizzBuzz", result.Results[1]);
            Assert.Equals("FizzBuzz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_NotMultipleOfThreeOrFive_ReturnsNumber()
        {
            var request = new FizzBuzzValues { Values = new[] { 1, 2, 4 } };
            var result = _service.ProcessValues(request.Values);

            Assert.Equals("1", result.Results[0]);
            Assert.Equals("2", result.Results[1]);
            Assert.Equals("4", result.Results[2]);
        }
    }
}
