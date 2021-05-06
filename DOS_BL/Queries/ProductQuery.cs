using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class ProductQuery
    {
        public static IQueryable<Product> WithProcesses(this IQueryable<Product> query)
            => query.Include(x => x.Processes)
                    .AsQueryable();

        public static Task<Product> GetByNameAsync(this IQueryable<Product> query, string name)
            => query.FirstOrDefaultAsync(x => x.Name == name);
    }
}
