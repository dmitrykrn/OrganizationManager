using System.Collections.Generic;

namespace OrganizationManager.Domain
{
    public class PersonDetails
    {
        public Person Person { get; set; }
        
        public Person Manager { get; set; }

        public IEnumerable<WorkTask> Tasks { get; set; }
        
        public IEnumerable<Person> Subordinates { get; set; }

        public IEnumerable<Report> Reports { get; set; }
    }
}