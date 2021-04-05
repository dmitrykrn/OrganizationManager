using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Domain
{
    public class PersonList
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
