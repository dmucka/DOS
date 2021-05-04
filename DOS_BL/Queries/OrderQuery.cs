using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class OrderQuery
    {
        public static IQueryable<Order> ProductOnly(this IQueryable<Order> query, int? productId) 
            => query.Where(x => !productId.HasValue || x.Product.Id == productId)
                    .AsQueryable();

        public static IQueryable<Order> WithManufacturingSteps(this IQueryable<Order> query) 
            => query.Include(x => x.ManufacturingSteps)
                    .AsQueryable();

        public static IQueryable<Order> WithProducts(this IQueryable<Order> query)
            => query.Include(x => x.Product)
                    .AsQueryable();
    }
}
