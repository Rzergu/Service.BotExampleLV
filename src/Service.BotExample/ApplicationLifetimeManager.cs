using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service;
using Service.BotExample.Services;

namespace Service.BotExample
{
    public class ApplicationLifetimeManager : ApplicationLifetimeManagerBase
    {
        private readonly ILogger<ApplicationLifetimeManager> _logger;
        private readonly IClientService _client;

		public ApplicationLifetimeManager(IHostApplicationLifetime appLifetime,
                IClientService clientService,
                ILogger<ApplicationLifetimeManager> logger)
            : base(appLifetime)
        {
            _logger = logger;
            _client = clientService;
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _client.GetTelegramBot();
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
