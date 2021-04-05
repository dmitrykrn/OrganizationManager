using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IHostEnvironment _hostEnv;

        public ImageController(IHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var filePath = Path.Combine(_hostEnv.ContentRootPath, "Data", "Images", name);
            return this.PhysicalFile(filePath, "image/jpg");
        }
    }
}
