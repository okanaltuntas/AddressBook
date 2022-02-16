using Report.API.GenericRepository;
using Report.API.Model;
using Report.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Report.API.Services.Concrete
{
    public class LocationReportService : ILocationReportService
    {
        private readonly IGenericRepository<NumbersOfAtLocation> _repo;

        public LocationReportService(IGenericRepository<NumbersOfAtLocation> repo)
        {
            _repo = repo;
        }

        public async Task<bool> GenerateLocationReport()
        {
            return true ;
        }


        public async Task<NumbersOfAtLocation> AddAsync(NumbersOfAtLocation entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id);
        }
        public async Task<NumbersOfAtLocation> GetAsync(Expression<Func<NumbersOfAtLocation, bool>> filter)
        {
            return await _repo.GetAsync(filter);
        }

        public async Task<NumbersOfAtLocation> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<NumbersOfAtLocation>> ListAsync(Expression<Func<NumbersOfAtLocation, bool>> filter = null)
        {
            return await _repo.ListAsync(filter);
        }

        public async Task<NumbersOfAtLocation> UpdateAsync(NumbersOfAtLocation entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
