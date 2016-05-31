using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;

namespace DevTools.Controllers.Regex
{
    [RoutePrefix("regex")]
    public sealed class RegexController : ApiController
    {
        [HttpGet]
        [Route("test")]
        [ResponseType(typeof(RegexResponse))]
        public IHttpActionResult Test([FromUri] RegexRequest request)
        {
            if (request == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regex = new System.Text.RegularExpressions.Regex(request.Pattern);
            MatchCollection matches = regex.Matches(request.Text);
            if (matches.Count == 0)
                return Ok(new RegexResponse { IsMatch = false });


            var response = new RegexResponse {
                IsMatch = true,
                Matches = matches
                    .Cast<Match>()
                    .Select(m => new GroupCollection(m.Groups
                        .Cast<Group>()
                        .Select(g => g.Value)))
                    .ToList()
            };
            return Ok(response);
        }
    }
}