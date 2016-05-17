using System.Web.Http;

namespace DevTools.Controllers
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test/add/{x:int}/{y:int}")]
        public IHttpActionResult Add(int x, int y)
        {
            return Ok(new { Sum = x + y });
        }
    }
}