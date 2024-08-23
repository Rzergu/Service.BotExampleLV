using Service.BotExample.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

using Service.BotExample.Interfaces;
using System;
using Service.BotExample.Services;

namespace Service.BotExample.Models
{
	public class HaveFunCommand : ICommand, IListener
	{
		public ITelegramBotClient Client => TelegramClientService.BotClient();
		private IUpdateHelper _updateHelper;
		private IFunRepo _funRepo;

		public string Name => "/start";

		public CommandExecutor Executor { get; }

		public HaveFunCommand(CommandExecutor executor, IUpdateHelper updateHelper, IFunRepo funRepo)
		{
			Executor = executor;
			_updateHelper = updateHelper;
			_funRepo = funRepo;
		}


		public async Task Execute(Update update)
		{
			long chatId = update.Message.Chat.Id;
			var keyboard = new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("lets have fun!!", "/start_fun"));
			Executor.StartListen(this);
			await Client.SendTextMessageAsync(chatId, "Hello dear friend!", replyMarkup: keyboard);
		}

		public async Task GetUpdate(Update update)
		{
			long chatId = _updateHelper.GetChatIdFromUpdate(update);
			string msgCommand = _updateHelper.GetMessageCommandByType(update);
			if (msgCommand == null)
				return;

			if (msgCommand == "/start_fun")
			{
				await Client.SendTextMessageAsync(chatId, $"hey hey hey, you are {_funRepo.FunCounter}!!!");
				Executor.StopListen();
			}
		}
	}
}


