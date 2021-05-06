using AutoMapper;
using DOS_BL.Interfaces;
using DOS_DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_BL.Services
{
    public abstract class BaseService<TModel> : IBaseService<TModel> where TModel : class, DOS_DAL.Interfaces.IBaseModel
    {
        protected readonly DOSContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(DOSContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public List<TMap> GetMappedList<TMap>(IQueryable<TModel> query)
            where TMap : IEditDTO
        {
            return _mapper.Map<List<TMap>>(query.ToList());
        }

        public async Task<List<TMap>> GetMappedListAsync<TMap>(IQueryable<TModel> query)
            where TMap : IEditDTO
        {
            var list = await EntityFrameworkQueryableExtensions.ToListAsync(query);
            return _mapper.Map<List<TMap>>(list);
        }

        public IQueryable<TModel> AsQueryable(bool loadAll = false, bool disableTracking = false, params string[] explicitTypes)
        {
            var query = _dbContext.Set<TModel>().AsQueryable();

            // https://stackoverflow.com/questions/44682555/include-all-navigation-properties-using-reflection-in-generic-repository-using-e
            if (loadAll)
            {
                foreach (var property in _dbContext.Model.FindEntityType(typeof(TModel)).GetNavigations())
                    query = query.Include(property.Name);
            }

            if (explicitTypes is not null)
            {
                foreach (string type in explicitTypes)
                {
                    query = query.Include(type);
                }
            }

            if (disableTracking)
                query = query.AsNoTracking();

            return query;
        }

        public Task<List<TModel>> GetAllAsync() => EntityFrameworkQueryableExtensions.ToListAsync(_dbContext.Set<TModel>());

        public async Task<TModel> GetAsync(int id) => await _dbContext.Set<TModel>().FindAsync(id);

        public async Task<bool> InsertAsync(TModel item)
        {
            await _dbContext.AddAsync(item);
            return await _dbContext.CommitAsync();
        }

        public async Task<bool> UpdateAsync(TModel item)
        {
            _dbContext.Update(item);
            return await _dbContext.CommitAsync();
        }

        public async Task<bool> UpdateAsync(IEditDTO dto)
        {
            var real = await GetAsync(dto.Id);
            var mapped = _mapper.Map(dto, real);
            _dbContext.Update(mapped);
            return await _dbContext.CommitAsync();
        }

        public async Task<bool> DeleteAsync(TModel item)
        {
            _dbContext.Remove(item);
            return await _dbContext.CommitAsync();
        }
    }
}
