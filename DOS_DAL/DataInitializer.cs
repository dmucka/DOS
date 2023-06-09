using DOS_DAL.Constants;
using DOS_DAL.Hashing;
using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DOS_DAL
{
    internal static class DataInitializer
    {
        /// <summary>
        /// Inserts seed values into the database.
        /// </summary>
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            var adminRole = new Role(RoleConstants.Admin);
            var operatorRole = new Role(RoleConstants.Operator);

            // id property is needed for the scaffolder
            adminRole.Id = 1;
            operatorRole.Id = 2;

            modelBuilder.Entity<Role>().HasData(adminRole, operatorRole);

            // use anonymous class so we can do not need to expose the RoleId property
            modelBuilder.Entity<User>().HasData(new { Id = 1, Username = "admin", Password = PasswordHasher.Hash("admin"), RoleId = adminRole.Id });

            var processes = new[]
            {
                new Process("Vstupn� kontrola"),
                new Process("Medziopera�n� kontrola"),
                new Process("Nap�nac� test"),
                new Process("Kalibr�cia"),
                new Process("V�stupn� kontrola")
            };

            // set index of each process
            int c = 1;
            foreach (var p in processes)
            {
                p.Id = c++;
                modelBuilder.Entity<Process>().HasData(p);
            }
        }
    }
}
