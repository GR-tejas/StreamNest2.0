using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using System.IO;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController
    {
        DirectoryService directoryService = new DirectoryService();

        [HttpGet]
        public IActionResult GetFolderContents(String path)
        {
            return directoryService.GetFolderContents(path);
        }
    }
}
