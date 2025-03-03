using CalastoneAssessment.File;
using ConsoleApp1.TextFilters.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TextFilter
{
    [TestClass]
    public class Filter1Tests
    {
        private Filter1 filter;
        private ILogger<Filter1> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = Substitute.For<ILogger<Filter1>>();
            filter = new Filter1(_mockLogger);
        }

        [Test]
        public void ApplyFilter_OddLength_FilterWordsWithVowelInMiddle()
        {
            //Arrange
            string input = "clean currently";
            string expected = "";

            //Act
            string result = filter.ApplyFilter(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_EvenLength_FilterWordsWithVowelInMiddle()
        {
            //Arrange
            string input = "what";
            string expected = "";

            //Act
            string result = filter.ApplyFilter(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_KeepsWordsWithoutVowelInMiddle()
        {
            string input = "the rather";
            string expected = "the rather";

            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_EmptyString_ReturnsEmptyString()
        {
            string input = "";
            string expected = "";
            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_NullString_ReturnsEmptyString()
        {
            string input = null;
            string expected = "";

            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

    }
}
