using DOS_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class BaseQuery
    {
        public static IQueryable<T> OrderById<T>(this IQueryable<T> query) where T : IBaseModel
            => query.OrderBy(x => x.Id)
                    .AsQueryable();

        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> query) where T : IBaseModel
            => EntityFrameworkQueryableExtensions.ToListAsync(query);
    }
}
