using LightInject;
using DOS_BL.Services;
using DOS_DAL.Models;
using DOS_BL.Interfaces;
using DOS_BL.DataObjects;
using AutoMapper;

namespace DOS_BL
{
    public class BusinessLayerModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // configure automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, CreateUserDTO>().ReverseMap().ForPath(s => s.Role.Id, opt => opt.Ignore());
            });

            serviceRegistry.Register(c => config.CreateMapper());

            // register concrete classes
            serviceRegistry.RegisterScoped<ManufacturingStepService>();
            serviceRegistry.RegisterScoped<OrderService>();
            serviceRegistry.RegisterScoped<ProcessService>();
            serviceRegistry.RegisterScoped<ProductService>();
            serviceRegistry.RegisterScoped<RoleService>();
            serviceRegistry.RegisterScoped<ToleranceService>();
            serviceRegistry.RegisterScoped<UserService>();

            // register the generic interfaces
            serviceRegistry.RegisterScoped<IBaseService<ManufacturingStep>>(s => s.GetInstance<ManufacturingStepService>());
            serviceRegistry.RegisterScoped<IBaseService<Order>>(s => s.GetInstance<OrderService>());
            serviceRegistry.RegisterScoped<IBaseService<Process>>(s => s.GetInstance<ProcessService>());
            serviceRegistry.RegisterScoped<IBaseService<Product>>(s => s.GetInstance<ProductService>());
            serviceRegistry.RegisterScoped<IBaseService<Role>>(s => s.GetInstance<RoleService>());
            serviceRegistry.RegisterScoped<IBaseService<Tolerance>>(s => s.GetInstance<ToleranceService>());
            serviceRegistry.RegisterScoped<IBaseService<User>>(s => s.GetInstance<UserService>());
        }
    }
}
