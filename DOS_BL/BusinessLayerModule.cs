using LightInject;
using DOS_BL.Services;
using DOS_DAL.Models;
using DOS_BL.Interfaces;

namespace DOS_BL
{
    public class BusinessLayerModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterScoped<ManufacturingStepService>();
            serviceRegistry.RegisterScoped<OrderService>();
            serviceRegistry.RegisterScoped<ProcessService>();
            serviceRegistry.RegisterScoped<ProductService>();
            serviceRegistry.RegisterScoped<RoleService>();
            serviceRegistry.RegisterScoped<ToleranceService>();
            serviceRegistry.RegisterScoped<UserService>();

            serviceRegistry.RegisterScoped<IBaseService<ManufacturingStep>>(s => s.GetInstance<ManufacturingStepService>());
            serviceRegistry.RegisterScoped<IBaseService<Order>>(s => s.GetInstance<OrderService>());
            serviceRegistry.RegisterScoped<IBaseService<Process>>(s => s.GetInstance<ProcessService>());
            serviceRegistry.RegisterScoped<IBaseService<Product>>(s => s.GetInstance<ProductService>());
            serviceRegistry.RegisterScoped<IBaseService<Role>>(s => s.GetInstance<RoleService>());
            serviceRegistry.RegisterScoped<IBaseService<Tolerance>>(s => s.GetInstance<ToleranceService>());
            serviceRegistry.RegisterScoped<IBaseService<User>>(s => s.GetInstance<UserService>());

            //serviceRegistry.RegisterScoped<IBaseService<ManufacturingStep>, ManufacturingStepService>();
            //serviceRegistry.RegisterScoped<IBaseService<Order>, OrderService>();
            //serviceRegistry.RegisterScoped<IBaseService<Process>, ProcessService>();
            //serviceRegistry.RegisterScoped<IBaseService<Product>, ProductService>();
            //serviceRegistry.RegisterScoped<IBaseService<Role>, RoleService>();
            //serviceRegistry.RegisterScoped<IBaseService<Tolerance>, ToleranceService>();
            //serviceRegistry.RegisterScoped<IBaseService<User>, UserService>();
        }
    }
}
