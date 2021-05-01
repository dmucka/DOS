using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;

namespace DOS_BL.Services
{
    public class ManufacturingStepService : BaseService<ManufacturingStep>
    {
        public ManufacturingStepService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
