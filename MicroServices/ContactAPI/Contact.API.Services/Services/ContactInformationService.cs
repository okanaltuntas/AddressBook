using Contact.API.DataAccess.GenericRepository;
using Contact.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact.API.Services.Services
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IGenericRepository<Entities.ContactInformation> _repo;

        public ContactInformationService(IGenericRepository<Entities.ContactInformation> repo)
        {
            _repo = repo;
        }
        public async Task<Entities.ContactInformation> AddAsync(Entities.ContactInformation entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<Entities.ContactInformation> GetAsync(Expression<Func<Entities.ContactInformation, bool>> filter)
        {
            return await _repo.GetAsync(filter);
        }

        public async Task<Entities.ContactInformation> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<Entities.ContactInformation>> ListAsync(Expression<Func<Entities.ContactInformation, bool>> filter = null)
        {
            return await _repo.ListAsync(filter);
        }

        public async Task<Entities.ContactInformation> UpdateAsync(Entities.ContactInformation entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
