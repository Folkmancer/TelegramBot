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
            botClient.StartReceiving();
            if (botClient.IsReceiving)
            {
                await botClient.SendTextMessageAsync(chatId, TextLayoutTranslator.TranslateIntoRU(message.Text), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
                botClient.StopReceiving();
                // if (!IsValidUsername(update.Message.ReplyToMessage.Text)) return;
                //SaveUsernameToDb(update.Message.Chat.Id, update.Message.ReplyToMessage.Text);
                //Bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                //Bot.SendTextMessage(update.Message.Chat.Id, "Username has been successfully saved!");
            }       
        }
    }
}
