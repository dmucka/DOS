using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_TEST
{
    internal class TestDbContext : DOS_DAL.DOSContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(Func<Task<int?>> authFunction) : base(authFunction)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }
}
