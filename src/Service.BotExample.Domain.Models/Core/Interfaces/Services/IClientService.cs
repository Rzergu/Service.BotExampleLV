using Service.BotExample.Domain.Models;
using Service.BotExample.Domain.Models.Core;
using System.Threading.Tasks;

namespace Service.BotExample.Services
{
	public interface IClientService
	{
		public void StartUp();
		public Task SendMsgToClientAsync(IHelloMessage message, long chatId);
		public event MsgSendMessagehandler? MsgSend;
	}

}
