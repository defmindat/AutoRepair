using System.Linq;

namespace Application
{
    public class Globals
    {
        public static bool IsAnyNullOrEmpty(params string[] tokens)
        {
            return tokens.Any(string.IsNullOrWhiteSpace);
        }
    }
}