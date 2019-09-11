using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TinyTinaBot.Models
{
    public class AnyText : ICommand
    {
        public string Name => @"/text";

        public bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return (message.Text[0] != '/');
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var keybord = new ReplyKeyboardMarkup(new KeyboardButton[] { new KeyboardButton("на русский"), new KeyboardButton("на английский") });
            keybord.Selective = true;
            keybord.OneTimeKeyboard = true;
            var chatId = message.Chat.Id;
            /*await botClient.SendTextMessageAsync(chatId,
                "Вы прислали:" + message.Text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyToMessageId: message.MessageId,
                replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton[] { new KeyboardButton("на русский"), new KeyboardButton("на английский") }));*/
            await botClient.SendTextMessageAsync(chatId,
            "Вы прислали:" + message.Text,
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
            replyToMessageId: message.ReplyToMessage.MessageId,
            replyMarkup: keybord);
        }
    }
}
