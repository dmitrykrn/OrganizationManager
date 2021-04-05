using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Services
{
    public class TaskService : ITaskService
    {
        IRepository _repository;

        public TaskService(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateTask(WorkTask task)
        {
            task.AssignDate = DateTime.Now.ToString("yyyy-MM-dd");
            _repository.CreateTask(task);
        }

        public IEnumerable<WorkTask> GetTasks(long ownerId)
        {
            return _repository
                .GetTasks()
                .Where(task => task.OwnerId == ownerId);
        }
    }
}
