using AutoMapper;
using DOS_BL.DataObjects;
using DOS_BL.Queries;
using DOS_DAL;
using DOS_DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DOS_BL.Services
{
    public class OrderService : SoftDeletableService<Order>
    {
        public OrderService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public async Task<bool> InsertAsync(CreateOrderDTO dto)
        {
            var item = _mapper.Map<Order>(dto);

            var product = await _dbContext.Products.WithProcesses().GetByIdAsync(dto.ProductId.Value);
            if (product is null)
                return false;

            item.Product = product;

            foreach (var process in product.Processes)
            {
                item.ManufacturingSteps.Add(new ManufacturingStep(DateTime.Now, item.Id, process, item));
            }

            item.Status = product.Processes.FirstOrDefault()?.Name;

            return await InsertAsync(item);
        }
    }
}
