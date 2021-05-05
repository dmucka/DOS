using DOS_BL.Interfaces;
using DOS_DAL.Interfaces;

namespace DOS_PL.Data
{
    public partial class MappedServiceAdaptor<TModel, TMap> 
        where TModel : class, IBaseModel
        where TMap : class, IEditDTO
    {
    }
}
