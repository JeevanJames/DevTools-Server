using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevTools.Controllers.Regex
{
    public sealed class RegexResponse
    {
        public bool IsMatch { get; set; }

        public IReadOnlyList<GroupCollection> Matches { get; set; }
    }

    public sealed class GroupCollection : Collection<string>
    {
        internal GroupCollection(IEnumerable<string> groups)
        {
            foreach (string group in groups)
                Add(group);
        }
    }
}
