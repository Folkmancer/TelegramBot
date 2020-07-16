using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TinyTinaBot.Models;
using Microsoft.Extensions.Logging;

namespace TinyTinaBot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;

        [HttpGet]
        public string Get()
        {
            return "Method GET unuvalable";
        }

        //[HttpPost]
        //public async Task<OkResult> Post(Update update)
        //{
        //    if (update == null)
        //    {
        //        return Ok();
        //    }

        //    var commands = Bot.Commands;
        //    var message = update.Message;
        //    var botClient = await Bot.GetBotClientAsync();

        //    _logger.LogInformation("Received Message from {0}", message.Chat.Id);

        //    foreach (var command in commands)
        //    {
        //        if (command.Contains(message))
        //        {
        //            await command.Execute(message, botClient);
        //            break;
        //        }
        //    }

        //    return Ok();
        //}

        [HttpPost]
        public async Task<OkResult> PostMessage(Update update)
        {
            _logger.LogInformation("Received Message1 from {0}", update.Message.Chat.Id);

            return Ok();
        }
    }
}