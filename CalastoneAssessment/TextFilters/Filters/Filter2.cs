using Microsoft.Extensions.Logging;

namespace ConsoleApp1.TextFilters.Filters
{
    public class Filter2 : TextFilter
    {
        private readonly ILogger<Filter2> _logger;

        public Filter2(ILogger<Filter2> logger) : base(logger)
        {
            _logger = logger;
        }

        public override string ApplyFilter(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                    return string.Join(" ", text.Split(' ').Where(word => word.Length >= 3));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while applying Filter2.");
            }

            return string.Empty;
        }
    }
}
