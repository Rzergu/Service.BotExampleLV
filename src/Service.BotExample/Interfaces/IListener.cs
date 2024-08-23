using Service.BotExample.Services;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Service.BotExample.Interfaces
{
	public interface IListener
	{
		public async Task GetUpdate(Update update) { }

		public CommandExecutor Executor { get; }
	}
}
