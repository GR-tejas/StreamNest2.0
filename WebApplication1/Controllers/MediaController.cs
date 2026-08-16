using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly MediaService _mediaService;

        public MediaController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("{*path}")]
        public IActionResult GetMedia(string path) {
            var result = _mediaService.GetMedia(path);

            if(result == null)
            {
                return NotFound();
            }

            return PhysicalFile(
                result.FilePath,
                result.ContentType,
                enableRangeProcessing: true
            );
        }
    }
}
