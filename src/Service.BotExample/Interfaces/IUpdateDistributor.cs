using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Service.BotExample.Interfaces
{
	public interface IUpdateDistributor
	{
		Task GetUpdate(Update update);
	}
}
