using System.Runtime.Serialization;
using Service.BotExample.Domain.Models;

namespace Service.BotExample.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}