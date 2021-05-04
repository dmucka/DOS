using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Queries
{
    public static class UserQuery
    {
        public static IQueryable<User> WithRoles(this IQueryable<User> query) 
            => query.Include(x => x.Role)
                    .AsQueryable();

        public static Task<User> GetByNameAsync(this IQueryable<User> query, string username)
            => query.FirstOrDefaultAsync(x => x.Username == username);
    }
}
