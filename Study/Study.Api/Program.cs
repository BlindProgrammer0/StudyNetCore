using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Study.EFCore.Context;
using System;

namespace Study.Api
{
    public class Program
    {
        /// <summary>
        /// WEB API服务入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var host = CreateHostBuilder(args).Build();
                //初次加载插入样本数据 -test
                using (var scope = host.Services.CreateScope())
                {
                    var serivces = scope.ServiceProvider;
                    var context = serivces.GetRequiredService<ConsumptionContext>();
                    ConsumptionHelper.InitSampleDataAsync(context).Wait();
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        /// <summary>
        /// 创建主机构建器
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                     .ConfigureLogging(logging =>
                     {
                         logging.ClearProviders();
                         logging.SetMinimumLevel(LogLevel.Trace);
                     }).UseNLog().UseUrls("http://*:5001");
                });
    }
}
