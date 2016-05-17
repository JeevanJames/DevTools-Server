using System.ComponentModel.DataAnnotations;

namespace DevTools.Controllers.Regex
{
    public sealed class RegexRequest
    {
        [Required]
        public string Pattern { get; set; }

        [Required]
        public string Text { get; set; }
    }
}