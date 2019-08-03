﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TinyTinaBot.Models
{
    public class TransferEnCommand : ICommand
    {
        public string Name => @"/en";

        public bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoEN(message.Text), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
