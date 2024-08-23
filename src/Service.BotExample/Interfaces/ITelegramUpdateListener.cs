using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Service.BotExample.Interfaces
{
	public interface ITelegramUpdateListener
	{
		Task GetUpdate(Update update);
	}
}
