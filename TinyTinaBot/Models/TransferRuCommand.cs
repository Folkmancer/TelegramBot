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
            message.Text = message.Text.Replace("/ru", "");
            if (message.Text.Length != 0)
            {
                string text = message.Text.Trim();
                await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoRU(text), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            }
            else
                await botClient.SendTextMessageAsync(chatId, "Дайте мне текст!");
        }
    }
}
