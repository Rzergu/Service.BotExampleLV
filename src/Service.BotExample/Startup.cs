using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using MyJetWallet.Sdk.GrpcMetrics;
using MyJetWallet.Sdk.GrpcSchema;
using MyJetWallet.Sdk.Service;
using Prometheus;
using ProtoBuf.Grpc.Server;
using Service.BotExample.Grpc;
using Service.BotExample.Modules;
using Service.BotExample.Services;
using SimpleTrading.BaseMetrics;
using SimpleTrading.ServiceStatusReporterConnector;
using Service.BotExample.Client;
using Service.BotExample.Domain.Interfaces.Services;

namespace Service.BotExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureJetWallet<ApplicationLifetimeManager>(Program.Settings.ZipkinUrl);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureJetWallet(env, endpoints =>
            {
                endpoints.MapGrpcSchema<HelloService, IHelloService>();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureJetWallet();
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<ServiceModule>();

			var factory = new BotExampleClientFactory("http://localhost:80/");

			builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
			builder.RegisterBotExampleClient(Program.Settings.BotApiKey);
			builder.RegisterType<ResponceService>().As<IResponceService>().SingleInstance();

		}
	}
}
