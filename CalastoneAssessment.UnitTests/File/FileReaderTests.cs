using CalastoneAssessment.File;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace File
{
    [TestFixture]
    public class FileReaderTests
    {
        private ILogger<FileReader> _mockLogger;
        private FileReader _fileReader;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = Substitute.For<ILogger<FileReader>>();
            _fileReader = new FileReader(_mockLogger);
        }

        [Test]
        public void ReadFile_FileExists_ReturnsFileContent()
        {
            // Arrange
            string filePath = "test.txt";
            string expectedContent = "This is Calastone Assessment!";
            System.IO.File.WriteAllText(filePath, expectedContent);

            // Act
            string result = _fileReader.ReadFile(filePath);

            // Assert
            Assert.AreEqual(expectedContent, result);

            // Clean up
            System.IO.File.Delete(filePath);
        }

        [Test]
        public void ReadFile_FileNotFound_ThrowsException()
        {
            // Arrange
            string filePath = "nonexistent.txt";

            // Act
            var ex = Assert.Throws<Exception>(() => _fileReader.ReadFile(filePath));

            //Assert
            Assert.AreEqual($"File not found: {filePath}", ex.Message);
        }
    }
}
