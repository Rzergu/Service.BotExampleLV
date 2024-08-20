using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.BotExample.Domain.Models.Core;
using Service.BotExample.Services;
using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.Threading;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Microsoft.AspNetCore.Hosting;
using Service.BotExample.Domain.Models;

namespace Service.BotExample.Client
{
	internal class TelegramClientService : IClientService
	{
		public event MsgSendMessagehandler MsgSend;
		private ITelegramBotClient _botClient;
		private ReceiverOptions _receiverOptions;
		private string _apiKey;

        public TelegramClientService(string apiKey)
        {
			_apiKey = apiKey;
		}
		public void StartUp()
		{
			_botClient = new TelegramBotClient(_apiKey); 
			_receiverOptions = new ReceiverOptions
			{
				AllowedUpdates = new[]
				{
					UpdateType.Message,
				},
				ThrowPendingUpdates = true,
			};
			_botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions);
		}
		public async Task SendMsgToClientAsync(IHelloMessage message, long chatId)
		{
			await _botClient.SendTextMessageAsync(chatId, message.Message);
		}
		protected virtual async Task OnMsgSent(MsgSentEventArgs eventArgs)
		{
			MsgSendMessagehandler? msgSentHandler = MsgSend;
			if (msgSentHandler != null)
			{
				await msgSentHandler(eventArgs);
			}
		}
		public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{

			try
			{
				switch (update.Type)
				{
					case UpdateType.Message:
						{
							var eventArgs = new MsgSentEventArgs
							{
								Message = update.Message?.Text,
								MessageFrom = update.Message.From.FirstName,
								ChatId = update.Message.Chat.Id,
							};
							OnMsgSent(eventArgs);
							Console.WriteLine("Msg!");
							return;
						}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public  Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
		{
			var ErrorMessage = error switch
			{
				ApiRequestException apiRequestException
					=> $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
				_ => error.ToString()
			};

			Console.WriteLine(ErrorMessage);
			return Task.CompletedTask;
		}
	}
}
