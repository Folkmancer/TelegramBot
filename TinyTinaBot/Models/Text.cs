using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TinyTinaBot.Models
{
    public class Text : ICommand
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
            var chatId = message.Chat.Id;
            var text = message.Text;
            var words = await Speller.CheckText(text);

            foreach (var word in words)
            {
                text = text.Replace(word.Word, word.S[0]);
            }

            await botClient.SendTextMessageAsync(chatId, text.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}