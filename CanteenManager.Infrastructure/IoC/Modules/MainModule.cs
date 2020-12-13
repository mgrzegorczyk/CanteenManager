using Autofac;
using AutoMapper;
using CanteenManager.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace CanteenManager.Infrastructure.IoC.Modules
{
    public class MainModule : Autofac.Module
    {
        private readonly IConfiguration configuration;
        public MainModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance<IMapper>(AutoMapperConfig.Initialize());
            builder.RegisterModule<AppCommandModule>();
            builder.RegisterModule(new SettingsModule(configuration));
        }
    }
}