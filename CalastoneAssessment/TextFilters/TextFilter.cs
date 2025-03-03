using Microsoft.Extensions.Logging;

namespace ConsoleApp1.TextFilters
{
    public abstract class TextFilter : ITextFilter
    {
        protected ITextFilter nextFilter;
        private readonly ILogger<TextFilter> _logger;

        protected TextFilter(ILogger<TextFilter> logger)
        {
            _logger = logger;
        }
        public void SetNext(ITextFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public string Apply(string text)
        {
            try
            {
                string result = ApplyFilter(text);
                if (nextFilter != null)
                {
                    result = nextFilter.Apply(result);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while applying text filter.");
            }

            return string.Empty;
        }

        public abstract string ApplyFilter(string text);
    }
}
