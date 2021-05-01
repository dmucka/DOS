using DOS_DAL;
using DOS_DAL.Models;
using AutoMapper;

namespace DOS_BL.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }
    }
}
