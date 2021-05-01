using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;

namespace DOS_BL.Services
{
    public class RoleService : BaseService<Role>
    {
        public RoleService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
