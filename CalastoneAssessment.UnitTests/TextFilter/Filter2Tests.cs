using ConsoleApp1.TextFilters.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TextFilter
{
    [TestClass]
    public class Filter2Tests
    {
        private Filter2 filter;
        private ILogger<Filter2> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = Substitute.For<ILogger<Filter2>>();
            filter = new Filter2(_mockLogger);
        }

        [Test]
        public void ApplyFilter_RemovesWordsWithLessThanThreeCharacters()
        {
            //Arrange
            string input = "but it had no pictures or conversations in it";
            string expected = "but had pictures conversations";

            //Act
            string result = filter.ApplyFilter(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_KeepsWordsWithThreeOrMoreCharacters()
        {
            //Arrange
            string input = "but it had no pictures or conversations in it";
            string expected = "but had pictures conversations";

            //Act
            string result = filter.ApplyFilter(input);

            //Assert
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

        [Test]
        public void ApplyFilter_AllShortWords_ReturnsEmptyString()
        {
            string input = "a an is";
            string expected = "";

            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

    }
}
