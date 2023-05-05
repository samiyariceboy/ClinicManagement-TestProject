using Autofac;
using System.Reflection;
using ClinicManagement.Common.Settings;
using ClinicManagement.Entities.Common;
using ClinicManagement.Data.DbContexts.Sql.SqlServer;
using ClinicManagement.Services.Common.Pagination;
using ClinicManagement.Common.InterfaceDependency;
using ClinicManagement.Repositories;
using ClinicManagement.Constant;

namespace ClinicManagement.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        #region NewConfiguration
        public class ServiceModules : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);

                #region new Register services with Autofac
                builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
                builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
                #endregion

                #region Auto Assembly Registeration services with autofac and interface class
                Assembly CommonAssembly = typeof(SiteSettings).Assembly;
                Assembly EntitiesAssembly = typeof(IEntity).Assembly;
                Assembly DataAssembly = typeof(ApplicationDbContext).Assembly;
                Assembly ServicesAssembly = typeof(PageBuilder).Assembly;

                builder.RegisterAssemblyTypes(CommonAssembly, EntitiesAssembly, DataAssembly, ServicesAssembly)
                    .AssignableTo<IScopedDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(CommonAssembly, EntitiesAssembly, DataAssembly, ServicesAssembly)
                    .AssignableTo<ITransientDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                builder.RegisterAssemblyTypes(CommonAssembly, EntitiesAssembly, DataAssembly, ServicesAssembly)
                    .AssignableTo<ISingletonDependency>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
                #endregion
            }
        }

        #endregion
    }
}
