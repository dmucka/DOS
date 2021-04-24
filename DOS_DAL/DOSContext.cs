using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DOS_DAL
{
    public partial class DOSContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=DOSDB;Trusted_Connection=True;";

        public DOSContext() : base()
        {
            // empty constructor for scaffolding
        }

        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {
            // set default connection as MS SQL Server
            optionsBuilder.UseSqlServer(_connectionString);
        }

        partial void OnModelCreatedImpl(ModelBuilder modelBuilder)
        {
            // singularize column names
            modelBuilder.Entity<global::DOS_DAL.Product>()
                     .HasMany<global::DOS_DAL.Process>(p => p.Processes)
                     .WithMany(p => p.Products)
                     .UsingEntity<Dictionary<string, object>>(
                                "ProductProcess",
                                j => j
                                    .HasOne<Process>()
                                    .WithMany()
                                    .HasForeignKey("ProcessId"),
                                j => j
                                    .HasOne<Product>()
                                    .WithMany()
                                    .HasForeignKey("ProductId"));

            // put initial values into database
            modelBuilder.Seed();
        }
    }
}
