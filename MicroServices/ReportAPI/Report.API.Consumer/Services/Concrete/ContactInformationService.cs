using Report.API.GenericRepository;
using Report.API.Model;
using Report.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Report.API.Services.Services
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IGenericRepository<ContactInformation> _repo;

        public ContactInformationService(IGenericRepository<ContactInformation> repo)
        {
            _repo = repo;
        }
        public async Task<ContactInformation> AddAsync(ContactInformation entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<ContactInformation> GetAsync(Expression<Func<ContactInformation, bool>> filter)
        {
            return await _repo.GetAsync(filter);
        }

        public async Task<ContactInformation> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<ContactInformation>> ListAsync(Expression<Func<ContactInformation, bool>> filter = null)
        {
            return await _repo.ListAsync(filter);
        }

        public async Task<ContactInformation> UpdateAsync(ContactInformation entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
