using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Data
{
    public class InMemoryRepo : IRepository
    {
        private long _reportId;
        private long _taskId;

        private List<Person> _persons;
        private List<Report> _reports;
        private List<WorkTask> _tasks;

        public InMemoryRepo()
        {
            _reportId = 0;
            _taskId = 0;

            CreatePersons();
            CreateReports();
            CreateTasks();
        }

        private void CreatePersons()
        {
            _persons = new List<Person>
            {
                new Person {
                    Id = 0,
                    FirstName = "James",
                    LastName = "Smith",
                    ManagerId = -1,
                    Position = "CEO",
                    Type = PersonType.Manager,
                    Picture = "JamesSmith.jpg"
                },

                new Person {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Johnson",
                    ManagerId = 0,
                    Position = "Group Lead",
                    Type = PersonType.Manager,
                    Picture = "JohnJohnson.jpg"
                },
                new Person {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "Brown",
                    ManagerId = 0,
                    Position = "Group Lead",
                    Type = PersonType.Manager,
                    Picture = "MaryBrown.jpg"
                },

                new Person {
                    Id = 3,
                    FirstName = "Robert",
                    LastName = "Williams",
                    ManagerId = 1,
                    Position = "Team Lead",
                    Type = PersonType.Manager,
                    Picture = "RobertWilliams.jpg",
                },
                new Person {
                    Id = 4,
                    FirstName = "Patricia",
                    LastName = "Jones",
                    ManagerId = 1,
                    Position = "Team Lead",
                    Type = PersonType.Manager,
                    Picture = "PatriciaJones.jpg",
                },

                new Person {
                    Id = 5,
                    FirstName = "Michael",
                    LastName = "Miller",
                    ManagerId = 3,
                    Position = "Developer",
                    Type = PersonType.Employee,
                    Picture = "MichaelMiller.jpg",
                },
                new Person {
                    Id = 6,
                    FirstName = "Jennifer",
                    LastName = "Davis",
                    ManagerId = 3,
                    Position = "Developer",
                    Type = PersonType.Employee,
                    Picture = "JenniferDavis.jpg",
                },
                new Person {
                    Id = 7,
                    FirstName = "William",
                    LastName = "Garcia",
                    ManagerId = 4,
                    Position = "Developer",
                    Type = PersonType.Employee,
                    Picture = "WilliamGarcia.jpg",
                },
                new Person {
                    Id = 8,
                    FirstName = "Linda",
                    LastName = "Wilson",
                    ManagerId = 4,
                    Position = "Developer",
                    Type = PersonType.Employee,
                    Picture = "LindaWilson.jpg",

                },
            };

        }

        private void CreateReports()
        {
            _reports = new List<Report>();

            foreach (Person person in this._persons)
            {
                if (person.ManagerId > 0)
                {
                    CreateReport(new Report
                    {
                        OwnerId = person.Id,
                        Text = $"Test report of {person.FirstName} {person.LastName}",
                        Date = "02-04-2021"
                    });
                }
            }
        }

        private void CreateTasks()
        {
            _tasks = new List<WorkTask>();
            foreach (Person person in _persons)
            {
                if (person.ManagerId < 0)
                    continue;

                for (int i = 0; i < 3; i++)
                {
                    var task = new WorkTask
                    {
                        OwnerId = person.Id,
                        AssignDate = "01-04-2021",
                        DueDate = "10-04-2021",
                        Text = "Task text"
                    };
                    CreateTask(task);
                }
            }
        }

        public List<Person> GetPersons()
        {
            return this._persons;
        }

        public IEnumerable<Report> GetReports()
        {
            return this._reports;
        }

        public IEnumerable<WorkTask> GetTasks()
        {
            return this._tasks;
        }

        public void CreateReport(Report report)
        {
            report.Id = this._reportId++;
            _reports.Add(report);
        }

        public void CreateTask(WorkTask task)
        {
            task.Id = _taskId++;
            _tasks.Add(task);
        }
    }
}
