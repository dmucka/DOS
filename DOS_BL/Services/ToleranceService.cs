using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;
using DOS_BL.DataObjects;
using System.Threading.Tasks;
using System.Linq;

namespace DOS_BL.Services
{
    public class ToleranceService : BaseService<Tolerance>
    {
        public ToleranceService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public Task<bool> InsertAsync(CreateToleranceDTO dto)
        {
            var item = _mapper.Map<Tolerance>(dto);
            var product = _dbContext.Products.FirstOrDefault(product => product.Id == dto.ProductId);
            var process = _dbContext.Processes.FirstOrDefault(process => process.Id == dto.ProcessId);

            item.Process = process;
            item.Product = product;

            return InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(EditToleranceDTO dto)
        {
            var tolerance = await GetAsync(dto.Id);
            tolerance = _mapper.Map(dto, tolerance);
            return await UpdateAsync(tolerance);
        }

        public async Task<EditToleranceDTO> GetSafeToleranceAsync(int id)
        {
            return _mapper.Map<EditToleranceDTO>(await GetAsync(id));
        }
    }
}
