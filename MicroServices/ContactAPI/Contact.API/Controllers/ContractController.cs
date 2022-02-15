using Contact.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContractController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.ListAsync(x => !x.IsDeleted));
        }
    }
}
