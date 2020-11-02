using APIDesafio.Application;
using APIDesafio.Application.Interfaces;
using APIDesafio.Application.Interfaces.Mappers;
using APIDesafio.Domain.Core.Interfaces.Repositorys;
using APIDesafio.Domain.Core.Interfaces.Services;
using APIDesafio.Domain.Services;
using APIDesafio.Infrastructure.Application.Mappers;
using APIDesafio.Infrastructure.Data.Repositorys;
using Autofac;

namespace APIDesafio.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceCategoria>().As<IApplicationServiceCategoria>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();            
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<ServiceCategoria>().As<IServiceCategoria>();
            builder.RegisterType<RepositoryCategoria>().As<IRepositoryCategoria>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();            
            builder.RegisterType<MapperCategoria>().As<IMapperCategoria>();
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();            

            #endregion IOC
        }
    }
}
