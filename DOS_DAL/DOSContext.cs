using DOS_DAL.Interfaces;
using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_DAL
{
    public partial class DOSContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=DOSDB;Trusted_Connection=True;";

        public Func<Task<int?>> GetAuthentication { get; private set; }

        public DOSContext() : base()
        {
            // empty constructor for scaffolding
        }

        /// <summary>
        /// Constructor used for authorized commits to the database.
        /// </summary>
        public DOSContext(Func<Task<int?>> authFunction) : base()
        {
            GetAuthentication = authFunction;
        }

        /// <summary>
        /// Commits changes to the database.
        /// </summary>
        /// <returns>True if no errors occured. False otherwise.</returns>
        public async Task<bool> CommitAsync()
        {
            try
            {
                if (GetAuthentication is null)
                    throw new ArgumentNullException(nameof(GetAuthentication));

                int? userId = await GetAuthentication();
                if (userId is null)
                    throw new Exception("You must be logged in to commit to the database.");

                var user = await Users.FindAsync(userId);
                if (user is null)
                    throw new Exception("Your user id is not valid.");

                // implement tracking of timestamps and who edited the records
                // https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
                var createdEntities = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is ITrackCreate && e.State == EntityState.Added);

                var editedEntities = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is ITrackEdit && (e.State == EntityState.Modified || e.State == EntityState.Added));

                foreach (var entry in createdEntities)
                {
                    ((ITrackCreate)entry.Entity).Created = DateTime.Now;
                    ((ITrackCreate)entry.Entity).CreatedBy = user;
                }

                foreach (var entry in editedEntities)
                {
                    ((ITrackEdit)entry.Entity).Edited = DateTime.Now;
                    ((ITrackEdit)entry.Entity).EditedBy = user;
                }

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
