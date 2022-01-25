using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.UI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            string date = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string filepath = "C:\\Logs\\EmployeeManagementService_" + date + ".txt";
            Log.Logger = new LoggerConfiguration()
                   .Enrich.FromLogContext()
                   .WriteTo.Console()
                   .WriteTo.File(filepath)
                   .MinimumLevel.Information()
                   .CreateLogger();

            try
            {
                Log.Information("Starting up");
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
                throw ex;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = null;
                        serverOptions.Limits.MinRequestBodyDataRate = null;
                        serverOptions.Limits.MinResponseDataRate = null;
                    }).UseStartup<Startup>();
                });
    }
}
