using Service.BotExample.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Service.BotExample.Helpers
{
	public class UpdateHelper : IUpdateHelper
	{
		public long GetChatIdFromUpdate(Update update)
		{
			switch (update.Type) {

				case UpdateType.Message:
					{
						return update.Message.Chat.Id;
					}
				case UpdateType.CallbackQuery:
					{
						return update.CallbackQuery.Message.Chat.Id;
					}
				default:
					return 0;
			}
		}
		public string GetMessageCommandByType(Update update)
		{
			switch (update.Type)
			{

				case UpdateType.Message:
					{
						return update.Message.Text;
					}
				case UpdateType.CallbackQuery:
					{
						return update.CallbackQuery.Data;
					}
				default:
					return string.Empty;
			}
		}
	}
}
