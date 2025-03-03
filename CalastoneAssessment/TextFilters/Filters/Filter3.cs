using Microsoft.Extensions.Logging;

namespace ConsoleApp1.TextFilters.Filters
{
    public class Filter3 : TextFilter
    {
        private readonly ILogger<Filter3> _logger;

        public Filter3(ILogger<Filter3> logger) : base(logger)
        {
            _logger = logger;
        }

        public override string ApplyFilter(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                    return String.Join(" ", text.Split(' ').Where(word => !word.Contains('t')));
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while applying Filter3.");
            }

            return string.Empty;
        }
    }

}
