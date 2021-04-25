using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOS_DAL.Hashing;
using DOS_DAL.Models;
using DOS_DAL.Constants;

namespace DOS_DAL
{
    internal static class DataInitializer
    {
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
        }
    }
}
