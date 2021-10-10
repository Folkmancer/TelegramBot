using System.Threading.Tasks;
using TinyTinaBot.Models.Enums;
using TinyTinaBot.Models.YandexSpeller;

namespace TinyTinaBot.Services.Interfaces
{
    public interface IYandexSpellerService
    {
        Task<SpellerResult> CheckText(string text, string lang, string textFormat, SpellerOption options);
        Task<SpellerResult[]> CheckTexts(string[] text, string lang, string textFormat, SpellerOption options);
    }
}