using Autofac;
using Service.BotExample.Grpc;
using Service.BotExample.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

// ReSharper disable UnusedMember.Global

namespace Service.BotExample.Client
{
    public static class AutofacHelper
    {
        public static void RegisterBotExampleClient(this ContainerBuilder builder, string apiKey)
        {
			builder.RegisterInstance(new TelegramClientService(apiKey)).As<IClientService>().SingleInstance();
        }
    }
}
