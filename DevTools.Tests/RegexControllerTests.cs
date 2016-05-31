using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using DevTools.Controllers.Regex;

using Xunit;

namespace DevTools.Tests
{
    public sealed class RegexControllerTests
    {
        private readonly RegexController _controller;

        public RegexControllerTests()
        {
            _controller = new RegexController {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
            };
        }

        [Theory]
        [InlineData(@"^(\d{5})-(\d{4})$", "12345-1234", new[] { "12345-1234", "12345", "1234" })]
        [InlineData(@"ABC(\d+)", "Testing ABC87394 More Tests", new[] { "ABC87394", "87394" })]
        [InlineData(@"\w+", "Testing ABC87394 More Tests", new[] { "Testing" })]
        public async Task Can_match_valid_zipcode_pattern(string pattern, string sampleText, string[] expectedGroups)
        {
            var request = new RegexRequest { Pattern = pattern, Text = sampleText };

            IHttpActionResult response = _controller.Test(request);
            var cts = new CancellationTokenSource();
            HttpResponseMessage message = await response.ExecuteAsync(cts.Token);

            Assert.Equal(HttpStatusCode.OK, message.StatusCode);

            var content = await message.Content.ReadAsAsync<RegexResponse>(cts.Token);
            Assert.True(content.Match);
            Assert.Equal(expectedGroups.Length, content.Groups.Count);
            //for (int i = 0; i < expectedGroups.Length; i++)
            //    Assert.Equal(expectedGroups[i], content.Groups);
        }
    }
}
