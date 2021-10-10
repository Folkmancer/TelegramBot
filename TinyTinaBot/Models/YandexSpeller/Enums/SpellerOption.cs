using System;

namespace TinyTinaBot.Models.Enums
{
    [Flags]
    public enum SpellerOption
    {
        IgnoreDigits = 2,
        IgnoreUrls = 4,
        FindRepeatWords = 8,
        IgnoreCapitalization = 512
    }
}