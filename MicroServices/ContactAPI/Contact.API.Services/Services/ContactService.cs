using Contact.API.DataAccess.GenericRepository;
using Contact.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact.API.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Entities.Contact> _repo;
        private readonly IQueeService _queeService;


        public ContactService(IGenericRepository<Entities.Contact> repo, IQueeService  queeService)
        {
            _repo = repo;
            _queeService = queeService;
        }
        public async Task<Entities.Contact> AddAsync(Entities.Contact entity)
        {
            _queeService.GenerateReport();
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            _queeService.GenerateReport();
            return await _repo.DeleteAsync(id);
        }

        public async Task<Entities.Contact> GetAsync(Expression<Func<Entities.Contact, bool>> filter)
        {
            return await _repo.GetAsync(filter);
        }

        public async Task<Entities.Contact> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<Entities.Contact>> ListAsync(Expression<Func<Entities.Contact, bool>> filter = null)
        {
            return await _repo.ListAsync(filter);
        }

        public async Task<Entities.Contact> UpdateAsync(Entities.Contact entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
