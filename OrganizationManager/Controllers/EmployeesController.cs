using Microsoft.AspNetCore.Mvc;
using OrganizationManager.Services;
using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace OrganizationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IPersonService _personService;

        public EmployeesController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public PersonList Get()
        {
            var personList = _personService.GetPersonList();
            return personList;
        }

        [HttpGet("{id}")]
        public PersonDetails Get(int id)
        {
            var personDetails = _personService.GetPersonDetails(id);
            return personDetails;
        }
    }
}
