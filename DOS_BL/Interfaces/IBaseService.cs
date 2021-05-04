using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Interfaces
{
    public interface IBaseService<T> where T : class, DOS_DAL.Interfaces.IBaseModel
    {
        IQueryable<T> AsQueryable(bool loadAll = false, params string[] explicitTypes);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
    }
}
