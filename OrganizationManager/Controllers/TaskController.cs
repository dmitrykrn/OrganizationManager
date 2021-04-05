using Microsoft.AspNetCore.Mvc;
using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<WorkTask> Get()
        {
            return null;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public WorkTask Get(int id)
        {
            return null;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] WorkTask task)
        {
            try
            {
                _taskService.CreateTask(task);
            }
            catch (Exception exp)
            {
                throw new Exception("Failed to create a task", exp);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
