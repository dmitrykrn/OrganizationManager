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
    }
}
