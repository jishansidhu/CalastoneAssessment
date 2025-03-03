using ConsoleApp1.TextFilters.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace TextFilter
{
    [TestClass]
    public class Filter3Tests
    {
        private Filter3 filter;
        private ILogger<Filter3> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = Substitute.For<ILogger<Filter3>>();
            filter = new Filter3(_mockLogger);
        }

        [Test]
        public void ApplyFilter_RemovesWordsContainingT()
        {
            string input = "or a watch to take out of it, and burning with curiosity, she ran across the field after it,";
            string expected = "or a of and burning she ran across field";

            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ApplyFilter_KeepsWordsWithoutT()
        {
            string input = "med once considering how";
            string expected = "med once considering how";

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

        [Test]
        public void ApplyFilter_AllWordsContainT_ReturnsEmptyString()
        {
            string input = "tttt ttt";
            string expected = "";

            string result = filter.ApplyFilter(input);

            Assert.AreEqual(expected, result);
        }

    }
}
