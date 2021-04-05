using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Domain
{
    public interface ITaskService
    {
        void CreateTask(WorkTask task);

        IEnumerable<WorkTask> GetTasks(long ownerId);
    }
}
