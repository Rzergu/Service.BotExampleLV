using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Service.BotExample.Client;
using Service.BotExample.Helpers;
using Service.BotExample.Interfaces;
using Service.BotExample.Services;

namespace Service.BotExample.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<TelegramClientService>().As<IClientService>().SingleInstance();
			builder.RegisterType<UpdateHelper>().As<IUpdateHelper>().SingleInstance();
			builder.RegisterType<CommandExecutor>().As<ITelegramUpdateListener>().InstancePerDependency();
			builder.RegisterType<UpdateDistributor>().As<IUpdateDistributor>().SingleInstance();
			builder.RegisterType<FunRepo>().As<IFunRepo>().SingleInstance();
		}
	}
}