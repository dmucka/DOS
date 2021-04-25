using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
