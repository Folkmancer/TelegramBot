using System;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;

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
            var chatId = message.Chat.Id;
            CheckText[] words;
            StringBuilder goodText = new StringBuilder();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://speller.yandex.net/services/spellservice.json/checkText");
                var content = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("text", message.Text),
                            new KeyValuePair<string, string>("lang", "ru,en"),
                            new KeyValuePair<string, string>("options", "0")
                        });
                var result = await client.PostAsync("", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                words = JsonConvert.DeserializeObject<CheckText[]>(resultContent);
            }
            foreach (var word in words)
            {
                goodText.Append(word?.S[0] ?? word.Word);
                goodText.Append(" ");
            }
            await botClient.SendTextMessageAsync(chatId, goodText.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
