using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TinyTinaBot.Models.Configurations;
using TinyTinaBot.Services;

namespace TinyTinaBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BotConfiguration = Configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }

        public IConfiguration Configuration { get; }
        private BotConfiguration BotConfiguration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<TelegramBotHostedService>();
            services.AddHttpClient("tgwebhook")
                .AddTypedClient<ITelegramBotClient>(httpClient 
                    => new TelegramBotClient(BotConfiguration.BotToken, httpClient));
            services.AddScoped<IUpdateHandlerService, UpdateHandlerService>();
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "tgwebhook",
                                             pattern: $"bot/{BotConfiguration.BotToken}",
                                             new { controller = "Webhook", action = "Post" });
                endpoints.MapControllers();
            });
        }
    }
}