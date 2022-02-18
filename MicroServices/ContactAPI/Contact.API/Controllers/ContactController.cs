using Contact.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(string id)
        {
            return Ok(await _contactService.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.ListAsync(x => !x.IsDeleted));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Contact contact)
        {
            return Ok(await _contactService.AddAsync(contact));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Entities.Contact contact)
        {
            return Ok(await _contactService.UpdateAsync(contact));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _contactService.DeleteAsync(id));
        }

       
    }
}
