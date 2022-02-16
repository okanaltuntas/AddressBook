using Report.API.GenericRepository;
using Report.API.Model;
using Report.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Report.API.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Contact> _repo;

        public ContactService(IGenericRepository<Contact> repo)
        {
            _repo = repo;
        }
        public async Task<Contact> AddAsync(Contact entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<Contact> GetAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _repo.GetAsync(filter);
        }

        public async Task<Contact> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<Contact>> ListAsync(Expression<Func<Contact, bool>> filter = null)
        {
            return await _repo.ListAsync(filter);
        }

        public async Task<Contact> UpdateAsync(Contact entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
