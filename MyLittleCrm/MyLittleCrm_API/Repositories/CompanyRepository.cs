using MyLittleCrmApi.Models;
using MyLittleCrm_API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLittleCrm_API.Data;
using Microsoft.EntityFrameworkCore;

namespace MyLittleCrm_API.Repositories
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private readonly MyLittleCrmContext _dbContext;
        public CompanyRepository(MyLittleCrmContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Company entity)
        {
            _dbContext.Companies.Remove(entity);
            return await Save();
        }

        public async Task<bool> DeleteAll(IList<Company> entity)
        {
            bool result = false;

            foreach (var c in entity)
            {
                result = await Delete(c);
            }
            return result;
        }

        public async Task<IList<Company>> FindAll()
        {
            return await _dbContext.Companies
                .Include(c => c.Contacts)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Company> FindById(int id)
        {
            return await _dbContext.Companies
                .Include(c => c.Contacts)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CompanyID == id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _dbContext.Companies.AnyAsync(c => c.CompanyID == id);
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Company entity)
        {
            _dbContext.Companies.Update(entity);
            return await Save();
        }
    }
}
