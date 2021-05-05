using DOS_DAL.Interfaces;

namespace DOS_PL.Data
{
    public partial class ProjectedServiceAdaptor<TModel, TProject> 
        where TModel : class, IBaseModel
        where TProject : class
    {
    }
}
