using DOS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class OrderQuery
    {
        public static IQueryable<Order> ProductOnly(this IQueryable<Order> query, int? productId) => query.Where(x => !productId.HasValue || x.Product.Id == productId).AsQueryable();
    }
}
