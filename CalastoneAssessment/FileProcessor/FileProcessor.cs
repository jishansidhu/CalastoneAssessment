using CalastoneAssessment.File;
using ConsoleApp1.TextFilters;
using Microsoft.Extensions.Logging;

namespace CalastoneAssessment.Processors
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IEnumerable<ITextFilter> _textFilters;
        private readonly IFileReader _fileReader;
        private readonly ILogger<FileProcessor> _logger;

        public FileProcessor(IEnumerable<ITextFilter> textFilters, IFileReader fileReader,  ILogger<FileProcessor> logger)
        {
            _textFilters = textFilters;
            _fileReader = fileReader;
            _logger = logger;
        }

        public void ProcessFile(string filePath)
        {
            try
            {

                string text = _fileReader.ReadFile(filePath);

                var filters = _textFilters.ToList();
                if (filters.Count > 0)
                {
                    for (int i = 0; i < filters.Count - 1; i++)
                    {
                        filters[i].SetNext(filters[i + 1]);
                    }

                    string result = filters[0].Apply(text);
                    Console.WriteLine(result);
                }
                else
                {
                    _logger.LogInformation("No filters available.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the file.");
            }
            finally
            {
                _logger.LogInformation("File processing has completed...");
            }
        }
    }
}


