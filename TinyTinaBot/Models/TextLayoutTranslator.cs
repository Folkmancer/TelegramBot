using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyTinaBot.Models
{
    public class TextLayoutTranslator
    {
        private static string ruL = "ё1234567890-=йцукенгшщзхъфывапролджэ\\ячсмитьбю.";
        private static string ruU = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭ/ЯЧСМИТЬБЮ,";
        private static string enL = "`1234567890-=qwertyuiop[]asdfghjkl;'\\zxcvbnm,./";
        private static string enU = "~!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL:\"|ZXCVBNM<>?";

        public static string TranslateIntoRU(string text)
        {
            string newMessage = default;
            foreach (char symbol in text)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    newMessage += " ";
                    continue;
                }
                else if (enL.Contains(symbol))
                    newMessage += ruL[enL.IndexOf(symbol)];
                else if (enU.Contains(symbol))
                    newMessage += ruU[enU.IndexOf(symbol)];
            }
            return newMessage;
        }

        public static string TranslateIntoEN(string text)
        {
            string newMessage = default;
            foreach (char symbol in text)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    newMessage += " ";
                    continue;
                }
                else if (ruL.Contains(symbol))
                    newMessage += enL[ruL.IndexOf(symbol)];
                else if (ruU.Contains(symbol))
                    newMessage += enU[ruU.IndexOf(symbol)];
            }
            return newMessage;
        }
    }
}
