using DOS_DAL.Interfaces;
using DOS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class SoftDeleteQuery
    {
        public static IQueryable<T> WithDeleted<T>(this IQueryable<T> query, bool withDeleted) where T : IBaseModel, ISoftDelete
            => query.Where(x => withDeleted || x.IsDeleted == false).Cast<T>().AsQueryable();
    }
}
