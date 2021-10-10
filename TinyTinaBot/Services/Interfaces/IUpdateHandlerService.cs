using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TinyTinaBot.Services
{
    public interface IUpdateHandlerService
    {
        Task EchoAsync(Update update);
    }
}