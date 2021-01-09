using Autofac;
using CanteenManager.Infrastructure.Extensions;
using CanteenManager.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace CanteenManager.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        public SettingsModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
            
            builder.RegisterInstance(configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}