using Contact.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformation : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;
        public ContactInformation(IContactInformationService contactInformationService)
        {
            _contactInformationService =  contactInformationService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactInformation(string id)
        {
            return Ok(await _contactInformationService.GetByIdAsync(id));
        }
   
        [HttpPost]
        public async Task<IActionResult> Create(Entities.ContactInformation contactInformation)
        {
            return Ok(await _contactInformationService.AddAsync(contactInformation));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Entities.ContactInformation contactInformation)
        {
            return Ok(await _contactInformationService.UpdateAsync(contactInformation));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _contactInformationService.DeleteAsync(id));
        }

       
    }
}
