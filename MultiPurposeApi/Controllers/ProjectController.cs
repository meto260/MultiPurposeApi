using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MultiPurposeApi.Controllers {
    [ApiController]
    public class ProjectController : ControllerBase {
        FileDb db;

        [EnableRateLimiting("Api")]
        [HttpGet("api/{project}/{collection}")]
        public IEnumerable<Dictionary<string, string>> Get([FromRoute] string project, [FromRoute] string collection) {
            db = new(project + "_" + collection + ".json");
            return db.Get();
        }

        [EnableRateLimiting("Api")]
        [HttpPost("api/{project}/{collection}")]
        public bool Post([FromBody] object value, [FromRoute] string project, [FromRoute] string collection) {
            db = new(project + "_" + collection + ".json");
            return db.Add(value);
        }
    }
}
