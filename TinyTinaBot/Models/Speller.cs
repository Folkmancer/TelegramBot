using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TinyTinaBot.Models
{
    public class Speller
    {
        public static async Task<CheckText[]> CheckText(string message)
        {
            CheckText[] words;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://speller.yandex.net/services/spellservice.json/checkText");
                var content = new FormUrlEncodedContent(new[] {
                            new KeyValuePair<string, string>("text", message),
                            new KeyValuePair<string, string>("lang", "ru,en"),
                            new KeyValuePair<string, string>("options", "0")
                        });
                var result = await client.PostAsync("", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                words = JsonConvert.DeserializeObject<CheckText[]>(resultContent);
            }
            return words;
        }
    }
}
