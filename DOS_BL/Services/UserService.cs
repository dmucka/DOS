using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
