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
        public static IQueryable<TModel> WithDeleted<TModel>(this IQueryable<TModel> query, bool withDeleted) where TModel : IBaseModel, ISoftDelete
            => query.Where(x => withDeleted || x.IsDeleted == false)
                    .AsQueryable();
    }
}
