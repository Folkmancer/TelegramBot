﻿using Newtonsoft.Json;

namespace TinyTinaBot.Models
{
    public class CheckText
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
        public string[] S { get; private set; }

        /// <summary>
        /// Информация об ошибке (может быть несколько или могут отсутствовать).
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; private set; }
    }
}