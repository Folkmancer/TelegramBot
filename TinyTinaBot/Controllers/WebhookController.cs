using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TinyTinaBot.Services;

namespace TinyTinaBot.Controllers
{
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> logger;
        private readonly IUpdateHandlerService updateHandlerService;

        public WebhookController(ILogger<WebhookController> logger, IUpdateHandlerService updateHandlerService)
        {
            this.logger = logger;
            this.updateHandlerService = updateHandlerService;
        }

        public async Task<IActionResult> Post(Update update)
        {
            logger.LogInformation($"Received post message");
            await updateHandlerService.EchoAsync(update);
            return Ok();
        }
    }
}