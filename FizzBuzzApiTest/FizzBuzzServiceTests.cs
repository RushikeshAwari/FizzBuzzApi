using NUnit.Framework;
using Moq;
using FizzBuzzApi.Services;
using FizzBuzzApi.Services.Division;
using NUnit.Framework.Legacy;

namespace FizzBuzzApiTest
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private Mock<IDivisionService> _mockDivisionService;
        private FizzBuzzService _service;

        // Constants for test data
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";
        private const string DividedTemplate = "Divided {0} by 5 Divided {0} by 3";
        private const string InvalidItem = "Invalid Item";
        private const string ErrorMessage = "Input values not provided";

        private static readonly string[] MultiplesOfThree = { "3", "6", "9" };
        private static readonly string[] MultiplesOfFive = { "5", "10", "20" };
        private static readonly string[] MultiplesOfThreeAndFive = { "15", "30", "45" };
        private static readonly string[] NonMultiplesOfThreeOrFive = { "1", "2", "4" };
        private static readonly string[] EmptyValue = { "" };

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
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 == 0 && i % 5 != 0)))
                                .Returns(Fizz);

            // Act
            var result = _service.ProcessValues(MultiplesOfThree);

            // Assert
            ClassicAssert.AreEqual($"3 = {Fizz}", result.Results[0]);
            ClassicAssert.AreEqual($"6 = {Fizz}", result.Results[1]);
            ClassicAssert.AreEqual($"9 = {Fizz}", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfFive_ReturnsBuzz()
        {
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 5 == 0 && i % 3 != 0)))
                                .Returns(Buzz);

            var result = _service.ProcessValues(MultiplesOfFive);

            ClassicAssert.AreEqual($"5 = {Buzz}", result.Results[0]);
            ClassicAssert.AreEqual($"10 = {Buzz}", result.Results[1]);
            ClassicAssert.AreEqual($"20 = {Buzz}", result.Results[2]);
        }

        [Test]
        public void ProcessValues_MultipleOfThreeAndFive_ReturnsFizzBuzz()
        {
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 == 0 && i % 5 == 0)))
                                .Returns(FizzBuzz);

            var result = _service.ProcessValues(MultiplesOfThreeAndFive);

            ClassicAssert.AreEqual($"15 = {FizzBuzz}", result.Results[0]);
            ClassicAssert.AreEqual($"30 = {FizzBuzz}", result.Results[1]);
            ClassicAssert.AreEqual($"45 = {FizzBuzz}", result.Results[2]);
        }

        [Test]
        public void ProcessValues_NotMultipleOfThreeOrFive_ReturnsNumber()
        {
            _mockDivisionService.Setup(d => d.GetDivisionResult(It.Is<int>(i => i % 3 != 0 && i % 5 != 0)))
                                .Returns<int>(i => string.Format(DividedTemplate, i));

            var result = _service.ProcessValues(NonMultiplesOfThreeOrFive);

            ClassicAssert.AreEqual("1 = Divided 1 by 5 Divided 1 by 3", result.Results[0]);
            ClassicAssert.AreEqual("2 = Divided 2 by 5 Divided 2 by 3", result.Results[1]);
            ClassicAssert.AreEqual("4 = Divided 4 by 5 Divided 4 by 3", result.Results[2]);
        }

        [Test]
        public void ProcessValues_EmptyValue_ReturnsInvalidItem()
        {
            var result = _service.ProcessValues(EmptyValue);

            ClassicAssert.AreEqual($" = {InvalidItem}", result.Results[0]);
        }

        [Test]
        public void ProcessValues_NullValues_ReturnsErrorMessage()
        {
            string[] request = null;

            var result = _service.ProcessValues(request);

            ClassicAssert.AreEqual(ErrorMessage, result.Results[0]);
        }
    }
}
