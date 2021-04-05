using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Services
{
    public class ReportService : IReportService
    {
        private IRepository _repository;

        public ReportService(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateReport(Report report)
        {
            report.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this._repository.CreateReport(report);
        }

        public IEnumerable<Report> GetReports(long ownerID)
        {
            return GetReports(new long[] { ownerID });
        }

        public IEnumerable<Report> GetReports(IEnumerable<long> ownerIDs)
        {
            return _repository
                .GetReports()
                .Where(report => ownerIDs.Contains(report.OwnerId));
        }
    }
}
