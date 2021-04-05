using System.Collections.Generic;

namespace OrganizationManager.Domain
{
    public interface IRepository
    {
        List<Person> GetPersons();

        IEnumerable<WorkTask> GetTasks();

        IEnumerable<Report> GetReports();
        
        void CreateReport(Report report);
        
        void CreateTask(WorkTask task);
    }
}
