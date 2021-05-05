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
                item.ManufacturingSteps.Add(new ManufacturingStep(DateTime.Now, item.Id, process, item));
            }

            item.Status = product.Processes.FirstOrDefault()?.Name;

            return await InsertAsync(item);
        }

        public async Task<bool> SoftDeleteAsync(Order order)
        {
            order.IsDeleted = true;

            // TODO: refactor using DTO
            var tracked = await AsQueryable().GetByIdAsync(order.Id);
            if (tracked is not null)
            {
                _dbContext.Entry(tracked).State = EntityState.Detached;
                _dbContext.Entry(order).State = EntityState.Modified;
                var ok = await _dbContext.CommitAsync();

                if (tracked is not null)
                {
                    _dbContext.Entry(tracked).State = EntityState.Detached;
                    _dbContext.Entry(order).State = EntityState.Detached;
                    _dbContext.SaveChanges();
                }

                return ok;
            }

            return false;
        }
    }
}
