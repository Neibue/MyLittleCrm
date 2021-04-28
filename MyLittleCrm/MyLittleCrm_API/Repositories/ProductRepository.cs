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
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly MyLittleCrmContext _dbContext;
        public ProductRepository(MyLittleCrmContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
            return await Save();
        }

        public async Task<bool> DeleteAll(IList<Product> entity)
        {
            bool result = false;
            foreach (var p in entity)
            {
                result = await Delete(p);
            }
            return result;
        }

        public async Task<IList<Product>> FindAll()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> FindById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _dbContext.Products.AnyAsync(p => p.ProductID == id);
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            return await Save();
        }
    }
}
