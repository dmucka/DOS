using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class ToleranceQuery
    {
        public static IQueryable<Tolerance> WithProcesses(this IQueryable<Tolerance> query)
            => query.Include(x => x.Process)
                    .AsQueryable();

        public static IQueryable<Tolerance> WithProducts(this IQueryable<Tolerance> query)
            => query.Include(x => x.Product)
                    .AsQueryable();
    }
}
