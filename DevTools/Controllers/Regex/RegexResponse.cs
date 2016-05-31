using System.Collections.Generic;

namespace DevTools.Controllers.Regex
{
    public sealed class RegexResponse
    {
        public bool IsMatch { get; set; }

        public IReadOnlyList<IReadOnlyList<string>> Matches { get; set; }
    }
}