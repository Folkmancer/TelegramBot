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
            await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoRU("message"), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
