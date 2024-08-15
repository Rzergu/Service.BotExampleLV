using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Service.BotExample.Services;

namespace Service.BotExample.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OmgService>().As<IOmgService>().SingleInstance();
        }
    }
}