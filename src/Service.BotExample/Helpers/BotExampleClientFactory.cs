using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.BotExample.Grpc;

namespace Service.BotExample.Client
{
    [UsedImplicitly]
    public class BotExampleClientFactory: MyGrpcClientFactory
    {
        public BotExampleClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
