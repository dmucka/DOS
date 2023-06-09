﻿using AutoMapper;
using DOS_BL.DataObjects;
using DOS_BL.Interfaces;
using DOS_BL.Services;
using DOS_DAL.Models;
using LightInject;

namespace DOS_BL
{
    public class BusinessLayerModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // configure automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                .CreateMap<User, CreateUserDTO>()
                .ForPath(s => s.Password, opt => opt.Ignore())
                .ReverseMap()
                .ForPath(s => s.Role.Id, opt => opt.Ignore());

                cfg
                .CreateMap<User, EditUserDTO>()
                .ForPath(s => s.Password, opt => opt.Ignore())
                .ReverseMap()
                .ForPath(s => s.Password, opt => opt.Ignore())
                .ForPath(s => s.Role.Id, opt => opt.Ignore());

                cfg
                .CreateMap<Tolerance, CreateToleranceDTO>()
                .ReverseMap()
                .ForPath(s => s.Process.Id, opt => opt.Ignore())
                .ForPath(s => s.Product.Id, opt => opt.Ignore());

                cfg
                .CreateMap<Tolerance, EditToleranceDTO>()
                .ReverseMap()
                .ForPath(s => s.Process.Id, opt => opt.Ignore())
                .ForPath(s => s.Product.Id, opt => opt.Ignore());

                cfg
                .CreateMap<Product, CreateProductDTO>()
                .ReverseMap()
                .ForPath(s => s.Processes, opt => opt.Ignore());

                cfg
                .CreateMap<Product, EditProductDTO>()
                .ReverseMap()
                .ForPath(s => s.Processes, opt => opt.Ignore());

                cfg
                .CreateMap<Order, CreateOrderDTO>()
                .ReverseMap()
                .ForPath(s => s.Product, opt => opt.Ignore());

                cfg
                .CreateMap<Order, EditOrderDTO>()
                .ReverseMap()
                .ForPath(s => s.Product, opt => opt.Ignore())
                .ForPath(s => s.ManufacturingSteps, opt => opt.Ignore());

                cfg
                .CreateMap<ManufacturingStep, EditManufacturingStepDTO>()
                .ReverseMap()
                .ForPath(s => s.Process, opt => opt.Ignore());
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
