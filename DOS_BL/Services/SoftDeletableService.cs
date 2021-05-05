using AutoMapper;
using DOS_BL.Interfaces;
using DOS_DAL;
using DOS_DAL.Interfaces;
using System.Threading.Tasks;

namespace DOS_BL.Services
{
    public abstract class SoftDeletableService<TModel> : BaseService<TModel>, ISoftDeletableService<TModel>
        where TModel : class, IBaseModel, ISoftDelete
    {
        public SoftDeletableService(DOSContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
        }

        public Task<bool> SoftDeleteAsync(TModel model)
        {
            model.IsDeleted = true;
            return UpdateAsync(model);
        }

        public async Task<bool> SoftDeleteAsync<TMap>(TMap dto)
            where TMap : IEditDTO
        {
            var real = await GetAsync(dto.Id);
            var mapped = _mapper.Map(dto, real);
            mapped.IsDeleted = true;

            return await UpdateAsync(mapped);
        }
    }
}
