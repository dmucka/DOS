using DOS_DAL;
using DOS_DAL.Models;
using DOS_BL.Queries;
using AutoMapper;
using DOS_BL.DataObjects;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DOS_BL.Services
{
    public class ToleranceService : BaseService<Tolerance>
    {
        public ToleranceService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public async Task<bool> InsertAsync(CreateToleranceDTO dto)
        {
            var item = _mapper.Map<Tolerance>(dto);
            var product = await _dbContext.Products.FindAsync(dto.ProductId);
            var process = await _dbContext.Processes.FindAsync(dto.ProcessId);

            item.Process = process;
            item.Product = product;

            return await InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(EditToleranceDTO dto)
        {
            var tolerance = await AsQueryable().WithProcesses().WithProducts().GetByIdAsync(dto.Id);
            tolerance = _mapper.Map(dto, tolerance);

            // do not change the entity if we didnt change the id
            if (dto.ProcessId != tolerance.Process.Id)
            {
                var process = await _dbContext.Processes.FindAsync(dto.ProcessId);
                tolerance.Process = process;
            }

            // do not change the entity if we didnt change the id
            if (dto.ProductId != tolerance.Product.Id)
            {
                var product = await _dbContext.Products.FindAsync(dto.ProductId);
                tolerance.Product = product;
            }

            return await UpdateAsync(tolerance);
        }

        public async Task<EditToleranceDTO> GetSafeToleranceAsync(int id)
        {
            return _mapper.Map<EditToleranceDTO>(await AsQueryable().WithProcesses().WithProducts().GetByIdAsync(id));
        }
    }
}
