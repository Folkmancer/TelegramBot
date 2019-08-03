using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TinyTinaBot.Models
{
    public class TransferRuCommand : ICommand
    {
        public string Name => @"/ru";

        public bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendChatActionAsync(chatId, Telegram.Bot.Types.Enums.ChatAction.Typing);
            await botClient.SendTextMessageAsync(chatId, "Дайте мне текст!");
            botClient.IsReceiving = false;
            botClient.StartReceiving();
            if (botClient.IsReceiving)
            {
                await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoRU(message.Text), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                botClient.StopReceiving();
            }       
        }
    }
}
