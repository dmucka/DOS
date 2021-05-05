using DOS_BL.Interfaces;
using DOS_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class TrackableQuery
    {
        public static IQueryable<TModel> WithEditTracking<TModel>(this IQueryable<TModel> query) where TModel : class, IBaseModel, ITrackEdit
            => query.Include(x => x.EditedBy)
                    .AsQueryable();

        public static IQueryable<TModel> WithCreateTracking<TModel>(this IQueryable<TModel> query) where TModel : class, IBaseModel, ITrackCreate
            => query.Include(x => x.CreatedBy)
                    .AsQueryable();

        public static IQueryable<TModel> WithTracking<TModel>(this IQueryable<TModel> query) where TModel : class, IBaseModel, ITrackCreate, ITrackEdit
            => query.Include(x => x.CreatedBy)
                    .Include(x => x.EditedBy)
                    .AsQueryable();
    }
}
