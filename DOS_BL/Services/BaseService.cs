using DOS_DAL.Models;
using DOS_DAL;
using DOS_BL.Interfaces;
using DOS_BL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq.Expressions;

namespace DOS_BL.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, DOS_DAL.Interfaces.IBaseModel
    {
        protected readonly DOSContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(DOSContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }


        public IQueryable<T> AsQueryable(bool loadAll = false, bool disableTracking = false, params string[] explicitTypes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            // https://stackoverflow.com/questions/44682555/include-all-navigation-properties-using-reflection-in-generic-repository-using-e
            if (loadAll)
            {
                foreach (var property in _dbContext.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }

            if (explicitTypes is not null)
            {
                foreach (var type in explicitTypes)
                {
                    query = query.Include(type);
                }
            }

            if (disableTracking)
                query = query.AsNoTracking();

            return query;
        }

        public Task<List<T>> GetAllAsync() => EntityFrameworkQueryableExtensions.ToListAsync(_dbContext.Set<T>());

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
