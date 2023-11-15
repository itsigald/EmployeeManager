using EM.Domain.Entities;
using EM.Domain.Enums;
using EM.Domain.Helpers;
using EM.Domain.Interfaces;
using EM.Domain.ViewModels.Reports;
using EM.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportsService _reportsSrvice;

        public ReportsController(IReportsService reports)
        {
            _reportsSrvice = (ReportsService)reports;
        }

        [HttpPost]
        public ActionResult Post(AddReportViewModel model)
        {
            _reportsSrvice.Add(new Report()
            {
                Text = model.Text,
                EmployeeId = model.EmployeeId,
                ManagerId = model.ManagerId,
            });

            return Ok();
        }
    }
}
