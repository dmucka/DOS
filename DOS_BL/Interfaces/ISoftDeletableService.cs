using DOS_DAL.Interfaces;
using System.Threading.Tasks;

namespace DOS_BL.Interfaces
{
    public interface ISoftDeletableService<TModel> : IBaseService<TModel> where TModel : class, IBaseModel, ISoftDelete
    {
        Task<bool> SoftDeleteAsync(TModel model);
        Task<bool> SoftDeleteAsync<TMap>(TMap dto) where TMap : IEditDTO;
    }
}
