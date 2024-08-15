using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.BotExample.Grpc;
using Service.BotExample.Grpc.Models;
using Service.BotExample.Settings;

namespace Service.BotExample.Services
{
    public class HelloService: IHelloService
    {
        private readonly ILogger<HelloService> _logger;
        private readonly IOmgService _omgService;

        public HelloService(ILogger<HelloService> logger, IOmgService omgService)
        {
            _logger = logger;
            _omgService = omgService;
        }

        public Task<HelloMessage> SayHelloAsync(HelloRequest request)
        {
            _logger.LogInformation("Hello from {name}", request.Name);
            
            _omgService.Omg();

            return Task.FromResult(new HelloMessage
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
