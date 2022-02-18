using Microsoft.AspNetCore.Mvc;
using Report.API.Services.Abstract;
using System.Linq;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocationReportController : ControllerBase
    {
        private readonly ILocationReportService _locationReportService;
        public LocationReportController(ILocationReportService locationReportService)
        {
            _locationReportService = locationReportService;
        }

        [HttpGet]
        public IActionResult NumberOfPeopleAtLocation()
        {
            var model = _locationReportService.ListAsync(x => !x.IsDeleted).GetAwaiter().GetResult()
                .Select(x => new { x.LocationName, x.ContactCount, x.CreatedDate }).OrderByDescending(x => x.ContactCount);
            return Ok(model);
        }



        [HttpGet]
        public IActionResult NumberOfPhoneAtLocation()
        {
            var model = _locationReportService.ListAsync(x => !x.IsDeleted).GetAwaiter().GetResult()
                .Select(x => new { x.LocationName, x.PhoneNumberCount, x.CreatedDate }).OrderByDescending(x => x.PhoneNumberCount);
            return Ok(model);
        }

    }
}
