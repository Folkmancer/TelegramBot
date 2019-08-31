using System.Threading.Tasks;
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
            message.Text = message.Text.Replace("/en", "");
            if (message.Text.Length != 0)
            {
                string text = message.Text.Trim();
                await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoEN(text), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            }
            else
                await botClient.SendTextMessageAsync(chatId, "Дайте мне текст!");
        }
    }
}
