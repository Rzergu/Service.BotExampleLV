using System.Runtime.Serialization;

namespace Service.BotExample.Grpc.Models
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
		[DataMember(Order = 2)]
		public string Msg { get; set; }
	}
}