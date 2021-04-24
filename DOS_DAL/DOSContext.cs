using Microsoft.EntityFrameworkCore;
using System;

namespace DOS_DAL
{
    public class DOSContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=DOSDB;Trusted_Connection=True;";

        public DOSContext(DbContextOptions<DOSContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
