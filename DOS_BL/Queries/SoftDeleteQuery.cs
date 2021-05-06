using DOS_DAL.Interfaces;
using System.Linq;

namespace DOS_BL.Queries
{
    public static class SoftDeleteQuery
    {
        public static IQueryable<TModel> WithDeleted<TModel>(this IQueryable<TModel> query, bool withDeleted) where TModel : IBaseModel, ISoftDelete
            => query.Where(x => withDeleted || x.IsDeleted == false)
                    .AsQueryable();
    }
}
