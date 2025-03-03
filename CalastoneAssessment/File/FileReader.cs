using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneAssessment.File
{
    public class FileReader : IFileReader
    {
        private readonly ILogger<FileReader> _logger;

        public FileReader(ILogger<FileReader> logger)
        {
            _logger = logger;
        }
        public string ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex.Message, "File not found: {FilePath}", filePath);
                throw new Exception($"File not found: {filePath}", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "An unexpected error occurred while reading file: {FilePath}", filePath);
                throw new Exception($"An unexpected error occurred while reading file: {filePath}", ex);
            }
        }
    }
}
