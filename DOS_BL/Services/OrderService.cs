using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;
using System.Threading.Tasks;
using DOS_BL.DataObjects;
using System;
using System.Linq;
using DOS_BL.Queries;
using Microsoft.EntityFrameworkCore;

namespace DOS_BL.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public async Task<bool> InsertAsync(CreateOrderDTO dto)
        {
            var item = _mapper.Map<Order>(dto);

            var product = await _dbContext.Products.WithProcesses().GetByIdAsync(dto.ProductId.Value);
            item.Product = product;

            foreach (var process in product.Processes)
            {
                item.ManufacturingSteps.Add(new ManufacturingStep(DateTime.Now, process, item));
            }

            item.Status = product.Processes.FirstOrDefault()?.Name;

            return await InsertAsync(item);
        }

        public Task<bool> SoftDeleteAsync(Order order)
        {
            order.IsDeleted = true;
            return UpdateAsync(order);
        }
    }
}
