﻿using System.Linq;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var regex = new System.Text.RegularExpressions.Regex(request.Pattern);
            MatchCollection matches = regex.Matches(request.Text);
            if (matches.Count == 0)
                return Ok(new RegexResponse { Match = false });
            var response = new RegexResponse {
                Match = true,
                Groups = matches.Cast<Match>()
                    .Select(m => m.Groups.Cast<Group>().Select(g => g.Value).ToList())
                    .ToList()
            };
            return Ok(response);
        }
    }
}