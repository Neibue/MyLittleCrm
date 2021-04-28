using Microsoft.EntityFrameworkCore;
using MyLittleCrmApi.Models;
using MyLittleCrm_API.Contracts;
using MyLittleCrm_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleCrm_API.Repositories
{
    public class ContactRepository : IBaseRepository<Contact>
    {
        private readonly MyLittleCrmContext _dbContext;
        public ContactRepository(MyLittleCrmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Contact entity)
        {
            await _dbContext.Contacts.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Contact entity)
        {
            _dbContext.Remove(entity);
            return await Save();
        }

        public async Task<bool> DeleteAll(IList<Contact> entity)
        {
            bool result = false;

            foreach (var c in entity)
            {
                result = await Delete(c);
            }

            return result;
        }

        public async Task<IList<Contact>> FindAll()
        {
            return await _dbContext.Contacts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Contact> FindById(int id)
        {
            return await _dbContext.Contacts
                .Include(c => c.Company)
                .FirstOrDefaultAsync(c => c.ContactID == id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _dbContext.Contacts.AnyAsync(c => c.ContactID == id);
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Contact entity)
        {
            _dbContext.Contacts.Update(entity);
            return await Save();
        }
    }
}
