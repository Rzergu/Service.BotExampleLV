using System.ServiceModel;
using System.Threading.Tasks;
using Service.BotExample.Grpc.Models;

namespace Service.BotExample.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}