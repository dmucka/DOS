using AutoMapper;
using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class ProcessService : BaseService<Process>
    {
        public ProcessService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
