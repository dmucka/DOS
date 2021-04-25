using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class ToleranceService : BaseService<Tolerance>
    {
        public ToleranceService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
