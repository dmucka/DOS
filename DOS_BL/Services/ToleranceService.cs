using AutoMapper;
using DOS_BL.DataObjects;
using DOS_BL.Queries;
using DOS_DAL;
using DOS_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<EditToleranceDTO> GetSafeToleranceAsync(string valueName, int productId, int processId)
        {
            var tolerances = await AsQueryable().Where(x => x.ValueName == valueName && x.Product.Id == productId && x.Process.Id == processId).ToListAsync();

            if (tolerances.Count > 1)
                throw new Exception($"There are multiple tolerances for column {valueName}, product {productId}, process {processId}.");
            else if (tolerances.Count == 0)
                return null;

            return _mapper.Map<EditToleranceDTO>(tolerances.First());
        }
    }
}
