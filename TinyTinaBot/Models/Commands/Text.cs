using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TinyTinaBot.Models.Commands
{
    public class Text : ICommand
    {
        public string Name => @"/text";

        public bool Contains(Message message)
        {
            return message.Text[0] != '/';
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var text = message.Text;

            if (!string.IsNullOrEmpty(text))
            {
                text = await GetProcessedText(text);
            }
            else
            {
                text = "Не удалось получить текст сообщения.";
            }

            await botClient.SendTextMessageAsync(message.Chat.Id, text.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }

        private async Task<string> GetProcessedText(string text)
        {
            var words = await Speller.CheckText(text);

            foreach (var word in words)
            {
                text = text.Replace(word.Word, word.S[0]);
            }

            return text;
        }
    }
}