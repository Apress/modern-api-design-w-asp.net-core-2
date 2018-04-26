using Microsoft.AspNetCore.Mvc;

namespace Versioning.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/awesome")]
    public class AwesomeV1Controller : Controller
    {
        public IActionResult Get() => Ok("Version 1");
    }
    [ApiVersion("2.0")]
    [Route("api/awesome")]
    public class AwesomeV2Controller : Controller
    {
        public IActionResult Get() => Ok($"Version 2 - {Request.HttpContext.Connection.Id}");
    }
}
