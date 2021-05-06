using AutoMapper;
using DOS_BL.DataObjects;
using DOS_BL.Queries;
using DOS_DAL;
using DOS_DAL.Models;
using System.Threading.Tasks;

namespace DOS_BL.Services
{
    public class ProductService : SoftDeletableService<Product>
    {
        public ProductService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public async Task<bool> InsertAsync(CreateProductDTO dto)
        {
            var item = _mapper.Map<Product>(dto);

            foreach (var processId in dto.ProcessIds)
            {
                var process = await _dbContext.Processes.FindAsync(processId);
                item.Processes.Add(process);
            }

            return await InsertAsync(item);
        }

        public async Task<bool> UpdateAsync(EditProductDTO dto)
        {
            var product = await AsQueryable().WithProcesses().GetByIdAsync(dto.Id);
            product = _mapper.Map(dto, product);

            return await UpdateAsync(product);
        }

        public async Task<EditProductDTO> GetSafeProductAsync(int id)
        {
            return _mapper.Map<EditProductDTO>(await AsQueryable().WithProcesses().GetByIdAsync(id));
        }
    }
}
