using Autofac;
using Service.BotExample.Interfaces;
using Service.BotExample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Service.BotExample.Services
{
	public class CommandExecutor : ITelegramUpdateListener
	{
		private List<ICommand> commands;
		private IListener? listener = null;
		private IUpdateHelper _helper = null;
		private IComponentContext _context = null;
		public CommandExecutor(IUpdateHelper helper, IComponentContext context, IFunRepo funRepo)
		{
			commands = new List<ICommand>()
			{
				new HaveFunCommand(this, helper, funRepo)
			};
			_helper = helper;
			_context = context;
		}

		public async Task GetUpdate(Update update)
		{
			if (listener == null)
			{
				await ExecuteCommand(update);
			}
			else
			{
				await listener.GetUpdate(update);
			}
		}

		private async Task ExecuteCommand(Update update)
		{
			foreach (var command in commands)
			{
				if (command.Name == _helper.GetMessageCommandByType(update))
				{
					await command.Execute(update);
				}
			}
		}

		public void StartListen(IListener newListener)
		{
			listener = newListener;
		}

		public void StopListen()
		{
			listener = null;
		}
	}
}
