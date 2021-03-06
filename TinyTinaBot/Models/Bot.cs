﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TinyTinaBot.Models.Commands;

namespace TinyTinaBot.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<ICommand> commandsList;

        public static IReadOnlyList<ICommand> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<ICommand>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new Text());
            
            //TODO: Add more commands

            botClient = new TelegramBotClient(BotSettings.Key);
            var hook = string.Format(BotSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            
            return botClient;
        }
    }
}