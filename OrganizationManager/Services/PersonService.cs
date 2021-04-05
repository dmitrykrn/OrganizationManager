using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Services
{
    public class PersonService : IPersonService
    {
        private IRepository _repository;
        private ITaskService _taskService;
        private IReportService _reportService;

        public PersonService(IRepository repo, ITaskService taskService, IReportService reportService)
        {
            _repository = repo;
            _taskService = taskService;
            _reportService = reportService;
        }

        public PersonDetails GetPersonDetails(int personID)
        {
            var personDetails = new PersonDetails();

            var persons = _repository
                .GetPersons();
            
            personDetails.Person = persons
                .FirstOrDefault(person => person.Id == personID);
            
            personDetails.Manager = persons
                .FirstOrDefault(person => person.Id == personDetails.Person.ManagerId);
            
            personDetails.Subordinates = persons
                .Where(person => person.ManagerId == personID);

            personDetails.Tasks = _taskService
                .GetTasks(personID);

            var subordinateIdBulk = personDetails
                .Subordinates
                .Select(person => person.Id);
            
            personDetails.Reports = _reportService
                .GetReports(subordinateIdBulk);

            return personDetails;
        }

        public PersonList GetPersonList()
        {
            var personList = new PersonList();
            personList.Persons = _repository.GetPersons();
            return personList;
        }
    }
}
