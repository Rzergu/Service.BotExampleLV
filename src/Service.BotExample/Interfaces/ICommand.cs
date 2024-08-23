using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Service.BotExample.Interfaces
{
	public interface ICommand
	{
		public ITelegramBotClient Client { get; }

		public string Name { get; }

		public async Task Execute(Update update) { }
	}
}
