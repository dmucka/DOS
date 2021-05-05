using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class ManufacturingStepQuery
    {
        public static IQueryable<ManufacturingStep> ForOrder(this IQueryable<ManufacturingStep> query, int orderId)
            => query.Where(x => x.OrderId == orderId)
                    .AsQueryable();

        public static IQueryable<ManufacturingStep> WithProcesses(this IQueryable<ManufacturingStep> query)
            => query.Include(x => x.Process)
                    .AsQueryable();
    }
}
