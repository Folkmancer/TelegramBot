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
            int index;
            string newMessage = "";
            foreach (char symbol in text)
            {
                index = enL.IndexOf(symbol);
                if (index != -1) newMessage += ruL[index];
                else
                {
                    index = enU.IndexOf(symbol);
                    if (index != -1) newMessage += ruU[index];
                }
            }
            return newMessage;
        }

        public static string TranslateIntoEN(string text)
        {
            int index;
            string newMessage = "";
            foreach (char symbol in text)
            {
                index = ruL.IndexOf(symbol);
                if (index != -1) newMessage += enL[index];
                else
                {
                    index = ruU.IndexOf(symbol);
                    if (index != -1) newMessage += enU[index];
                }
            }
            return newMessage;
        }
    }
}
