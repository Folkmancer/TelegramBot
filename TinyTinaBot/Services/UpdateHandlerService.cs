using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TinyTinaBot.Services
{
    public class UpdateHandlerService : IUpdateHandlerService
    {
        private readonly ILogger<UpdateHandlerService> logger;
        private readonly ITelegramBotClient botClient;

        public UpdateHandlerService(ILogger<UpdateHandlerService> logger, ITelegramBotClient botClient)
        {
            this.logger = logger;
            this.botClient = botClient;
        }

        public async Task EchoAsync(Update update)
        {
            logger.LogInformation($"Received new update from {update.Message.Chat.Username}");
            await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Test");
        }
    }
}