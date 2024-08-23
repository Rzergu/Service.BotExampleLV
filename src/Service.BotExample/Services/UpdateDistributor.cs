using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Service.BotExample.Interfaces;
using Telegram.Bot.Types.Enums;
using Autofac;

namespace Service.BotExample.Services
{
	public class UpdateDistributor : IUpdateDistributor
	{
		private Dictionary<long, ITelegramUpdateListener> listeners;
		private IUpdateHelper _updateHelper;
		private IComponentContext _context;

		public UpdateDistributor(IUpdateHelper updateHelper, IComponentContext context)
		{
			listeners = new Dictionary<long, ITelegramUpdateListener>();
			_updateHelper = updateHelper;
			_context = context;
		}

		public async Task GetUpdate(Update update)
		{
			long chatId = _updateHelper.GetChatIdFromUpdate(update);
			ITelegramUpdateListener listener = listeners.GetValueOrDefault(chatId);
			if (listener is null)
			{
				listener = _context.Resolve<ITelegramUpdateListener>();
				listeners.Add(chatId, listener);
				await listener.GetUpdate(update);
				return;
			}
			await listener.GetUpdate(update);
		}
	}
}
