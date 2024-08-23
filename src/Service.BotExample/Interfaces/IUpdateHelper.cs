using Telegram.Bot.Types;

namespace Service.BotExample.Interfaces
{
	public interface IUpdateHelper
	{
		long GetChatIdFromUpdate(Update update);
		string GetMessageCommandByType (Update update);
	}
}
