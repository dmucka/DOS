using DOS_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class BaseQuery
    {
        public static IQueryable<TModel> OrderById<TModel>(this IQueryable<TModel> query) where TModel : IBaseModel
            => query.OrderBy(x => x.Id)
                    .AsQueryable();

        public static Task<TModel> GetByIdAsync<TModel>(this IQueryable<TModel> query, int id) where TModel : IBaseModel
            => query.FirstOrDefaultAsync(x => x.Id == id);

        public static Task<List<TModel>> ToListAsync<TModel>(this IQueryable<TModel> query) where TModel : IBaseModel
            => EntityFrameworkQueryableExtensions.ToListAsync(query);
    }
}
