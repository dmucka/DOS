using LightInject;
using DOS_BL.Services;

namespace DOS_BL
{
    public class BusinessLayerModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ManufacturingStepService>();
            serviceRegistry.Register<OrderService>();
            serviceRegistry.Register<ProcessService>();
            serviceRegistry.Register<ProductService>();
            serviceRegistry.Register<RoleService>();
            serviceRegistry.Register<ToleranceService>();
            serviceRegistry.Register<UserService>();
        }
    }
}
