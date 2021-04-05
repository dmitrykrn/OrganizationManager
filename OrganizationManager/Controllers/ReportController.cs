
using Microsoft.AspNetCore.Mvc;
using OrganizationManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        
        [HttpPost]
        public void Post([FromBody] Report report)
        {
            try
            {
                _reportService.CreateReport(report);
            }
            catch (Exception exp)
            {
                throw new Exception("Failed to create a report", exp);
            }
        }
    }
}
