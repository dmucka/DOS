using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Interfaces
{
    public interface IBaseService<TModel> 
        where TModel : class, DOS_DAL.Interfaces.IBaseModel
    {
        List<TMap> GetMappedList<TMap>(IQueryable<TModel> query) where TMap : IEditDTO;
        Task<List<TMap>> GetMappedListAsync<TMap>(IQueryable<TModel> query) where TMap : IEditDTO;
        IQueryable<TModel> AsQueryable(bool loadAll = false, bool disableTracking = false, params string[] explicitTypes);
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetAsync(int id);
        Task<bool> InsertAsync(TModel item);
        Task<bool> UpdateAsync(TModel item);
        Task<bool> UpdateAsync(IEditDTO dto);
        Task<bool> DeleteAsync(TModel item);
    }
}
