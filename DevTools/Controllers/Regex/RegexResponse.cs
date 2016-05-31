using System.Collections.Generic;

namespace DevTools.Controllers.Regex
{
    public sealed class RegexResponse
    {
        public bool Match { get; set; }

        public IReadOnlyList<IReadOnlyList<string>> Groups { get; set; }
    }
}