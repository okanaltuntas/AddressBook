using Microsoft.AspNetCore.Mvc;
using Report.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationReportController : ControllerBase
    {
        private readonly ILocationReportService _locationReportService;
        public LocationReportController(ILocationReportService locationReportService)
        {
            _locationReportService = locationReportService;
        }
        public async Task<IActionResult> NumberOfPeopleAtLocationAsync()
        {
            return Ok();
        }
    }
}
