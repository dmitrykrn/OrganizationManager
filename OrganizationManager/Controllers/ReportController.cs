
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
        
        // GET: api/<ReportController>
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return null;
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public Report Get(int id)
        {
            return null;
        }

        // POST api/<ReportController>
        [HttpPost]
        public void Post([FromBody] Report report)
        {
            try
            {
                _reportService.CreateReport(report);
            }
            catch (Exception exp)
            {
                throw new Exception("Failed to create report", exp);
            }
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Report value)
        {
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
