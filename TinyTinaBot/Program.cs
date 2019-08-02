using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TinyTinaBot.Models;

namespace TinyTinaBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BotSettings.Url = args[0];
            BotSettings.Name = args[1];
            BotSettings.Key = args[2];
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
