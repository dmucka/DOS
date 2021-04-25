using DOS_DAL;
using DOS_DAL.Models;

namespace DOS_BL.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(DOSContext dbcontext) : base(dbcontext)
        {
        }
    }
}
