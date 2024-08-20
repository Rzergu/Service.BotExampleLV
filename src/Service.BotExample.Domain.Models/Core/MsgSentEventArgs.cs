using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BotExample.Domain.Models.Core
{
    public delegate Task MsgSendMessagehandler(MsgSentEventArgs eventArgs);
    public class MsgSentEventArgs
    {
        public string MessageFrom { get; set; }
        public string Message { get; set; }
		public long ChatId { get; set; }


	}
}
