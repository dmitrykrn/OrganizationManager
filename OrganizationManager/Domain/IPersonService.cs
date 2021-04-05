using System.Collections.Generic;

namespace OrganizationManager.Domain
{
    public interface IPersonService
    {
        PersonList GetPersonList();
        
        PersonDetails GetPersonDetails(int id);
    }
}