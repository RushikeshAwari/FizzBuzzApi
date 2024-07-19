using NUnit.Framework;
using Moq;
using FizzBuzzApi.Services;
using FizzBuzzApi.Services.Division;
using FizzBuzzApi.Model;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace FizzBuzzApi.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private Mock<IDivisionService> _mockDivisionService;
        private FizzBuzzService _service;

        [SetUp]
        public void Setup()
        {
            _mockDivisionService = new Mock<IDivisionService>();
            _service = new FizzBuzzService(_mockDivisionService.Object);
        }

        [Test]
        public void ProcessValues_MultipleOfThree_ReturnsFizz()
        {
            // Arrange
            var request = new[] { "3", "6", "9" };
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 == 0 && i % 5 != 0)))
                                .Returns("Fizz");

            // Act
            var result = _service.ProcessValues(request);

            // Assert
            ClassicAssert.AreEqual("3 = Fizz", result.Results[0]);
            ClassicAssert.AreEqual("6 = Fizz", result.Results[1]);
            ClassicAssert.AreEqual("9 = Fizz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfFive_ReturnsBuzz()
        {
            var request = new[] { "5", "10", "20" };
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 5 == 0 && i % 3 != 0)))
                                .Returns("Buzz");

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual("5 = Buzz", result.Results[0]);
            ClassicAssert.AreEqual("10 = Buzz", result.Results[1]);
            ClassicAssert.AreEqual("20 = Buzz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfThreeAndFive_ReturnsFizzBuzz()
        {
            var request = new[] { "15", "30", "45" };
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 == 0 && i % 5 == 0)))
                                .Returns("FizzBuzz");

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual("15 = FizzBuzz", result.Results[0]);
            ClassicAssert.AreEqual("30 = FizzBuzz", result.Results[1]);
            ClassicAssert.AreEqual("45 = FizzBuzz", result.Results[2]);
        }

        [Test]
        public void ProcessValues_NotMultipleOfThreeOrFive_ReturnsNumber()
        {
            var request = new[] { "1", "2", "4" };
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 != 0 && i % 5 != 0)))
                                .Returns<int>(i => $"Divided {i} by 5 Divided {i} by 3");

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual("1 = Divided 1 by 5 Divided 1 by 3", result.Results[0]);
            ClassicAssert.AreEqual("2 = Divided 2 by 5 Divided 2 by 3", result.Results[1]);
            ClassicAssert.AreEqual("4 = Divided 4 by 5 Divided 4 by 3", result.Results[2]);
        }

        [Test]
        public void ProcessValues_EmptyValue_ReturnsInvalidItem()
        {
            var request = new[] { "" };

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual(" = Invalid Item", result.Results[0]);
        }

        [Test]
        public void ProcessValues_NullValues_ReturnsErrorMessage()
        {
            string[] request = null;

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual("Input values not provided", result.Results[0]);
        }
    }
}
