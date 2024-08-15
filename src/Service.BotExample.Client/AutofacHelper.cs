using Autofac;
using Service.BotExample.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.BotExample.Client
{
    public static class AutofacHelper
    {
        public static void RegisterBotExampleClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new BotExampleClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
        }
    }
}
