using Microsoft.Extensions.Logging;

namespace ConsoleApp1.TextFilters.Filters
{
    public class Filter1 : TextFilter
    {
        private readonly ILogger<Filter1> _logger;

        public Filter1(ILogger<Filter1> logger):base(logger)
        {
            _logger = logger;
        }

        public override string ApplyFilter(string text)
        {
            if (!string.IsNullOrEmpty(text))
                return string.Join(" ", text.Split(' ').Where(word => !HasVowelInMiddle(word)));

            return string.Empty;
        }

        private bool HasVowelInMiddle(string word)
        {
            try
            {
                if (!string.IsNullOrEmpty(word))
                {
                    int middle = word.Length / 2;
                    if (word.Length % 2 == 0)
                    {
                        return IsVowel(word[middle - 1]) || IsVowel(word[middle]);
                    }
                    else
                    {
                        return IsVowel(word[middle]);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while applying Filter1.");
                return false;
            }
        }

        private bool IsVowel(char c)
        {
            return "aeiou".Contains(char.ToLower(c));
        }
    }

}
