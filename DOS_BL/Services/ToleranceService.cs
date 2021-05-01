using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;

namespace DOS_BL.Services
{
    public class ToleranceService : BaseService<Tolerance>
    {
        public ToleranceService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
