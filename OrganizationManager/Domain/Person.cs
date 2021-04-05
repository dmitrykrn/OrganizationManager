using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Domain
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public PersonType Type { get; set; }
        public long ManagerId { get; set; }
        public string Picture { get; set; }
    }
}
