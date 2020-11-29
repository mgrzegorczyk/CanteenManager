using System.Reflection;
using Autofac;
using CanteenManager.Infrastructure.Commands;

namespace CanteenManager.Infrastructure.IoC.Modules
{
    public class AppCommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(AppCommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IAppCommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<AppCommandDispatcher>()
                .As<IAppCommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}