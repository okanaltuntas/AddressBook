using Report.API.GenericRepository;
using Report.API.Model;
using Report.API.Services.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Report.API.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace Report.API.Services.Concrete
{
    public class LocationReportService : ILocationReportService
    {
        private readonly IGenericRepository<NumbersOfAtLocation> _repo;
        private readonly IGenericRepository<ContactInformation> _repoContactInformation;
        private readonly IGenericRepository<Contact> _repoContact;

        public LocationReportService(IGenericRepository<NumbersOfAtLocation> repo, IGenericRepository<Contact> repoContact, IGenericRepository<ContactInformation> repoContactInformation)
        {
            _repo = repo;
            _repoContactInformation = repoContactInformation;
            _repoContact = repoContact;
        }

        public async Task<bool> GenerateLocationReport()
        {

            try
            {
                var result = await _repoContact.Queryable().
                    Where(x => x.ContactInformations.Any(q => q.Type == InformationType.Location))
                   .Select(x => new
                   {
                       Location = x.ContactInformations.First(q => q.Type == InformationType.Location).Value,
                       PhoneNumberCount = x.ContactInformations.Count(q => q.Type == InformationType.PhoneNumber)
                   }).ToListAsync();

                var newNumbersOfAtLocations = result
                    .GroupBy(x => x.Location)
                    .Select(g => new NumbersOfAtLocation
                    {
                        LocationName = g.Key,
                        ContactCount = g.Count(),
                        PhoneNumberCount = g.Sum(x => x.PhoneNumberCount),
                    }).ToList();


                var oldnumbersOfAtLocations = await _repo.ListAsync(x => !x.IsDeleted);

                var addResult = _repo.AddBulk(newNumbersOfAtLocations);
                if (addResult)
                    _repo.DeleteBulk(oldnumbersOfAtLocations);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

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
