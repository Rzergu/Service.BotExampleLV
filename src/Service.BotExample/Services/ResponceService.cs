using Service.BotExample.Domain.Interfaces.Services;
using Service.BotExample.Domain.Models.Core;
using Service.BotExample.Grpc;
using Service.BotExample.Grpc.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;

namespace Service.BotExample.Services
{
	public class ResponceService : IResponceService
	{
		internal IHelloService _helloService;
		internal IClientService _clientService;
        public ResponceService(IHelloService helloService, IClientService clientService)
        {
            _helloService = helloService;
			_clientService = clientService;
        }
        public void SetUpResponce()
		{
			_clientService.MsgSend += _clientService_MsgSend;
		}

		private async Task _clientService_MsgSend(MsgSentEventArgs eventArgs)
		{
			try
			{
				var res = await _helloService.SayHelloAsync(new HelloRequest() { Msg = eventArgs.Message, Name = eventArgs.MessageFrom });
				if (res != null)
				{
					await _clientService.SendMsgToClientAsync(res, eventArgs.ChatId);
				}
			}
			catch (Exception e)
			{
				var ErrorMessage = e switch
				{
					_ => e.ToString()
				};

				Console.WriteLine(ErrorMessage);
			}
		}
	}
}
