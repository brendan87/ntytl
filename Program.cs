using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NTytL.Data;

namespace NTytL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            if ((config["DBINIT"] ?? "false") == "true")
            {
                Console.WriteLine("Database initialise");
                Init.DbInit(new ApplicationDbContext());
            }
            else
            {
                Console.WriteLine("Starting web app");
                CreateWebHostBuilder(args).Build().Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
