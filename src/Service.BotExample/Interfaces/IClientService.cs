using Telegram.Bot;
using Telegram.Bot.Types;

namespace Service.BotExample.Services
{
    public interface IClientService
	{
		public ITelegramBotClient GetTelegramBot();
	}

}
