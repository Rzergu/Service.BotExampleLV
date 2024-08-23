using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.BotExample.Services;
using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.Threading;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Service.BotExample.Interfaces;
using MyJetWallet.Sdk.Service;

namespace Service.BotExample.Client
{
	internal class TelegramClientService : IClientService
	{
		private static ITelegramBotClient _botClient;
		private static ReceiverOptions _receiverOptions;
		private static IUpdateDistributor _updateDistributor;
		private static string _apiKey;
		private static ILogger<TelegramClientService> _logger;

        public TelegramClientService(IUpdateDistributor updateDistributor, ILogger<TelegramClientService> logger)
        {
			_updateDistributor = updateDistributor;
			_logger = logger;
			_apiKey = Program.Settings.BotApiKey;
			_botClient = new TelegramBotClient(_apiKey);
			_receiverOptions = new ReceiverOptions
			{
				AllowedUpdates = new[]
				{
					UpdateType.Message,
					UpdateType.CallbackQuery
				},
				ThrowPendingUpdates = true,
			};
			_botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions);
		}

		public static ITelegramBotClient BotClient()
		{ 
			return _botClient;
		}
		public ITelegramBotClient GetTelegramBot()
		{
			return _botClient;
		}
		public async static Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{

			try
			{
				switch (update.Type)
				{
					case UpdateType.CallbackQuery:
					case UpdateType.Message:
						{
							_logger.LogInformation(update.ToJson());
							await _updateDistributor.GetUpdate(update);
							return;
						}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
		{
			var ErrorMessage = error switch
			{
				ApiRequestException apiRequestException
					=> $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
				_ => error.ToString()
			};

			_logger.LogError(ErrorMessage);
			return Task.CompletedTask;
		}
	}
}
