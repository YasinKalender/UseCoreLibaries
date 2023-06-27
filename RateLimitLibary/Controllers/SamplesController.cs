using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimitLibary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSamples()
        {

            return Ok(new { Id = 1, Name = "Sample" });
        }

        [HttpGet("{name}")]
        public IActionResult GetSamples(string name)
        {

            return Ok(name);
        }

        [HttpPost]
        public IActionResult SaveSamples()
        {

            return Ok(new { Id = 1, Name = "Sample" });
        }
    }
}
