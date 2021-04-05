using Microsoft.AspNetCore.Mvc;
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
        // GET: api/<ImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ImageController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Images", name);
            return this.PhysicalFile(filePath, "image/png");
        }

        // POST api/<ImageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
