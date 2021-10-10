using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TinyTinaBot.Models.Configurations;

namespace TinyTinaBot.Services
{
    public class TelegramBotHostedService : IHostedService
    {
        private readonly ILogger<TelegramBotHostedService> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly BotConfiguration botConfiguration;

        public TelegramBotHostedService(ILogger<TelegramBotHostedService> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.botConfiguration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var clientBot = scope.ServiceProvider.GetService<ITelegramBotClient>();

            var webhookAddress = @$"{botConfiguration.HostAddress}/bot/{botConfiguration.BotToken}";
            logger.LogInformation($"Start telegram bot webhook on address: {webhookAddress}");

            await clientBot.SetWebhookAsync(
                url: webhookAddress, 
                allowedUpdates: Array.Empty<UpdateType>(), 
                cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var clientBot = scope.ServiceProvider.GetService<ITelegramBotClient>();

            logger.LogInformation("Stop telegram bot webhook");

            await clientBot.DeleteWebhookAsync(cancellationToken: cancellationToken);
        }
    }
}