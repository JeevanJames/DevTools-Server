using System.Collections.Generic;

namespace DevTools.Controllers.Regex
{
    public sealed class RegexResponse
    {
        public bool Match { get; set; }

        public List<string> Groups { get; set; }
    }
}