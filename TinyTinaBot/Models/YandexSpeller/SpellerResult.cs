using Newtonsoft.Json;

namespace TinyTinaBot.Models.YandexSpeller
{
    public class SpellerResult
    {
        /// <summary>
        /// Исходное слово.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; private set; }

        /// <summary>
        /// Подсказка (может быть несколько или могут отсутствовать).
        /// </summary>
        [JsonProperty("s")]
        public string[] Prompt { get; private set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; private set; }

        /// <summary>
        /// Позиция слова с ошибкой (отсчет от 0).
        /// </summary>
        [JsonProperty("pos")]
        public long Position { get; private set; }

        /// <summary>
        /// Номер строки (отсчет от 0).
        /// </summary>
        [JsonProperty("row")]
        public long Row { get; private set; }

        /// <summary>
        /// Номер столбца (отсчет от 0).
        /// </summary>
        [JsonProperty("col")]
        public long Column { get; private set; }

        /// <summary>
        /// Длина слова с ошибкой.
        /// </summary>
        [JsonProperty("len")]
        public long Length { get; private set; }
    }
}