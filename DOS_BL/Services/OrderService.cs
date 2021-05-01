using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;

namespace DOS_BL.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
