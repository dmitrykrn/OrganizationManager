using OrganizationManager.Domain;
using System.Collections.Generic;

namespace OrganizationManager.Domain
{
    public interface IReportService
    {
        void CreateReport(Report report);

        IEnumerable<Report> GetReports(long ownerID);

        IEnumerable<Report> GetReports(IEnumerable<long> ownerIDs);
    }
}