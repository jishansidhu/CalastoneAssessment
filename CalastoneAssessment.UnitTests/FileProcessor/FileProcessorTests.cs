using CalastoneAssessment.File;
using CalastoneAssessment.Processors;
using ConsoleApp1.TextFilters;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    [TestFixture]
    public class FileProcessorTests
    {
        private IFileReader _mockFileReader;
        private ILogger<FileProcessor> _mockLogger;
        private IEnumerable<ITextFilter> _mockTextFilters;
        private FileProcessor _fileProcessor;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = Substitute.For<IFileReader>();
            _mockLogger = Substitute.For<ILogger<FileProcessor>>();
            _mockTextFilters = new List<ITextFilter>
        {
            Substitute.For<ITextFilter>(),
            Substitute.For<ITextFilter>(),
            Substitute.For<ITextFilter>()
        };
            _fileProcessor = new FileProcessor(_mockTextFilters, _mockFileReader, _mockLogger);
        }

        [Test]
        public void ProcessFile_FileExists_AppliesFilters()
        {
            // Arrange
            string filePath = "test.txt";
            string fileContent = "This is a test file.";
            _mockFileReader.ReadFile(filePath).Returns(fileContent);

            // Act
            _fileProcessor.ProcessFile(filePath);

            // Assert
            _mockTextFilters.ElementAt(0).Received(1).Apply(fileContent);
            _mockTextFilters.ElementAt(0).Received(1).SetNext(_mockTextFilters.ElementAt(1));
            _mockTextFilters.ElementAt(1).Received(1).SetNext(_mockTextFilters.ElementAt(2));
        }

        [Test]
        public void ProcessFile_NoFiltersAvailable_LogsMessage()
        {
            // Arrange
            var emptyFilters = new List<ITextFilter>();
            _fileProcessor = new FileProcessor(emptyFilters, _mockFileReader, _mockLogger);
            string filePath = "test.txt";
            _mockFileReader.ReadFile(filePath).Returns("Content");

            // Act
            _fileProcessor.ProcessFile(filePath);

            // Assert
            _mockLogger.Received(1).LogInformation("No filters available.");
        }

        [Test]
        public void ProcessFile_ExceptionThrown_LogsError()
        {
            // Arrange
            string filePath = "test.txt";
            _mockFileReader.ReadFile(filePath).Returns(x => { throw new Exception("Test exception"); });

            // Act
            _fileProcessor.ProcessFile(filePath);

            // Assert
            _mockLogger.Received(1).LogError(Arg.Any<Exception>(), "An error occurred while processing the file.");
        }
    }
}
