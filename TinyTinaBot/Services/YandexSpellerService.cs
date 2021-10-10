using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TinyTinaBot.Models.Enums;
using TinyTinaBot.Models.YandexSpeller;
using TinyTinaBot.Services.Interfaces;

namespace TinyTinaBot.Services
{
    public class YandexSpellerService : IYandexSpellerService
    {
        private readonly ILogger<YandexSpellerService> logger;
        private readonly string yandexSpellerJsonUrl;

        public YandexSpellerService(ILogger<YandexSpellerService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.yandexSpellerJsonUrl = configuration.GetConnectionString("YandexSpellerJsonUrl");
        }

        public async Task<SpellerResult> CheckText(string text, string lang, string textFormat, SpellerOption options)
        {
            logger.LogInformation("Execute CheckText");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(yandexSpellerJsonUrl);
            var parameters = new Dictionary<string, string>()
            {
                { "text", text.ToString() },
                { "lang", lang },
                { "options", ((int)options).ToString() },
                { "format", textFormat }
            };
            var uri = QueryHelpers.AddQueryString("checkText", parameters);
            var result = await client.GetAsync(uri);
            var resultContent = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SpellerResult>(resultContent);
        }

        public async Task<SpellerResult[]> CheckTexts(string[] text, string lang, string textFormat, SpellerOption options)
        {
            logger.LogInformation("Execute CheckTexts");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(yandexSpellerJsonUrl);
            var parameters = new Dictionary<string, string>()
            {
                { "text", text.ToString() },
                { "lang", lang },
                { "options", ((int)options).ToString() },
                { "format", textFormat }
            };
            var uri = QueryHelpers.AddQueryString("checkTexts", parameters);
            var result = await client.GetAsync(uri);
            var resultContent = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SpellerResult[]>(resultContent);
        }
    }
}