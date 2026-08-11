using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok (new
            {
                name = "Media Server",
                status = "Running"
            });
        }
    }
}
