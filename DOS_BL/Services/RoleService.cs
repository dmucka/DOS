﻿using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class RoleService : BaseService<Role>
    {
        public RoleService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
