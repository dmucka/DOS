using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOS_DAL
{
    public partial class DOSContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=DOSDB;Trusted_Connection=True;";

        public DOSContext() : base()
        {
            // empty constructor for scaffolding
        }

        /// <summary>
        /// Commits changes to the database.
        /// </summary>
        /// <returns>True if no errors occured. False otherwise.</returns>
        public async Task<bool> CommitAsync()
        {
            try
            {
                // TODO: https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
                await base.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }

            return false;
        }

        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {
            // set default connection as MS SQL Server
            optionsBuilder.UseSqlServer(_connectionString);

            // enable logging
            optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() }));
        }

        partial void OnModelCreatedImpl(ModelBuilder modelBuilder)
        {
            // singularize column names
            modelBuilder.Entity<Product>()
                     .HasMany<Process>(p => p.Processes)
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
