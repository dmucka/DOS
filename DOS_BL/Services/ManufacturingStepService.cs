using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class ManufacturingStepService : BaseService<ManufacturingStep>
    {
        public ManufacturingStepService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
