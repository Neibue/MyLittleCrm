using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLittleCrmApi.Models;
using MyLittleCrm_API.Contracts;
using MyLittleCrm_API.Data;


namespace MyLittleCrm_API.Repositories
{
    public class QuoteRepository : IBaseRepository<Quote>
    {
        private readonly MyLittleCrmContext _dbContext;
        public QuoteRepository(MyLittleCrmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Quote entity)
        {
            await _dbContext.Quotes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Quote entity)
        {
            _dbContext.Quotes.Remove(entity);
            return await Save();
        }

        public async Task<bool> DeleteAll(IList<Quote> entity)
        {
            bool result = false;
            foreach (var q in entity)
            {
                result = await Delete(q);
            }
            return result;
        }

        public async Task<IList<Quote>> FindAll()
        {
            return await _dbContext.Quotes
                .Include(q => q.QuoteLines)
                    .ThenInclude(ql => ql.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Quote> FindById(int id)
        {
            return await _dbContext.Quotes
                .Include(q => q.QuoteLines)
                    .ThenInclude(ql => ql.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.QuoteID == id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _dbContext.Quotes.AnyAsync(q => q.QuoteID == id);
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Quote entity)
        {
            _dbContext.Quotes.Update(entity);
            return await Save();
        }
    }
}
