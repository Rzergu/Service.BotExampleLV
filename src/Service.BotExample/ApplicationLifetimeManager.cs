using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service;
using Service.BotExample.Domain.Interfaces.Services;
using Service.BotExample.Services;

namespace Service.BotExample
{
    public class ApplicationLifetimeManager : ApplicationLifetimeManagerBase
    {
        private readonly ILogger<ApplicationLifetimeManager> _logger;
        private readonly IClientService _clientService; 
        private readonly IResponceService _responceService;

		public ApplicationLifetimeManager(IHostApplicationLifetime appLifetime, IClientService clientService, IResponceService responceService, 
                ILogger<ApplicationLifetimeManager> logger)
            : base(appLifetime)
        {
            _logger = logger;
            _clientService = clientService;
            _responceService = responceService;
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _clientService.StartUp();
            _responceService.SetUpResponce();
        }

        protected override void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
        }

        protected override void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");
        }
    }
}
