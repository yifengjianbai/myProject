﻿using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OpenAuth.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
// .ConfigureLogging((hostingContext, logging) =>
//                {
//                    logging.ClearProviders();  //去掉默认的日志
//                   logging.AddFilter("System", LogLevel.Warning);
//                    logging.AddFilter("Microsoft", LogLevel.Warning);
//                    logging.AddLog4Net();
//                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())   //将默认ServiceProviderFactory指定为AutofacServiceProviderFactory
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:52789").UseStartup<Startup>();
                });
    }
}
