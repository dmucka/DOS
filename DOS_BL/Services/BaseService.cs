using DOS_DAL.Models;
using DOS_DAL;
using DOS_BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DOS_BL.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, DOS_DAL.Interfaces.IBaseModel
    {
        protected readonly DOSContext _dbContext;

        public BaseService(DOSContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public IQueryable<T> AsQueryable() => _dbContext.Set<T>().AsQueryable();

        public Task<List<T>> GetAllAsync() => _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<bool> InsertAsync(T item)
        {
            await _dbContext.AddAsync(item);
            return await _dbContext.CommitAsync();
        }

        public async Task<bool> UpdateAsync(T item)
        {
            _dbContext.Update(item);
            return await _dbContext.CommitAsync();
        }

        public async Task<bool> DeleteAsync(T item)
        {
            _dbContext.Remove(item);
            return await _dbContext.CommitAsync();
        }
    }
}
